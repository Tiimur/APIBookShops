using System;
using System.Collections.Generic;

namespace API.EFModels;

public partial class Bookseries
{
    public int SerieId { get; set; }

    public string SerieTitle { get; set; } = null!;

    public string SerieDescription { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
