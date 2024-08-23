using System;
using System.Collections.Generic;

namespace Asp_Core_Api_Project.Models;

public partial class Order
{
    public int OrId { get; set; }

    public int? UsId { get; set; }

    public DateOnly? OrDate { get; set; }

    public virtual User? Us { get; set; }
}
