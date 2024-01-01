using System;
using System.Collections.Generic;

namespace VisorPosicion5.Models;

public partial class VentaCompraLink
{
    public int LinkId { get; set; }

    public int VentaTransactionId { get; set; }

    public int CompraTransactionId { get; set; }

    public decimal? AmountLinked { get; set; }

    public virtual Operacion CompraTransaction { get; set; } = null!;

    public virtual Operacion VentaTransaction { get; set; } = null!;
}
