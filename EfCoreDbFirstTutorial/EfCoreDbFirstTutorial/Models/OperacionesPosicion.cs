using System;
using System.Collections.Generic;

namespace EfCoreDbFirstTutorial.Models;

public partial class OperacionesPosicion
{
    public DateTime FechaReporte { get; set; }

    public DateTime FechaRegistro { get; set; }

    public int? SolicitudId { get; set; }

    public int? CierreId { get; set; }

    public string Operaciones { get; set; } = null!;

    public string OperacionDetalle { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public decimal Monto { get; set; }

    public string ClienteRut { get; set; } = null!;

    public string? ClienteNombre { get; set; }

    public string Moneda { get; set; } = null!;

    public decimal TipoCambio { get; set; }

    public string Ejecutivo { get; set; } = null!;

    public string Gestion { get; set; } = null!;

    public string? EstadoSolicitud { get; set; }
}
