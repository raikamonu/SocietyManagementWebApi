using System;
using System.Collections.Generic;

namespace Model;

public partial class MembershipPlan
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Amount { get; set; }

    public int? ValidityMonth { get; set; }

    public int IsRenewal { get; set; }

    public int IsActive { get; set; }

    public virtual ICollection<Membership> Memberships { get; set; } = new List<Membership>();
}
