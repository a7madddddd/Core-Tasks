using System;
using System.Collections.Generic;

namespace Asp_Core_Api_Project.Models;

public partial class UserRole
{
    public int UserId { get; set; }

    public int? UsId { get; set; }

    public string Role { get; set; } = null!;

    public virtual User? Us { get; set; }
}
