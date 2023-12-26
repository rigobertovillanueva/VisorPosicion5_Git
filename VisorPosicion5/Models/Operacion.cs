using System;
using System.Collections.Generic;

namespace VisorPosicion5.Models;

public partial class Operacion
{
    public int TransactionId { get; set; }

    public decimal? Amount { get; set; }

    public decimal? TipoCambio { get; set; }

    public string? Estado { get; set; }

    public DateTime? FechaOperacion { get; set; }

    public string? TipoOperacion { get; set; }

    public decimal? AvailableAmount { get; set; }

    public bool? IsCanceled { get; set; }

    public virtual ICollection<VentaCompraLink> VentaCompraLinkCompraTransactions { get; set; } = new List<VentaCompraLink>();

    public virtual ICollection<VentaCompraLink> VentaCompraLinkVentaTransactions { get; set; } = new List<VentaCompraLink>();
}
