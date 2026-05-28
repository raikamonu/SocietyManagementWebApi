using System;
using System.Collections.Generic;

namespace Model;

public partial class ProfessionProfile
{
    public int Id { get; set; }

    public int? EntityId { get; set; }

    public int? ReferenceId { get; set; }

    public int? JobType { get; set; }

    public int? Location { get; set; }

    public int? Designation { get; set; }

    public int? Department { get; set; }

    public DateTime? Date { get; set; }

    public int IsActive { get; set; }

    public int? AchievementId { get; set; }

    public virtual Achievement? Achievement { get; set; }

    public virtual MasterTypeDetail? DepartmentNavigation { get; set; }

    public virtual MasterTypeDetail? DesignationNavigation { get; set; }

    public virtual Entity? Entity { get; set; }

    public virtual ICollection<ProfessionProfile> InverseReference { get; set; } = new List<ProfessionProfile>();

    public virtual MasterTypeDetail? JobTypeNavigation { get; set; }

    public virtual Location? LocationNavigation { get; set; }

    public virtual ProfessionProfile? Reference { get; set; }
}
