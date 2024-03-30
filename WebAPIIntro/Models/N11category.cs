using System;
using System.Collections.Generic;

namespace WebAPIIntro.Models;

public partial class N11category
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? TopCategoryId { get; set; }
}
