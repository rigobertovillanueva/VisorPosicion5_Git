﻿using System;
using System.Collections.Generic;

namespace ApiTest3.ApiModels;

public partial class Beer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int BrandId { get; set; }

    public virtual Brand Brand { get; set; } = null!;
}
