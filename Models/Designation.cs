using System;
using System.Collections.Generic;

namespace Model;

public partial class Designation
{
    public int Id { get; set; }

    public int? EntityId { get; set; }

    public int? Designation1 { get; set; }

    public int? Level { get; set; }

    public int? Location { get; set; }

    public DateTime? Date { get; set; }

    public int IsDefault { get; set; }

    public virtual MasterTypeDetail? Designation1Navigation { get; set; }

    public virtual Entity? Entity { get; set; }

    public virtual MasterTypeDetail? LevelNavigation { get; set; }

    public virtual MasterTypeDetail? LocationNavigation { get; set; }
}
