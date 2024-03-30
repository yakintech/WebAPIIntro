using System;
using System.Collections.Generic;

namespace WebAPIIntro.Models;

public partial class ProductStockLog
{
    public int Id { get; set; }

    public int? ProductId { get; set; }

    public DateTime? AddDate { get; set; }

    public int? OldStock { get; set; }

    public int? NewStock { get; set; }

    public virtual Product? Product { get; set; }
}
