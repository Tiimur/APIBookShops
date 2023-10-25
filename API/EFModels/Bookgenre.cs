using System;
using System.Collections.Generic;

namespace API.EFModels;

public partial class Bookgenre
{
    public int GenreId { get; set; }

    public string GenreTitle { get; set; } = null!;
}
