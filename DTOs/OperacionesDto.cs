using VisorPosicion5.Models;

namespace VisorPosicion5.DTOs
{
    public class OperacionesDto
    {
        public decimal? Amount { get; set; }
        public decimal? TipoCambio { get; set; }
        public string? Estado { get; set; }
        public DateTime? FechaOperacion { get; set; }
        public string? TipoOperacion { get; set; }

        public OperacionesDto() { }

        public OperacionesDto(Operacion operacion)
        {
            Amount = operacion.Amount;
            TipoCambio = operacion.TipoCambio;
            Estado = operacion.Estado;
            FechaOperacion = operacion.FechaOperacion;
            TipoOperacion = operacion.TipoOperacion;
        }
    }
}