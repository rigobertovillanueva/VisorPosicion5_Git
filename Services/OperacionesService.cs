using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisorPosicion5.Models;
using Microsoft.EntityFrameworkCore;

namespace VisorPosicion5.Services
{
    public class OperacionesService : IOperacionesService
    {
        private readonly VisorPosicionContext _context;

        public OperacionesService(VisorPosicionContext context)
        {
            _context = context;
        }

        public class TransactionRevenue
        {
            public int TransactionId { get; set; }
            public decimal Revenue { get; set; }
        }

        public async Task AddAsync(Operacion operacion)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    if (operacion.TipoOperacion == "compra")
                    {
                        operacion.AvailableAmount = operacion.Amount;
                        _context.Operacions.Add(operacion);
                    }
                    else if (operacion.TipoOperacion == "venta")
                    {
                        await ProcessVentaAsync(operacion);
                    }
                    // Optionally handle other operation types

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    // Consider logging the error
                    Console.WriteLine(ex.ToString());
                    throw; // Re-throw the exception to be handled further up the call stack
                }
            }
        }

        public async Task<List<Operacion>> GetAllAsync()
        {
            return await _context.Operacions.ToListAsync();
        }

        // Other methods...

        public async Task<(decimal PosicionUSD, decimal fifoRevenue, List<TransactionRevenue> topRevenueTransactions)> CalculateFifoAsync()
        {
            var operations = await _context.Operacions
                                           .OrderBy(op => op.FechaOperacion)
                                           .ToListAsync();

            // PosicionUSD is the sum of AvailableAmount from compra operations
            decimal PosicionUSD = operations.Where(op => op.TipoOperacion == "compra")
                                            .Sum(op => op.AvailableAmount.HasValue ? op.AvailableAmount.Value : 0);

            decimal fifoRevenue = 0;
            var topRevenueTransactions = new List<TransactionRevenue>();

            foreach (var venta in operations.Where(op => op.TipoOperacion == "venta"))
            {
                var linkedCompraRecords = _context.VentaCompraLinks
                                                  .Where(link => link.VentaTransactionId == venta.TransactionId);

                foreach (var link in linkedCompraRecords)
                {
                    var compra = _context.Operacions.Find(link.CompraTransactionId);
                    if (compra != null && venta.TipoCambio.HasValue && compra.TipoCambio.HasValue)
                    {
                        decimal amountFromCompra = link.AmountLinked.HasValue ? link.AmountLinked.Value : 0;
                        decimal revenue = (venta.TipoCambio.Value - compra.TipoCambio.Value) * amountFromCompra;

                        fifoRevenue += revenue;
                        if (revenue > 0)
                        {
                            topRevenueTransactions.Add(new TransactionRevenue { TransactionId = venta.TransactionId, Revenue = revenue });
                        }
                    }
                }
            }

            topRevenueTransactions = topRevenueTransactions.OrderByDescending(tr => tr.Revenue).ToList();

            return (PosicionUSD, fifoRevenue, topRevenueTransactions);
        }




        // Inside the OperacionesService class
        public async Task CancelSaleAsync(int transactionId)
        {
            var operacionToCancel = await _context.Operacions.FindAsync(transactionId);
            if (operacionToCancel == null || operacionToCancel.TipoOperacion != "venta")
            {
                throw new InvalidOperationException("Sale transaction not found or not a sale.");
            }
            // Continue with cancellation logic...
        }

        public async Task ProcessVentaAsync(Operacion venta)
        {
            if (venta.TransactionId == 0)
            {
                _context.Operacions.Add(venta);
                await _context.SaveChangesAsync();
            }

            var amountToSell = venta.Amount ?? 0;
            var eligibleCompras = await _context.Operacions
                .Where(o => o.TipoOperacion == "compra" && o.AvailableAmount >= amountToSell)
                .OrderBy(o => o.FechaOperacion)
                .ToListAsync();

            if (!eligibleCompras.Any())
            {
                throw new InvalidOperationException("No sufficient 'compra' to cover 'venta'");
            }

            foreach (var compra in eligibleCompras)
            {
                if (amountToSell <= 0) break;

                decimal amountFromThisCompra = Math.Min(compra.AvailableAmount.Value, amountToSell);
                amountToSell -= amountFromThisCompra;
                compra.AvailableAmount -= amountFromThisCompra;

                var link = new VentaCompraLink
                {
                    VentaTransactionId = venta.TransactionId,
                    CompraTransactionId = compra.TransactionId,
                    AmountLinked = amountFromThisCompra
                };

                Console.WriteLine($"Linking Venta ID: {venta.TransactionId} with Compra ID: {compra.TransactionId}");
                _context.VentaCompraLinks.Add(link);
            }

            await _context.SaveChangesAsync();
        }

        // Additional methods would go here...

    }
}
