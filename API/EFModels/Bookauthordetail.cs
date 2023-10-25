using System;
using System.Collections.Generic;

namespace API.EFModels;

public partial class Bookauthordetail
{
    public long BookAuthorDetailIsbn { get; set; }

    public int BookAuthorDetailIdAuthor { get; set; }

    public virtual Bookauthor BookAuthorDetailIdAuthorNavigation { get; set; } = null!;

    public virtual Book BookAuthorDetailIsbnNavigation { get; set; } = null!;
}
