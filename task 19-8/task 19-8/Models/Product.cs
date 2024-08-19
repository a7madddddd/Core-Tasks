using System;
using System.Collections.Generic;

namespace task_19_8.Models;

public partial class Product
{
    public int PId { get; set; }

    public string? PName { get; set; }

    public string? PDes { get; set; }

    public string? PPric { get; set; }

    public string? PImage { get; set; }

    public int? CId { get; set; }

    public virtual Category? CIdNavigation { get; set; }
}
