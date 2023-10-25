using System;
using System.Collections.Generic;

namespace API.EFModels;

public partial class Bookbinding
{
    public int BindingId { get; set; }

    public string BindingTitle { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
