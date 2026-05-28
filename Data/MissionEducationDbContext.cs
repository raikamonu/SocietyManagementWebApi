using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Data;

public partial class MissionEducationDbContext : DbContext
{
    public MissionEducationDbContext()
    {
    }

    public MissionEducationDbContext(DbContextOptions<MissionEducationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Academic> Academics { get; set; }

    public virtual DbSet<Achievement> Achievements { get; set; }

    public virtual DbSet<AchievementVerify> AchievementVerifies { get; set; }

    public virtual DbSet<AddressProfile> AddressProfiles { get; set; }

    public virtual DbSet<BasicProfile> BasicProfiles { get; set; }

    public virtual DbSet<ContactProfile> ContactProfiles { get; set; }

    public virtual DbSet<Designation> Designations { get; set; }

    public virtual DbSet<DocumentProfile> DocumentProfiles { get; set; }

    public virtual DbSet<Entity> Entities { get; set; }

    public virtual DbSet<FundTransaction> FundTransactions { get; set; }

    public virtual DbSet<FundVerify> FundVerifies { get; set; }

    public virtual DbSet<LinkProfile> LinkProfiles { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<MasterType> MasterTypes { get; set; }

    public virtual DbSet<MasterTypeDetail> MasterTypeDetails { get; set; }

    public virtual DbSet<Membership> Memberships { get; set; }

    public virtual DbSet<MembershipPlan> MembershipPlans { get; set; }

    public virtual DbSet<PersonalProfile> PersonalProfiles { get; set; }

    public virtual DbSet<PrizeMaster> PrizeMasters { get; set; }

    public virtual DbSet<ProfessionProfile> ProfessionProfiles { get; set; }

    public virtual DbSet<Program> Programs { get; set; }

    public virtual DbSet<Session> Sessions { get; set; }

    public virtual DbSet<SocietyProfile> SocietyProfiles { get; set; }

    public virtual DbSet<Sport> Sports { get; set; }

    public virtual DbSet<TransactionDetail> TransactionDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=101.53.149.28,1232;Database=MissionEducationDB;Persist Security Info=True;User Id=UserMission;Password=Mission@#123;MultipleActiveResultSets=True;Encrypt=False;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Academic>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Academic__3214EC07C14E7E47");

            entity.ToTable("Academic");

            entity.Property(e => e.Average).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DocumentProof)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.AcademicSessionNavigation).WithMany(p => p.Academics)
                .HasForeignKey(d => d.AcademicSession)
                .HasConstraintName("FK__Academic__Academ__3587F3E0");

            entity.HasOne(d => d.Achievement).WithMany(p => p.Academics)
                .HasForeignKey(d => d.AchievementId)
                .HasConstraintName("FK__Academic__Achiev__367C1819");

            entity.HasOne(d => d.BoardNavigation).WithMany(p => p.AcademicBoardNavigations)
                .HasForeignKey(d => d.Board)
                .HasConstraintName("FK__Academic__Board__3493CFA7");

            entity.HasOne(d => d.EducationNavigation).WithMany(p => p.AcademicEducationNavigations)
                .HasForeignKey(d => d.Education)
                .HasConstraintName("FK__Academic__Educat__339FAB6E");

