using System;
using System.Collections.Generic;

namespace API.EFModels;

public partial class Bookpublisher
{
    public int PublisherId { get; set; }

    public string PublisherTitle { get; set; } = null!;

    public string PublisherNumPhone { get; set; } = null!;

    public int PublisherIndex { get; set; }

    public string PublisherCity { get; set; } = null!;

    public string PublisherStreet { get; set; } = null!;

    public string PublisherRegeon { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
