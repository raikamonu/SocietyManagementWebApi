using System;
using System.Collections.Generic;

namespace Model;

public partial class Location
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public int? ParentId { get; set; }

    public int? TypeId { get; set; }

    public int IsActive { get; set; }

    public virtual ICollection<AddressProfile> AddressProfiles { get; set; } = new List<AddressProfile>();

    public virtual ICollection<Location> InverseParent { get; set; } = new List<Location>();

    public virtual Location? Parent { get; set; }

    public virtual ICollection<ProfessionProfile> ProfessionProfiles { get; set; } = new List<ProfessionProfile>();

    public virtual ICollection<Program> Programs { get; set; } = new List<Program>();

    public virtual MasterTypeDetail? Type { get; set; }
}
