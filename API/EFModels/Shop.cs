using System;
using System.Collections.Generic;

namespace API.EFModels;

public partial class Shop
{
    public int ShopId { get; set; }

    public int ShopIndex { get; set; }

    public string ShopCity { get; set; } = null!;

    public string ShopStreet { get; set; } = null!;

    public string ShopRegeon { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    public virtual ICollection<Storedproduct> Storedproducts { get; set; } = new List<Storedproduct>();
}
