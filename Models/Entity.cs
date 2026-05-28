using System;
using System.Collections.Generic;

namespace Model;

public partial class Entity
{
    public int Id { get; set; }

    public DateTime? Date { get; set; }

    public int IsActive { get; set; }

    public int IsDelete { get; set; }

    public int? SessionId { get; set; }

    public virtual ICollection<Academic> Academics { get; set; } = new List<Academic>();

    public virtual ICollection<AchievementVerify> AchievementVerifies { get; set; } = new List<AchievementVerify>();

    public virtual ICollection<Achievement> Achievements { get; set; } = new List<Achievement>();

    public virtual ICollection<AddressProfile> AddressProfiles { get; set; } = new List<AddressProfile>();

    public virtual ICollection<BasicProfile> BasicProfiles { get; set; } = new List<BasicProfile>();

    public virtual ICollection<ContactProfile> ContactProfiles { get; set; } = new List<ContactProfile>();

    public virtual ICollection<Designation> Designations { get; set; } = new List<Designation>();

    public virtual ICollection<DocumentProfile> DocumentProfiles { get; set; } = new List<DocumentProfile>();

    public virtual ICollection<FundVerify> FundVerifies { get; set; } = new List<FundVerify>();

    public virtual ICollection<LinkProfile> LinkProfileCoordinators { get; set; } = new List<LinkProfile>();

    public virtual ICollection<LinkProfile> LinkProfileEntities { get; set; } = new List<LinkProfile>();

    public virtual ICollection<Login> Logins { get; set; } = new List<Login>();

    public virtual ICollection<Membership> Memberships { get; set; } = new List<Membership>();

    public virtual ICollection<PersonalProfile> PersonalProfiles { get; set; } = new List<PersonalProfile>();

    public virtual ICollection<ProfessionProfile> ProfessionProfiles { get; set; } = new List<ProfessionProfile>();

    public virtual Session? Session { get; set; }

    public virtual ICollection<SocietyProfile> SocietyProfiles { get; set; } = new List<SocietyProfile>();

    public virtual ICollection<Sport> Sports { get; set; } = new List<Sport>();

    public virtual ICollection<TransactionDetail> TransactionDetails { get; set; } = new List<TransactionDetail>();
}
