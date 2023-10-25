using System;
using System.Collections.Generic;

namespace API.EFModels;

public partial class Sale
{
    public int SaleId { get; set; }

    public int SaleIdShop { get; set; }

    public int SaleIdUser { get; set; }

    public int SaleCountProduct { get; set; }

    public DateTime SaleDate { get; set; }

    public virtual Shop SaleIdShopNavigation { get; set; } = null!;

    public virtual User SaleIdUserNavigation { get; set; } = null!;
}
