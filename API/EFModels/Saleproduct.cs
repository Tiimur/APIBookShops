using System;
using System.Collections.Generic;

namespace API.EFModels;

public partial class Saleproduct
{
    public int SaleId { get; set; }

    public long SaleBookIsbn { get; set; }

    public int SaleBookCount { get; set; }

    public virtual Sale Sale { get; set; } = null!;

    public virtual Book SaleBookIsbnNavigation { get; set; } = null!;
}
