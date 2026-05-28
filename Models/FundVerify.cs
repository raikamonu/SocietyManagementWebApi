using System;
using System.Collections.Generic;

namespace Model;

public partial class FundVerify
{
    public int Id { get; set; }

    public int? FundId { get; set; }

    public int? VerifyStatus { get; set; }

    public DateTime? VerifyDate { get; set; }

    public int? VerifyEntityId { get; set; }

    public virtual FundTransaction? Fund { get; set; }

    public virtual Entity? VerifyEntity { get; set; }
}
