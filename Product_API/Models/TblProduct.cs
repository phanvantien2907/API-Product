using System;
using System.Collections.Generic;

namespace Product_API.Models;

public partial class TblProduct
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public string? Alias { get; set; }

    public double? Price { get; set; }

    public double? PriceSale { get; set; }

    public string? Images { get; set; }

    public string? Sku { get; set; }

    public bool? Status { get; set; }

    public string? MainIngredients { get; set; }

    public string? SuitableFor { get; set; }

    public string? Capacity { get; set; }

    public int? Quantity { get; set; }
}
