using System;
using System.Collections.Generic;

namespace API.EFModels;

public partial class Usercard
{
    public int UserCardId { get; set; }

    public int UserCardIdUser { get; set; }

    public long UserCardBookIsbn { get; set; }

    public sbyte UserCardIsShopCard { get; set; }

    public int? UserCardBookCount { get; set; }

    public virtual Book UserCardBookIsbnNavigation { get; set; } = null!;

    public virtual User UserCardIdUserNavigation { get; set; } = null!;
}
