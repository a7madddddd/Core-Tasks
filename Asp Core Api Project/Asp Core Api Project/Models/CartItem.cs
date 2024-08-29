using System;
using System.Collections.Generic;

namespace Asp_Core_Api_Project.Models;

public partial class CartItem
{
    public int CartItemId { get; set; }

    public int? CartId { get; set; }

    public int? PId { get; set; }

    public int Quantity { get; set; }

    //public virtual Cart? Cart { get; set; }

    public Cart Cart { get; set; }
    public Product Product { get; set; }
}
