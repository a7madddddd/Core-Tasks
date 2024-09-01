using System;
using System.Collections.Generic;

namespace Asp_Core_Api_Project.Models;

public partial class User
{
    public int UsId { get; set; }

    public string? UsName { get; set; }

    public string? UsPas { get; set; }

    public string? UsEm { get; set; }

    public byte[]? PasswordHash { get; set; }

    public byte[]? PasswordSalt { get; set; }

    public virtual Cart? Cart { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
