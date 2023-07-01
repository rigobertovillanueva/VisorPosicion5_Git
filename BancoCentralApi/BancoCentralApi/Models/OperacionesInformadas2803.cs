using System;
using System.Collections.Generic;

namespace BancoCentralApi.Models;

public partial class OperacionesInformadas2803
{
    public short Id { get; set; }

    public DateTime FechaRegistro { get; set; }

    public int? SolicitudId { get; set; }

    public int? CierreId { get; set; }

    public string Tipo { get; set; } = null!;

    public int Planilla { get; set; }

    public string Operaciones { get; set; } = null!;

    public string OperacionDetalle { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public string? EstadoSolicitud { get; set; }

    public double Monto { get; set; }

    public decimal ClienteRut { get; set; }

    public string ClienteNombre { get; set; } = null!;

    public string Moneda { get; set; } = null!;

    public double TipoCambio { get; set; }

    public string Ejecutivo { get; set; } = null!;

    public string Gestion { get; set; } = null!;
}
