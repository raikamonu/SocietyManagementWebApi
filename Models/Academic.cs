using System;
using System.Collections.Generic;

namespace Model;

public partial class Academic
{
    public int Id { get; set; }

    public int? EntityId { get; set; }

    public int? Education { get; set; }

    public int? Board { get; set; }

    public int? TotalMarks { get; set; }

    public int? ObtainedMarks { get; set; }

    public decimal? Average { get; set; }

    public int? AcademicSession { get; set; }

    public int? AchievementId { get; set; }

    public string? DocumentProof { get; set; }

    public virtual Session? AcademicSessionNavigation { get; set; }

    public virtual Achievement? Achievement { get; set; }

    public virtual MasterTypeDetail? BoardNavigation { get; set; }

    public virtual MasterTypeDetail? EducationNavigation { get; set; }

    public virtual Entity? Entity { get; set; }
}
