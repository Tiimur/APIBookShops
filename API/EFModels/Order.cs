using System;
using System.Collections.Generic;

namespace API.EFModels;

public partial class Order
{
    public int OrderId { get; set; }

    public int OrderIdShop { get; set; }

    public int OrderIdCustomer { get; set; }

    public int OrderCountProduct { get; set; }

    public int OrderIdStatus { get; set; }

    public int OrderIdEmployee { get; set; }

    public DateOnly OrderDate { get; set; }

    public virtual User OrderIdCustomerNavigation { get; set; } = null!;

    public virtual User OrderIdEmployeeNavigation { get; set; } = null!;

    public virtual Shop OrderIdShopNavigation { get; set; } = null!;

    public virtual Orderstatus OrderIdStatusNavigation { get; set; } = null!;
}
