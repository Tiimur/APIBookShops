using System;
using System.Collections.Generic;

namespace API.EFModels;

public partial class Storedproduct
{
    public int StoredProductId { get; set; }

    public long StoredProductIsbn { get; set; }

    public int StoredProductIdShop { get; set; }

    public int StoredProductCount { get; set; }

    public int StoredProductIdStatus { get; set; }

    public DateTime StoredProductDateChange { get; set; }

    public virtual Shop StoredProductIdShopNavigation { get; set; } = null!;

    public virtual Storedproductstatus StoredProductIdStatusNavigation { get; set; } = null!;

    public virtual Book StoredProductIsbnNavigation { get; set; } = null!;
}
