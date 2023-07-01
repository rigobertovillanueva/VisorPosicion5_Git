using System;
using System.Collections.Generic;

namespace DataBase.Models;

public partial class Paridade
{
    public int ParidadesId { get; set; }

    public int MonedaId { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal MontoDolar { get; set; }

    public decimal MontoPesos { get; set; }

    public string? MonedaCodigo { get; set; }

    public int? PaisCodigo { get; set; }
}
