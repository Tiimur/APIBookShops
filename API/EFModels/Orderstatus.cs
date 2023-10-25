using System;
using System.Collections.Generic;

namespace API.EFModels;

public partial class Orderstatus
{
    public int StatusId { get; set; }

    public string StatusTitle { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
