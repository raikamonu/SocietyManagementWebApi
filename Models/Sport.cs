using System;
using System.Collections.Generic;

namespace Model;

public partial class Sport
{
    public int Id { get; set; }

    public int? EntityId { get; set; }

    public int? Game { get; set; }

    public int? Medal { get; set; }

    public int? Level { get; set; }

    public int? AchievementId { get; set; }

    public string? DocumentProof { get; set; }

    public virtual Achievement? Achievement { get; set; }

    public virtual Entity? Entity { get; set; }

    public virtual MasterTypeDetail? GameNavigation { get; set; }

    public virtual MasterTypeDetail? LevelNavigation { get; set; }

    public virtual MasterTypeDetail? MedalNavigation { get; set; }
}
