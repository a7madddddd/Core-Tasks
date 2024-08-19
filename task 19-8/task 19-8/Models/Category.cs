using System;
using System.Collections.Generic;

namespace task_19_8.Models;

public partial class Category
{
    public int CId { get; set; }

    public string? CName { get; set; }

    public string? CImage { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
