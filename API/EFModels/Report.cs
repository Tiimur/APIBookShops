using System;
using System.Collections.Generic;

namespace API.EFModels;

public partial class Report
{
    public int ReportId { get; set; }

    public int ReportIdShop { get; set; }

    public byte[] ReportFile { get; set; } = null!;

    public DateTime ReportDate { get; set; }

    public virtual Shop ReportIdShopNavigation { get; set; } = null!;
}
