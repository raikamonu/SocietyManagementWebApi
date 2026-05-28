using System;
using System.Collections.Generic;

namespace Model;

public partial class MasterTypeDetail
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public int? ParentId { get; set; }

    public int? MasterTypeId { get; set; }

    public int IsActive { get; set; }

    public int IsEdit { get; set; }

    public int IsDelete { get; set; }

    public DateTime? Date { get; set; }

    public decimal? Srno { get; set; }

    public virtual ICollection<Academic> AcademicBoardNavigations { get; set; } = new List<Academic>();

    public virtual ICollection<Academic> AcademicEducationNavigations { get; set; } = new List<Academic>();

    public virtual ICollection<Achievement> Achievements { get; set; } = new List<Achievement>();

    public virtual ICollection<AddressProfile> AddressProfiles { get; set; } = new List<AddressProfile>();

    public virtual ICollection<ContactProfile> ContactProfiles { get; set; } = new List<ContactProfile>();

    public virtual ICollection<Designation> DesignationDesignation1Navigations { get; set; } = new List<Designation>();

    public virtual ICollection<Designation> DesignationLevelNavigations { get; set; } = new List<Designation>();

    public virtual ICollection<Designation> DesignationLocationNavigations { get; set; } = new List<Designation>();

    public virtual ICollection<DocumentProfile> DocumentProfileDocExtensions { get; set; } = new List<DocumentProfile>();

    public virtual ICollection<DocumentProfile> DocumentProfileDocTypes { get; set; } = new List<DocumentProfile>();

    public virtual ICollection<FundTransaction> FundTransactionBanks { get; set; } = new List<FundTransaction>();

    public virtual ICollection<FundTransaction> FundTransactionStatusNavigations { get; set; } = new List<FundTransaction>();

    public virtual ICollection<MasterTypeDetail> InverseParent { get; set; } = new List<MasterTypeDetail>();

    public virtual ICollection<LinkProfile> LinkProfiles { get; set; } = new List<LinkProfile>();

    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();

    public virtual ICollection<Login> Logins { get; set; } = new List<Login>();

    public virtual MasterType? MasterType { get; set; }

    public virtual ICollection<Membership> MembershipIsPas { get; set; } = new List<Membership>();

    public virtual ICollection<Membership> MembershipPaymentModeNavigations { get; set; } = new List<Membership>();

    public virtual MasterTypeDetail? Parent { get; set; }

    public virtual ICollection<PersonalProfile> PersonalProfileCastNavigations { get; set; } = new List<PersonalProfile>();

    public virtual ICollection<PersonalProfile> PersonalProfileGenderNavigations { get; set; } = new List<PersonalProfile>();

    public virtual ICollection<PrizeMaster> PrizeMasterAchievementTypes { get; set; } = new List<PrizeMaster>();

    public virtual ICollection<PrizeMaster> PrizeMasterLevelNavigations { get; set; } = new List<PrizeMaster>();

    public virtual ICollection<PrizeMaster> PrizeMasterMedalTypeNavigations { get; set; } = new List<PrizeMaster>();

    public virtual ICollection<ProfessionProfile> ProfessionProfileDepartmentNavigations { get; set; } = new List<ProfessionProfile>();

    public virtual ICollection<ProfessionProfile> ProfessionProfileDesignationNavigations { get; set; } = new List<ProfessionProfile>();

    public virtual ICollection<ProfessionProfile> ProfessionProfileJobTypeNavigations { get; set; } = new List<ProfessionProfile>();

    public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();

    public virtual ICollection<SocietyProfile> SocietyProfiles { get; set; } = new List<SocietyProfile>();

    public virtual ICollection<Sport> SportGameNavigations { get; set; } = new List<Sport>();

    public virtual ICollection<Sport> SportLevelNavigations { get; set; } = new List<Sport>();

    public virtual ICollection<Sport> SportMedalNavigations { get; set; } = new List<Sport>();
}
