namespace VisorPosicion5.DTOs
{
    public class OperacionRequestDto
    {
        public decimal? Amount { get; set; }
        public decimal? TipoCambio { get; set; }
        public string? Estado { get; set; }
        public DateTime? FechaOperacion { get; set; }
        public string? TipoOperacion { get; set; }
    }
}