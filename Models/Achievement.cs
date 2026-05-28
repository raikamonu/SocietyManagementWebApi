using System;
using System.Collections.Generic;

namespace Model;

public partial class Achievement
{
    public int Id { get; set; }

    public int? EntityId { get; set; }

    public int? AchievementTypeId { get; set; }

    public decimal? Amount { get; set; }

    public int? SessionId { get; set; }

    public int? ProgramId { get; set; }

    public string? Description { get; set; }

    public DateTime? Date { get; set; }

    public virtual ICollection<Academic> Academics { get; set; } = new List<Academic>();

    public virtual MasterTypeDetail? AchievementType { get; set; }

    public virtual ICollection<AchievementVerify> AchievementVerifies { get; set; } = new List<AchievementVerify>();

    public virtual Entity? Entity { get; set; }

    public virtual ICollection<ProfessionProfile> ProfessionProfiles { get; set; } = new List<ProfessionProfile>();

    public virtual Program? Program { get; set; }

    public virtual Session? Session { get; set; }

    public virtual ICollection<Sport> Sports { get; set; } = new List<Sport>();
}
