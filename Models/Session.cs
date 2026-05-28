using System;
using System.Collections.Generic;

namespace Model;

public partial class Session
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? SessionTypeId { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public int IsActive { get; set; }

    public virtual ICollection<Academic> Academics { get; set; } = new List<Academic>();

    public virtual ICollection<Achievement> Achievements { get; set; } = new List<Achievement>();

    public virtual ICollection<Entity> Entities { get; set; } = new List<Entity>();

    public virtual ICollection<Membership> Memberships { get; set; } = new List<Membership>();

    public virtual ICollection<PrizeMaster> PrizeMasters { get; set; } = new List<PrizeMaster>();

    public virtual ICollection<Program> Programs { get; set; } = new List<Program>();

    public virtual MasterTypeDetail? SessionType { get; set; }
}
