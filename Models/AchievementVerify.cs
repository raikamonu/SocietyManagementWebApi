using System;
using System.Collections.Generic;

namespace Model;

public partial class AchievementVerify
{
    public int Id { get; set; }

    public int? AchievementId { get; set; }

    public int? VerifyId { get; set; }

    public string? Description { get; set; }

    public DateTime? Date { get; set; }

    public virtual Achievement? Achievement { get; set; }

    public virtual Entity? Verify { get; set; }
}
