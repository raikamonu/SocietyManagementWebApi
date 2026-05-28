using System;
using System.Collections.Generic;

namespace Model;

public partial class Login
{
    public int Id { get; set; }

    public int? EntityId { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public int? RoleId { get; set; }

    public DateTime? Date { get; set; }

    public int IsActive { get; set; }

    public virtual Entity? Entity { get; set; }

    public virtual MasterTypeDetail? Role { get; set; }
}
