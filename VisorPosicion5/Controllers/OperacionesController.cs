using Azure;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VisorPosicion5.Models;
using VisorPosicion5.Services;
using VisorPosicion5.DTOs; // Updated namespace

[Route("api/[controller]")]
[ApiController]
public class OperacionesController : ControllerBase
{
    private readonly IOperacionesService _operacionesService;

    public OperacionesController(IOperacionesService operacionesService)
    {
        _operacionesService = operacionesService;
    }

    // ... Other methods ...

    // GET: api/Operaciones/CalculateFifo
    [HttpGet("CalculateFifo")]
    public async Task<IActionResult> CalculateFifo()
    {
        try
        {
            var (totalAmount, fifoRevenue, topRevenueTransactions) = await _operacionesService.CalculateFifoAsync();
            var result = new
            {
                TotalAmountUSD = totalAmount,
                FifoRevenueCLP = fifoRevenue,
                TopRevenueTransactions = topRevenueTransactions
            };
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Internal Server Error: " + ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddOperacion([FromBody] OperacionRequestDto operacionDto)
    {
        // Convert DTO to Entity here
        Operacion operacion = new Operacion
        {
            Amount = operacionDto.Amount,
            TipoCambio = operacionDto.TipoCambio,
            Estado = operacionDto.Estado,
            FechaOperacion = operacionDto.FechaOperacion,
            TipoOperacion = operacionDto.TipoOperacion
        };

        await _operacionesService.AddAsync(operacion);

        // Create response DTO from the entity
        var responseDto = new OperacionesDto(operacion);

        return Ok(responseDto);
    }

    [HttpPost("CancelSale/{transactionId}")]
    public async Task<IActionResult> CancelSale(int transactionId)
    {
        try
        {
            await _operacionesService.CancelSaleAsync(transactionId);
            return Ok($"Sale with TransactionId {transactionId} has been cancelled.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Internal Server Error: " + ex.Message);
        }
    }

    


    // ... Additional methods ...
}
