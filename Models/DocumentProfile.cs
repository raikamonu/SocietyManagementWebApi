using System;
using System.Collections.Generic;

namespace Model;

public partial class DocumentProfile
{
    public int Id { get; set; }

    public int? EntityId { get; set; }

    public int? DocTypeId { get; set; }

    public string? Path { get; set; }

    public int? DocExtensionId { get; set; }

    public string? DocumentNo { get; set; }

    public string? AltTag { get; set; }

    public DateTime? Date { get; set; }

    public int IsActive { get; set; }

    public virtual MasterTypeDetail? DocExtension { get; set; }

    public virtual MasterTypeDetail? DocType { get; set; }

    public virtual Entity? Entity { get; set; }
}
