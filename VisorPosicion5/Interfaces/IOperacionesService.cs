using VisorPosicion5.Models;
using static VisorPosicion5.Services.OperacionesService;

namespace VisorPosicion5.Services
{
    public interface IOperacionesService
    {
        Task AddAsync(Operacion operacion);
        Task<List<Operacion>> GetAllAsync();
        Task CancelSaleAsync(int transactionId);
        Task ProcessVentaAsync(Operacion venta);
        Task<(decimal totalAmount, decimal fifoRevenue, List<TransactionRevenue> topRevenueTransactions)> CalculateFifoAsync();
    }
}
