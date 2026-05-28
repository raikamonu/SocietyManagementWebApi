using System;
using System.Collections.Generic;

namespace Model;

public partial class TransactionDetail
{
    public int Id { get; set; }

    public int? EntityId { get; set; }

    public int? FundId { get; set; }

    public string? TransactionType { get; set; }

    public int? TypeId { get; set; }

    public virtual Entity? Entity { get; set; }

    public virtual FundTransaction? Fund { get; set; }
}
