using System;
using System.Collections.Generic;

namespace ApiPractice2;

public partial class Brand
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Beer> Beers { get; } = new List<Beer>();
}
