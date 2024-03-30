using System;
using System.Collections.Generic;

namespace WebAPIIntro.Models;

public partial class VwProductDetail
{
    public string ProductName { get; set; } = null!;

    public decimal? UnitPrice { get; set; }

    public short? UnitsInStock { get; set; }

    public string CategoryName { get; set; } = null!;

    public string CompanyName { get; set; } = null!;
}
