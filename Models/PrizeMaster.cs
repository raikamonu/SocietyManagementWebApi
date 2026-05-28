using System;
using System.Collections.Generic;

namespace Model;

public partial class PrizeMaster
{
    public int Id { get; set; }

    public int? AchievementTypeId { get; set; }

    public int? Level { get; set; }

    public int? MedalType { get; set; }

    public int? SessionId { get; set; }

    public int? Prize { get; set; }

    public int IsActive { get; set; }

    public virtual MasterTypeDetail? AchievementType { get; set; }

    public virtual MasterTypeDetail? LevelNavigation { get; set; }

    public virtual MasterTypeDetail? MedalTypeNavigation { get; set; }

    public virtual Session? Session { get; set; }
}
