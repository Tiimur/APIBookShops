using System;
using System.Collections.Generic;

namespace API.EFModels;

public partial class Role
{
    public int RoleId { get; set; }

    public string RoleTitle { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
