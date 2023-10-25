using System;
using System.Collections.Generic;

namespace API.EFModels;

public partial class Book
{
    public long BookIsbn { get; set; }

    public string BookTitle { get; set; } = null!;

    public string BookDescription { get; set; } = null!;

    public int? BookIdSeries { get; set; }

    public int? BookCirculation { get; set; }

    public int BookIdPublisher { get; set; }

    public int BookIdBinding { get; set; }

    public string BookSize { get; set; } = null!;

    public int BookPageCount { get; set; }

    public decimal BookPrice { get; set; }

    public int? BookDiscount { get; set; }

    public int? BooksQuantityInNetwork { get; set; }

    public virtual Bookbinding BookIdBindingNavigation { get; set; } = null!;

    public virtual Bookpublisher BookIdPublisherNavigation { get; set; } = null!;

    public virtual Bookseries? BookIdSeriesNavigation { get; set; }

    public virtual ICollection<Storedproduct> Storedproducts { get; set; } = new List<Storedproduct>();

    public virtual ICollection<Usercard> Usercards { get; set; } = new List<Usercard>();
}