            entity.HasOne(d => d.Entity).WithMany(p => p.Academics)
                .HasForeignKey(d => d.EntityId)
                .HasConstraintName("FK__Academic__Entity__32AB8735");
        });

        modelBuilder.Entity<Achievement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Achievem__3214EC0790D63993");

            entity.ToTable("Achievement");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.AchievementType).WithMany(p => p.Achievements)
                .HasForeignKey(d => d.AchievementTypeId)
                .HasConstraintName("FK__Achieveme__Achie__2A164134");

            entity.HasOne(d => d.Entity).WithMany(p => p.Achievements)
                .HasForeignKey(d => d.EntityId)
                .HasConstraintName("FK__Achieveme__Entit__29221CFB");

            entity.HasOne(d => d.Program).WithMany(p => p.Achievements)
                .HasForeignKey(d => d.ProgramId)
                .HasConstraintName("FK__Achieveme__Progr__2BFE89A6");

            entity.HasOne(d => d.Session).WithMany(p => p.Achievements)
                .HasForeignKey(d => d.SessionId)
                .HasConstraintName("FK__Achieveme__Sessi__2B0A656D");
        });

        modelBuilder.Entity<AchievementVerify>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Achievem__3214EC07AF2D947F");

            entity.ToTable("AchievementVerify");

            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.Achievement).WithMany(p => p.AchievementVerifies)
                .HasForeignKey(d => d.AchievementId)
                .HasConstraintName("FK__Achieveme__Achie__2EDAF651");

            entity.HasOne(d => d.Verify).WithMany(p => p.AchievementVerifies)
                .HasForeignKey(d => d.VerifyId)
                .HasConstraintName("FK__Achieveme__Verif__2FCF1A8A");
        });

        modelBuilder.Entity<AddressProfile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AddressP__3214EC078784F33A");

            entity.ToTable("AddressProfile");

            entity.Property(e => e.Landmark)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Pincode)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Entity).WithMany(p => p.AddressProfiles)
                .HasForeignKey(d => d.EntityId)
                .HasConstraintName("FK__AddressPr__Entit__5FB337D6");

            entity.HasOne(d => d.Location).WithMany(p => p.AddressProfiles)
                .HasForeignKey(d => d.LocationId)
                .HasConstraintName("FK__AddressPr__Locat__619B8048");

            entity.HasOne(d => d.Type).WithMany(p => p.AddressProfiles)
                .HasForeignKey(d => d.TypeId)
                .HasConstraintName("FK__AddressPr__TypeI__60A75C0F");
        });

        modelBuilder.Entity<BasicProfile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BasicPro__3214EC077729608E");

            entity.ToTable("BasicProfile");

            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.Entity).WithMany(p => p.BasicProfiles)
                .HasForeignKey(d => d.EntityId)
                .HasConstraintName("FK__BasicProf__Entit__5812160E");
        });

        modelBuilder.Entity<ContactProfile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ContactP__3214EC077A4C5AF6");

            entity.ToTable("ContactProfile");

            entity.Property(e => e.EmailId)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Mobileno)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Whatsappno)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.Entity).WithMany(p => p.ContactProfiles)
                .HasForeignKey(d => d.EntityId)
                .HasConstraintName("FK__ContactPr__Entit__656C112C");

            entity.HasOne(d => d.Type).WithMany(p => p.ContactProfiles)
                .HasForeignKey(d => d.TypeId)
                .HasConstraintName("FK__ContactPr__TypeI__66603565");
        });

        modelBuilder.Entity<Designation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Designat__3214EC07B4E2E2E6");

            entity.ToTable("Designation");

            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Designation1).HasColumnName("Designation");
            entity.Property(e => e.IsDefault).HasDefaultValueSql("('1')");

            entity.HasOne(d => d.Designation1Navigation).WithMany(p => p.DesignationDesignation1Navigations)
                .HasForeignKey(d => d.Designation1)
                .HasConstraintName("FK__Designati__Desig__74AE54BC");

            entity.HasOne(d => d.Entity).WithMany(p => p.Designations)
                .HasForeignKey(d => d.EntityId)
                .HasConstraintName("FK__Designati__Entit__73BA3083");

            entity.HasOne(d => d.LevelNavigation).WithMany(p => p.DesignationLevelNavigations)
                .HasForeignKey(d => d.Level)
                .HasConstraintName("FK__Designati__Level__75A278F5");

            entity.HasOne(d => d.LocationNavigation).WithMany(p => p.DesignationLocationNavigations)
                .HasForeignKey(d => d.Location)
                .HasConstraintName("FK__Designati__Locat__76969D2E");
        });

        modelBuilder.Entity<DocumentProfile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Document__3214EC077D14C967");

            entity.ToTable("DocumentProfile");

            entity.Property(e => e.AltTag)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.DocumentNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("('1')")
                .HasColumnName("isActive");
            entity.Property(e => e.Path)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.DocExtension).WithMany(p => p.DocumentProfileDocExtensions)
                .HasForeignKey(d => d.DocExtensionId)
                .HasConstraintName("FK__DocumentP__DocEx__04E4BC85");

            entity.HasOne(d => d.DocType).WithMany(p => p.DocumentProfileDocTypes)
                .HasForeignKey(d => d.DocTypeId)
                .HasConstraintName("FK__DocumentP__DocTy__03F0984C");

            entity.HasOne(d => d.Entity).WithMany(p => p.DocumentProfiles)
                .HasForeignKey(d => d.EntityId)
                .HasConstraintName("FK__DocumentP__Entit__02FC7413");
        });

        modelBuilder.Entity<Entity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Entity__3214EC07BECA9DC4");

            entity.ToTable("Entity");

            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.IsActive).HasDefaultValueSql("('1')");
            entity.Property(e => e.IsDelete).HasDefaultValueSql("('0')");

            entity.HasOne(d => d.Session).WithMany(p => p.Entities)
                .HasForeignKey(d => d.SessionId)
                .HasConstraintName("FK__Entity__SessionI__4CA06362");
        });

        modelBuilder.Entity<FundTransaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FundTran__3214EC07FCEF07FA");

            entity.ToTable("FundTransaction");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.AmountInWord).IsUnicode(false);
            entity.Property(e => e.ChequeNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.FundExpiryDate).HasColumnType("datetime");
            entity.Property(e => e.FundType)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.PaymentType)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Bank).WithMany(p => p.FundTransactionBanks)
                .HasForeignKey(d => d.BankId)
                .HasConstraintName("FK__FundTrans__BankI__498EEC8D");

            entity.HasOne(d => d.StatusNavigation).WithMany(p => p.FundTransactionStatusNavigations)
                .HasForeignKey(d => d.Status)
                .HasConstraintName("FK__FundTrans__Statu__4A8310C6");
        });

        modelBuilder.Entity<FundVerify>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FundVeri__3214EC07E23AF9AA");

            entity.ToTable("FundVerify");

            entity.Property(e => e.VerifyDate).HasColumnType("datetime");

            entity.HasOne(d => d.Fund).WithMany(p => p.FundVerifies)
                .HasForeignKey(d => d.FundId)
                .HasConstraintName("FK__FundVerif__FundI__4D5F7D71");

            entity.HasOne(d => d.VerifyEntity).WithMany(p => p.FundVerifies)
                .HasForeignKey(d => d.VerifyEntityId)
                .HasConstraintName("FK__FundVerif__Verif__4E53A1AA");
        });

        modelBuilder.Entity<LinkProfile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LinkProf__3214EC0709C9C4FC");

            entity.ToTable("LinkProfile");

            entity.Property(e => e.Groupno)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.Coordinator).WithMany(p => p.LinkProfileCoordinators)
                .HasForeignKey(d => d.CoordinatorId)
                .HasConstraintName("FK__LinkProfi__Coord__5441852A");

            entity.HasOne(d => d.Entity).WithMany(p => p.LinkProfileEntities)
                .HasForeignKey(d => d.EntityId)
                .HasConstraintName("FK__LinkProfi__Entit__534D60F1");

            entity.HasOne(d => d.RelationNavigation).WithMany(p => p.LinkProfiles)
                .HasForeignKey(d => d.Relation)
                .HasConstraintName("FK__LinkProfi__Relat__5535A963");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Location__3214EC0736181460");

            entity.ToTable("Location");

            entity.Property(e => e.Code)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasDefaultValueSql("('1')");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.ParentId)
                .HasConstraintName("FK__Location__Parent__30F848ED");

            entity.HasOne(d => d.Type).WithMany(p => p.Locations)
                .HasForeignKey(d => d.TypeId)
                .HasConstraintName("FK__Location__TypeId__31EC6D26");
        });

        modelBuilder.Entity<Login>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Login__3214EC071855C0C0");

            entity.ToTable("Login");

            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValueSql("('1')");
            entity.Property(e => e.Password)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.Entity).WithMany(p => p.Logins)
                .HasForeignKey(d => d.EntityId)
                .HasConstraintName("FK__Login__EntityId__693CA210");

            entity.HasOne(d => d.Role).WithMany(p => p.Logins)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Login__RoleId__6A30C649");
        });

        modelBuilder.Entity<MasterType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MasterTy__3214EC07F64426D8");

            entity.ToTable("MasterType");

            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValueSql("('1')");
            entity.Property(e => e.IsDelete).HasDefaultValueSql("('0')");
            entity.Property(e => e.IsEdit).HasDefaultValueSql("('0')");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Srno).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.ParentId)
                .HasConstraintName("FK__MasterTyp__Paren__24927208");
        });

        modelBuilder.Entity<MasterTypeDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MasterTy__3214EC07D6ADB4E7");

            entity.ToTable("MasterTypeDetail");

            entity.Property(e => e.Code)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValueSql("('1')");
            entity.Property(e => e.IsDelete).HasDefaultValueSql("('0')");
            entity.Property(e => e.IsEdit).HasDefaultValueSql("('0')");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Srno).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.MasterType).WithMany(p => p.MasterTypeDetails)
                .HasForeignKey(d => d.MasterTypeId)
                .HasConstraintName("FK__MasterTyp__Maste__2B3F6F97");

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.ParentId)
                .HasConstraintName("FK__MasterTyp__Paren__2A4B4B5E");
        });

        modelBuilder.Entity<Membership>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Membersh__3214EC071CE9259B");

            entity.ToTable("Membership");

            entity.Property(e => e.DueDate).HasColumnType("datetime");
            entity.Property(e => e.PaidDate).HasColumnType("datetime");

            entity.HasOne(d => d.Entity).WithMany(p => p.Memberships)
                .HasForeignKey(d => d.EntityId)
                .HasConstraintName("FK__Membershi__Entit__7B5B524B");

            entity.HasOne(d => d.IsPa).WithMany(p => p.MembershipIsPas)
                .HasForeignKey(d => d.IsPaid)
                .HasConstraintName("FK__Membershi__IsPai__00200768");

            entity.HasOne(d => d.MembershipPlan).WithMany(p => p.Memberships)
                .HasForeignKey(d => d.MembershipPlanId)
                .HasConstraintName("FK__Membershi__Membe__7D439ABD");

            entity.HasOne(d => d.PaymentModeNavigation).WithMany(p => p.MembershipPaymentModeNavigations)
                .HasForeignKey(d => d.PaymentMode)
                .HasConstraintName("FK__Membershi__Payme__7E37BEF6");

            entity.HasOne(d => d.Reference).WithMany(p => p.InverseReference)
                .HasForeignKey(d => d.ReferenceId)
                .HasConstraintName("FK__Membershi__Refer__7C4F7684");

            entity.HasOne(d => d.Session).WithMany(p => p.Memberships)
                .HasForeignKey(d => d.SessionId)
                .HasConstraintName("FK__Membershi__Sessi__7F2BE32F");
        });

        modelBuilder.Entity<MembershipPlan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Membersh__3214EC07B90FE159");

            entity.ToTable("MembershipPlan");

            entity.Property(e => e.IsActive).HasDefaultValueSql("('1')");
            entity.Property(e => e.IsRenewal).HasDefaultValueSql("('1')");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PersonalProfile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Personal__3214EC07145E173F");

            entity.ToTable("PersonalProfile");

            entity.Property(e => e.Dob)
                .HasColumnType("datetime")
                .HasColumnName("DOB");
            entity.Property(e => e.FatherName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.MotherName)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.CastNavigation).WithMany(p => p.PersonalProfileCastNavigations)
                .HasForeignKey(d => d.Cast)
                .HasConstraintName("FK__PersonalPr__Cast__5CD6CB2B");

            entity.HasOne(d => d.Entity).WithMany(p => p.PersonalProfiles)
                .HasForeignKey(d => d.EntityId)
                .HasConstraintName("FK__PersonalP__Entit__5AEE82B9");

            entity.HasOne(d => d.GenderNavigation).WithMany(p => p.PersonalProfileGenderNavigations)
                .HasForeignKey(d => d.Gender)
                .HasConstraintName("FK__PersonalP__Gende__5BE2A6F2");
        });

        modelBuilder.Entity<PrizeMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PrizeMas__3214EC079F1E4C5E");

            entity.ToTable("PrizeMaster");

            entity.Property(e => e.IsActive).HasDefaultValueSql("('1')");

            entity.HasOne(d => d.AchievementType).WithMany(p => p.PrizeMasterAchievementTypes)
                .HasForeignKey(d => d.AchievementTypeId)
                .HasConstraintName("FK__PrizeMast__Achie__440B1D61");

            entity.HasOne(d => d.LevelNavigation).WithMany(p => p.PrizeMasterLevelNavigations)
                .HasForeignKey(d => d.Level)
                .HasConstraintName("FK__PrizeMast__Level__44FF419A");

            entity.HasOne(d => d.MedalTypeNavigation).WithMany(p => p.PrizeMasterMedalTypeNavigations)
                .HasForeignKey(d => d.MedalType)
                .HasConstraintName("FK__PrizeMast__Medal__45F365D3");

            entity.HasOne(d => d.Session).WithMany(p => p.PrizeMasters)
                .HasForeignKey(d => d.SessionId)
                .HasConstraintName("FK__PrizeMast__Sessi__46E78A0C");
        });

        modelBuilder.Entity<ProfessionProfile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Professi__3214EC076761F28F");

            entity.ToTable("ProfessionProfile");

            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValueSql("('1')");

            entity.HasOne(d => d.Achievement).WithMany(p => p.ProfessionProfiles)
                .HasForeignKey(d => d.AchievementId)
                .HasConstraintName("FK__Professio__Achie__46B27FE2");

            entity.HasOne(d => d.DepartmentNavigation).WithMany(p => p.ProfessionProfileDepartmentNavigations)
                .HasForeignKey(d => d.Department)
                .HasConstraintName("FK__Professio__Depar__44CA3770");

            entity.HasOne(d => d.DesignationNavigation).WithMany(p => p.ProfessionProfileDesignationNavigations)
                .HasForeignKey(d => d.Designation)
                .HasConstraintName("FK__Professio__Desig__43D61337");

            entity.HasOne(d => d.Entity).WithMany(p => p.ProfessionProfiles)
                .HasForeignKey(d => d.EntityId)
                .HasConstraintName("FK__Professio__Entit__40058253");

            entity.HasOne(d => d.JobTypeNavigation).WithMany(p => p.ProfessionProfileJobTypeNavigations)
                .HasForeignKey(d => d.JobType)
                .HasConstraintName("FK__Professio__JobTy__41EDCAC5");

            entity.HasOne(d => d.LocationNavigation).WithMany(p => p.ProfessionProfiles)
                .HasForeignKey(d => d.Location)
                .HasConstraintName("FK__Professio__Locat__42E1EEFE");

            entity.HasOne(d => d.Reference).WithMany(p => p.InverseReference)
                .HasForeignKey(d => d.ReferenceId)
                .HasConstraintName("FK__Professio__Refer__40F9A68C");
        });

        modelBuilder.Entity<Program>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Program__3214EC07BBA59C3E");

            entity.ToTable("Program");

            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValueSql("('1')");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.HasOne(d => d.Location).WithMany(p => p.Programs)
                .HasForeignKey(d => d.LocationId)
                .HasConstraintName("FK__Program__Locatio__3B75D760");

            entity.HasOne(d => d.Session).WithMany(p => p.Programs)
                .HasForeignKey(d => d.SessionId)
                .HasConstraintName("FK__Program__Session__3C69FB99");
        });

        modelBuilder.Entity<Session>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Session__3214EC079131969A");

            entity.ToTable("Session");

            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValueSql("('1')");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.HasOne(d => d.SessionType).WithMany(p => p.Sessions)
                .HasForeignKey(d => d.SessionTypeId)
                .HasConstraintName("FK__Session__Session__35BCFE0A");
        });

        modelBuilder.Entity<SocietyProfile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SocietyP__3214EC0772972234");

            entity.ToTable("SocietyProfile");

            entity.Property(e => e.IsActive).HasDefaultValueSql("('1')");

            entity.HasOne(d => d.Entity).WithMany(p => p.SocietyProfiles)
                .HasForeignKey(d => d.EntityId)
                .HasConstraintName("FK__SocietyPr__Entit__6E01572D");

            entity.HasOne(d => d.EntityType).WithMany(p => p.SocietyProfiles)
                .HasForeignKey(d => d.EntityTypeId)
                .HasConstraintName("FK__SocietyPr__Entit__6FE99F9F");

            entity.HasOne(d => d.Reference).WithMany(p => p.InverseReference)
                .HasForeignKey(d => d.ReferenceId)
                .HasConstraintName("FK__SocietyPr__Refer__6EF57B66");
        });

        modelBuilder.Entity<Sport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sports__3214EC0763C472C1");

            entity.Property(e => e.DocumentProof)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.Achievement).WithMany(p => p.Sports)
                .HasForeignKey(d => d.AchievementId)
                .HasConstraintName("FK__Sports__Achievem__3D2915A8");

            entity.HasOne(d => d.Entity).WithMany(p => p.Sports)
                .HasForeignKey(d => d.EntityId)
                .HasConstraintName("FK__Sports__EntityId__395884C4");

            entity.HasOne(d => d.GameNavigation).WithMany(p => p.SportGameNavigations)
                .HasForeignKey(d => d.Game)
                .HasConstraintName("FK__Sports__Game__3A4CA8FD");

            entity.HasOne(d => d.LevelNavigation).WithMany(p => p.SportLevelNavigations)
                .HasForeignKey(d => d.Level)
                .HasConstraintName("FK__Sports__Level__3C34F16F");

            entity.HasOne(d => d.MedalNavigation).WithMany(p => p.SportMedalNavigations)
                .HasForeignKey(d => d.Medal)
                .HasConstraintName("FK__Sports__Medal__3B40CD36");
        });

        modelBuilder.Entity<TransactionDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Transact__3214EC07CB62E7C7");

            entity.ToTable("TransactionDetail");

            entity.Property(e => e.TransactionType)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.Entity).WithMany(p => p.TransactionDetails)
                .HasForeignKey(d => d.EntityId)
                .HasConstraintName("FK__Transacti__Entit__51300E55");

            entity.HasOne(d => d.Fund).WithMany(p => p.TransactionDetails)
                .HasForeignKey(d => d.FundId)
                .HasConstraintName("FK__Transacti__FundI__5224328E");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
