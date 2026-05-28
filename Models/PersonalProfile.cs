using System;
using System.Collections.Generic;

namespace Model;

public partial class PersonalProfile
{
    public int Id { get; set; }

    public int? EntityId { get; set; }

    public string? FatherName { get; set; }

    public string? MotherName { get; set; }

    public DateTime? Dob { get; set; }

    public int? Gender { get; set; }

    public int? Cast { get; set; }

    public virtual MasterTypeDetail? CastNavigation { get; set; }

    public virtual Entity? Entity { get; set; }

    public virtual MasterTypeDetail? GenderNavigation { get; set; }
}
