using System;
using System.Collections.Generic;

namespace API.EFModels;

public partial class Storedproductstatus
{
    public int StoredProductStatusId { get; set; }

    public string StoredProductStatusTitle { get; set; } = null!;

    public virtual ICollection<Storedproduct> Storedproducts { get; set; } = new List<Storedproduct>();
}
