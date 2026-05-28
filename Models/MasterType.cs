using System;
using System.Collections.Generic;

namespace Model;

public partial class MasterType
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? ParentId { get; set; }

    public int IsActive { get; set; }

    public int IsEdit { get; set; }

    public int IsDelete { get; set; }

    public DateTime? Date { get; set; }

    public decimal? Srno { get; set; }

    public virtual ICollection<MasterType> InverseParent { get; set; } = new List<MasterType>();

    public virtual ICollection<MasterTypeDetail> MasterTypeDetails { get; set; } = new List<MasterTypeDetail>();

    public virtual MasterType? Parent { get; set; }
}
