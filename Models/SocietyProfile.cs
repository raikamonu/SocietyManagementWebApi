using System;
using System.Collections.Generic;

namespace Model;

public partial class SocietyProfile
{
    public int Id { get; set; }

    public int? EntityId { get; set; }

    public int? ReferenceId { get; set; }

    public int? SessionId { get; set; }

    public int? EntityTypeId { get; set; }

    public int IsActive { get; set; }

    public virtual Entity? Entity { get; set; }

    public virtual MasterTypeDetail? EntityType { get; set; }

    public virtual ICollection<SocietyProfile> InverseReference { get; set; } = new List<SocietyProfile>();

    public virtual SocietyProfile? Reference { get; set; }
}
