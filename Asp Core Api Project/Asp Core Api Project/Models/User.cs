using System;
using System.Collections.Generic;

namespace Asp_Core_Api_Project.Models;

public partial class User
{
    public int UsId { get; set; }

    public string? UsName { get; set; }

    public string? UsPas { get; set; }

    public string? UsEm { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
