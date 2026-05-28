using System;
using System.Collections.Generic;

namespace Model;

public partial class FundTransaction
{
    public int Id { get; set; }

    public string? ChequeNo { get; set; }

    public string? Name { get; set; }

    public DateTime? Date { get; set; }

    public int? BankId { get; set; }

    public string? PaymentType { get; set; }

    public decimal? Amount { get; set; }

    public string? AmountInWord { get; set; }

    public string? FundType { get; set; }

    public int? Status { get; set; }

    public DateTime? FundExpiryDate { get; set; }

    public virtual MasterTypeDetail? Bank { get; set; }

    public virtual ICollection<FundVerify> FundVerifies { get; set; } = new List<FundVerify>();

    public virtual MasterTypeDetail? StatusNavigation { get; set; }

    public virtual ICollection<TransactionDetail> TransactionDetails { get; set; } = new List<TransactionDetail>();
}
