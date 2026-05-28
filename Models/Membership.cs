using System;
using System.Collections.Generic;

namespace Model;

public partial class Membership
{
    public int Id { get; set; }

    public int? EntityId { get; set; }

    public int? ReferenceId { get; set; }

    public int? MembershipPlanId { get; set; }

    public int? AmountPaid { get; set; }

    public int? PaymentMode { get; set; }

    public int? ReceiptNo { get; set; }

    public int? SessionId { get; set; }

    public DateTime? DueDate { get; set; }

    public DateTime? PaidDate { get; set; }

    public int? IsPaid { get; set; }

    public virtual Entity? Entity { get; set; }

    public virtual ICollection<Membership> InverseReference { get; set; } = new List<Membership>();

    public virtual MasterTypeDetail? IsPa { get; set; }

    public virtual MembershipPlan? MembershipPlan { get; set; }

    public virtual MasterTypeDetail? PaymentModeNavigation { get; set; }

    public virtual Membership? Reference { get; set; }

    public virtual Session? Session { get; set; }
}
