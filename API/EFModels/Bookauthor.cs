using System;
using System.Collections.Generic;

namespace API.EFModels;

public partial class Bookauthor
{
    public int AuthorId { get; set; }

    public string AuthorSurname { get; set; } = null!;

    public string AuthorName { get; set; } = null!;

    public string AuthorPatronymic { get; set; } = null!;
}
