using System;
using System.Collections.Generic;

namespace API.EFModels;

public partial class Orderproduct
{
    public int OrderId { get; set; }

    public long OrderBookIsbn { get; set; }

    public int OrderBookCount { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Book OrderBookIsbnNavigation { get; set; } = null!;
}
