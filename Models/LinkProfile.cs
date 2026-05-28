using System;
using System.Collections.Generic;

namespace Model;

public partial class LinkProfile
{
    public int Id { get; set; }

    public int? EntityId { get; set; }

    public int? CoordinatorId { get; set; }

    public int? Relation { get; set; }

    public string? Groupno { get; set; }

    public virtual Entity? Coordinator { get; set; }

    public virtual Entity? Entity { get; set; }

    public virtual MasterTypeDetail? RelationNavigation { get; set; }
}
