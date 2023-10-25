using System;
using System.Collections.Generic;

namespace API.EFModels;

public partial class User
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string UserSurname { get; set; } = null!;

    public string? UserPatronymic { get; set; }

    public string UserNumPhone { get; set; } = null!;

    public string? UserLogin { get; set; }

    public string? UserPassword { get; set; }

    public string? UserEmail { get; set; }

    public DateOnly? UserDateBirth { get; set; }

    public int UserIdRole { get; set; }

    public virtual ICollection<Order> OrderOrderIdCustomerNavigations { get; set; } = new List<Order>();

    public virtual ICollection<Order> OrderOrderIdEmployeeNavigations { get; set; } = new List<Order>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    public virtual Role UserIdRoleNavigation { get; set; } = null!;

    public virtual ICollection<Usercard> Usercards { get; set; } = new List<Usercard>();
}
