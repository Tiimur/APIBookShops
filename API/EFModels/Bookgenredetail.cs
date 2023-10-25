using System;
using System.Collections.Generic;

namespace API.EFModels;

public partial class Bookgenredetail
{
    public long BookGenreDetailIsbn { get; set; }

    public int BookGenreDetailIdGenre { get; set; }

    public virtual Bookgenre BookGenreDetailIdGenreNavigation { get; set; } = null!;

    public virtual Book BookGenreDetailIsbnNavigation { get; set; } = null!;
}
