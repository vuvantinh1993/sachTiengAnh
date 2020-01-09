using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CTIN.DataAccess.ModelsRender
{
    public partial class erpContext : DbContext
    {
        public erpContext()
        {
        }

        public erpContext(DbContextOptions<erpContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Acttachments> Acttachments { get; set; }
        public virtual DbSet<ActualCosts> ActualCosts { get; set; }
        public virtual DbSet<Aspiration> Aspiration { get; set; }
        public virtual DbSet<Bidding> Bidding { get; set; }
        public virtual DbSet<BiddingDocuments> BiddingDocuments { get; set; }
        public virtual DbSet<BiddingModel> BiddingModel { get; set; }
        public virtual DbSet<BizModel> BizModel { get; set; }
        public virtual DbSet<BloodGroup> BloodGroup { get; set; }
        public virtual DbSet<Branchs> Branchs { get; set; }
        public virtual DbSet<Certificate> Certificate { get; set; }
        public virtual DbSet<CertificateType> CertificateType { get; set; }
        public virtual DbSet<CollateCosts> CollateCosts { get; set; }
        public virtual DbSet<Commitment> Commitment { get; set; }
        public virtual DbSet<CompanyInfo> CompanyInfo { get; set; }
        public virtual DbSet<Configuration> Configuration { get; set; }
        public virtual DbSet<ContractClassify> ContractClassify { get; set; }
        public virtual DbSet<ContractForm> ContractForm { get; set; }
        public virtual DbSet<ContractType> ContractType { get; set; }
        public virtual DbSet<Contractor> Contractor { get; set; }
        public virtual DbSet<Contracts> Contracts { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Cr> Cr { get; set; }
        public virtual DbSet<Criteria> Criteria { get; set; }
        public virtual DbSet<Crtype> Crtype { get; set; }
        public virtual DbSet<Currency> Currency { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Device> Device { get; set; }
        public virtual DbSet<Discuss> Discuss { get; set; }
        public virtual DbSet<Division> Division { get; set; }
        public virtual DbSet<EducationLevel> EducationLevel { get; set; }
        public virtual DbSet<EmailTemplate> EmailTemplate { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Ethnic> Ethnic { get; set; }
        public virtual DbSet<EvaluationTemplate> EvaluationTemplate { get; set; }
        public virtual DbSet<ExpectedCosts> ExpectedCosts { get; set; }
        public virtual DbSet<ExpensesItem> ExpensesItem { get; set; }
        public virtual DbSet<ExpensesItemGroup> ExpensesItemGroup { get; set; }
        public virtual DbSet<Expert> Expert { get; set; }
        public virtual DbSet<FieldOfActivity> FieldOfActivity { get; set; }
        public virtual DbSet<Files> Files { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<General> General { get; set; }
        public virtual DbSet<HandoverSchedule> HandoverSchedule { get; set; }
        public virtual DbSet<Invests> Invests { get; set; }
        public virtual DbSet<Issue> Issue { get; set; }
        public virtual DbSet<IssueCauses> IssueCauses { get; set; }
        public virtual DbSet<IssueType> IssueType { get; set; }
        public virtual DbSet<JobPosition> JobPosition { get; set; }
        public virtual DbSet<Logworks> Logworks { get; set; }
        public virtual DbSet<Major> Major { get; set; }
        public virtual DbSet<ManagementForm> ManagementForm { get; set; }
        public virtual DbSet<Marital> Marital { get; set; }
        public virtual DbSet<Master> Master { get; set; }
        public virtual DbSet<ModeBidding> ModeBidding { get; set; }
        public virtual DbSet<Occupational> Occupational { get; set; }
        public virtual DbSet<OccupationalDisease> OccupationalDisease { get; set; }
        public virtual DbSet<OccupationalDiseaseGroup> OccupationalDiseaseGroup { get; set; }
        public virtual DbSet<Originated> Originated { get; set; }
        public virtual DbSet<PackageBids> PackageBids { get; set; }
        public virtual DbSet<Partner> Partner { get; set; }
        public virtual DbSet<PartnerGroup> PartnerGroup { get; set; }
        public virtual DbSet<PaymentSchedule> PaymentSchedule { get; set; }
        public virtual DbSet<PaymentType> PaymentType { get; set; }
        public virtual DbSet<Performance> Performance { get; set; }
        public virtual DbSet<Personality> Personality { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<PositionType> PositionType { get; set; }
        public virtual DbSet<ProductServices> ProductServices { get; set; }
        public virtual DbSet<Professor> Professor { get; set; }
        public virtual DbSet<ProjGeneral> ProjGeneral { get; set; }
        public virtual DbSet<ProjProfileDetail> ProjProfileDetail { get; set; }
        public virtual DbSet<ProjectGroup> ProjectGroup { get; set; }
        public virtual DbSet<ProjectProfile> ProjectProfile { get; set; }
        public virtual DbSet<ProjectResources> ProjectResources { get; set; }
        public virtual DbSet<ProjectType> ProjectType { get; set; }
        public virtual DbSet<Projworks> Projworks { get; set; }
        public virtual DbSet<RecruitmentApplicant> RecruitmentApplicant { get; set; }
        public virtual DbSet<RecruitmentPlan> RecruitmentPlan { get; set; }
        public virtual DbSet<RecruitmentRequest> RecruitmentRequest { get; set; }
        public virtual DbSet<RecyclebBin> RecyclebBin { get; set; }
        public virtual DbSet<Relationship> Relationship { get; set; }
        public virtual DbSet<Religion> Religion { get; set; }
        public virtual DbSet<Revenues> Revenues { get; set; }
        public virtual DbSet<RoleClaims> RoleClaims { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Skill> Skill { get; set; }
        public virtual DbSet<SkillGroup> SkillGroup { get; set; }
        public virtual DbSet<SkillLevel> SkillLevel { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<StorageCabinets> StorageCabinets { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<TableModel> TableModel { get; set; }
        public virtual DbSet<Target> Target { get; set; }
        public virtual DbSet<TargetDetail> TargetDetail { get; set; }
        public virtual DbSet<Template> Template { get; set; }
        public virtual DbSet<TermsOfPayment> TermsOfPayment { get; set; }
        public virtual DbSet<TermsPayDetail> TermsPayDetail { get; set; }
        public virtual DbSet<TimeSheet> TimeSheet { get; set; }
        public virtual DbSet<TimeSheetDetail> TimeSheetDetail { get; set; }
        public virtual DbSet<TrainingLecturers> TrainingLecturers { get; set; }
        public virtual DbSet<TrainningPartner> TrainningPartner { get; set; }
        public virtual DbSet<TrainningPlan> TrainningPlan { get; set; }
        public virtual DbSet<TrainningPlanEmployee> TrainningPlanEmployee { get; set; }
        public virtual DbSet<TrainningRequest> TrainningRequest { get; set; }
        public virtual DbSet<TypeOfBusiness> TypeOfBusiness { get; set; }
        public virtual DbSet<TypeOfEducation> TypeOfEducation { get; set; }
        public virtual DbSet<Unit> Unit { get; set; }
        public virtual DbSet<UnitType> UnitType { get; set; }
        public virtual DbSet<UserClaims> UserClaims { get; set; }
        public virtual DbSet<UserLogins> UserLogins { get; set; }
        public virtual DbSet<UserRoles> UserRoles { get; set; }
        public virtual DbSet<UserTokens> UserTokens { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<WorkEnvironment> WorkEnvironment { get; set; }
        public virtual DbSet<WorkType> WorkType { get; set; }
        public virtual DbSet<WorkmanshipLevel> WorkmanshipLevel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=10.0.101.53;Database=erp;user id=sa;password=ctin@123;Trusted_Connection=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity<Acttachments>(entity =>
            {
                entity.ToTable("Acttachments", "pm");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DataDb)
                    .IsRequired()
                    .HasColumnName("dataDb");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .HasComputedColumnSql("(CONVERT([nvarchar](250),json_value([FileData],'$.Description')))");

                entity.Property(e => e.FileData).IsRequired();

                entity.Property(e => e.FileName)
                    .HasMaxLength(50)
                    .HasComputedColumnSql("(CONVERT([nvarchar](50),json_value([FileData],'$.FileName')))");

                entity.Property(e => e.LinkIn)
                    .HasMaxLength(100)
                    .HasComputedColumnSql("(CONVERT([nvarchar](100),json_value([FileData],'$.LinkIn')))");

                entity.Property(e => e.LinkOut)
                    .HasMaxLength(100)
                    .HasComputedColumnSql("(CONVERT([nvarchar](100),json_value([FileData],'$.LinkOut')))");

                entity.Property(e => e.UploadDate)
                    .HasMaxLength(20)
                    .HasComputedColumnSql("(CONVERT([nvarchar](20),json_value([FileData],'$.UploadDate')))");

                entity.Property(e => e.Version)
                    .HasMaxLength(10)
                    .HasComputedColumnSql("(CONVERT([nvarchar](10),json_value([FileData],'$.Version')))");
            });

            modelBuilder.Entity<ActualCosts>(entity =>
            {
                entity.ToTable("ActualCosts", "pm");

                entity.HasIndex(e => e.VouchersNumber)
                    .HasName("UQ__ActualCo__A3FFF1EA8DEC8373")
                    .IsUnique();

                entity.Property(e => e.Accountant).HasComputedColumnSql("(CONVERT([int],json_value([data],'$.Accountant')))");

                entity.Property(e => e.AllowDisplay).HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.AllowDisplay')))");

                entity.Property(e => e.AmountOfMoney)
                    .HasColumnType("numeric(20, 3)")
                    .HasComputedColumnSql("(CONVERT([numeric](20,3),json_value([data],'$.AmountOfMoney')))");

                entity.Property(e => e.AmountReceived)
                    .HasColumnType("numeric(20, 3)")
                    .HasComputedColumnSql("(CONVERT([numeric](20,3),json_value([data],'$.AmountReceived')))");

                entity.Property(e => e.BidId).HasComputedColumnSql("(CONVERT([int],json_value([data],'$.BidId')))");

                entity.Property(e => e.ContractId).HasComputedColumnSql("(CONVERT([int],json_value([data],'$.ContractId')))");

                entity.Property(e => e.CoordinationList)
                    .HasMaxLength(200)
                    .HasComputedColumnSql("(CONVERT([nvarchar](200),json_value([data],'$.CoordinationList')))");

                entity.Property(e => e.CostName)
                    .HasMaxLength(500)
                    .HasComputedColumnSql("((CONVERT([nvarchar](500),json_value([data],'$.CostName'))) collate Vietnamese_CI_AI)");

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](50),json_value([dataDb],'$.CreateBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.CreatedDate')))");

                entity.Property(e => e.Currency)
                    .HasMaxLength(100)
                    .HasComputedColumnSql("(CONVERT([nvarchar](100),json_value([data],'$.Currency')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.DatePosted)
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([data],'$.DatePosted')))");

                entity.Property(e => e.EmpId).HasComputedColumnSql("(CONVERT([int],json_value([data],'$.EmpId')))");

                entity.Property(e => e.ExchangeRate)
                    .HasColumnType("numeric(20, 3)")
                    .HasComputedColumnSql("(CONVERT([numeric](20,3),json_value([data],'$.ExchangeRate')))");

                entity.Property(e => e.ExpItenId).HasComputedColumnSql("(CONVERT([int],json_value([data],'$.ExpItenId')))");

                entity.Property(e => e.FrameContract)
                    .HasMaxLength(200)
                    .HasComputedColumnSql("(CONVERT([nvarchar](200),json_value([data],'$.FrameContract')))");

                entity.Property(e => e.ImplementationSchedule)
                    .HasMaxLength(200)
                    .HasComputedColumnSql("(CONVERT([nvarchar](200),json_value([data],'$.ImplementationSchedule')))");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](50),json_value([dataDb],'$.ModifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.ModifiedDate')))");

                entity.Property(e => e.Note)
                    .HasMaxLength(500)
                    .HasComputedColumnSql("(CONVERT([nvarchar](500),json_value([data],'$.Note')))");

                entity.Property(e => e.PartId).HasComputedColumnSql("(CONVERT([int],json_value([data],'$.PartId')))");

                entity.Property(e => e.PaymentType)
                    .HasMaxLength(200)
                    .HasComputedColumnSql("(CONVERT([nvarchar](200),json_value([data],'$.PaymentType')))");

                entity.Property(e => e.Payments)
                    .HasColumnType("numeric(20, 3)")
                    .HasComputedColumnSql("(CONVERT([numeric](20,3),json_value([data],'$.Payments')))");

                entity.Property(e => e.ProjectId)
                    .HasMaxLength(20)
                    .HasComputedColumnSql("(CONVERT([nvarchar](20),json_value([data],'$.ProjectId')))");

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .HasComputedColumnSql("(CONVERT([nvarchar](100),json_value([data],'$.Status')))");

                entity.Property(e => e.Taxpay)
                    .HasColumnType("numeric(20, 3)")
                    .HasComputedColumnSql("(CONVERT([numeric](20,3),json_value([data],'$.Taxpay')))");

                entity.Property(e => e.VouchersDate)
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([data],'$.VouchersDate')))");

                entity.Property(e => e.VouchersNumber)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Aspiration>(entity =>
            {
                entity.ToTable("Aspiration", "cat");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay)
                    .HasColumnName("allowDisplay")
                    .HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.allowDisplay')))");

                entity.Property(e => e.AspirationCode)
                    .HasColumnName("aspirationCode")
                    .HasMaxLength(50)
                    .HasComputedColumnSql("(CONVERT([nvarchar](50),json_value([data],'$.aspirationCode')))");

                entity.Property(e => e.AspirationName)
                    .HasColumnName("aspirationName")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([data],'$.aspirationName')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deletedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.deletedBy')))");

                entity.Property(e => e.DeletedDate)
                    .HasColumnName("deletedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.deletedDate')))");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .HasComputedColumnSql("(CONVERT([nvarchar](500),json_value([data],'$.description')))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.OrderIndex)
                    .HasColumnName("orderIndex")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.orderIndex')))");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComputedColumnSql("(CONVERT([int],json_value([dataDb],'$.status')))");
            });

            modelBuilder.Entity<Bidding>(entity =>
            {
                entity.ToTable("Bidding", "dm");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay).HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.AllowDisplay')))");

                entity.Property(e => e.BiddingIndex).HasComputedColumnSql("(CONVERT([int],json_value([data],'$.BiddingIndex')))");

                entity.Property(e => e.BiddingName)
                    .HasMaxLength(250)
                    .HasComputedColumnSql("(CONVERT([nvarchar](250),json_value([data],'$.BiddingName')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.Note)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](500),json_value([data],'$.Note')))");
            });

            modelBuilder.Entity<BiddingDocuments>(entity =>
            {
                entity.ToTable("BiddingDocuments", "pm");

                entity.Property(e => e.AdjustmentDate).HasColumnType("datetime");

                entity.Property(e => e.AllowDisplay).HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateOfApproval).HasColumnType("datetime");

                entity.Property(e => e.DateOfBidSubmission).HasColumnType("datetime");

                entity.Property(e => e.DateOfVerification).HasColumnType("datetime");

                entity.Property(e => e.DatePassed).HasColumnType("datetime");

                entity.Property(e => e.DecisionNumber).HasMaxLength(200);

                entity.Property(e => e.Delete)
                    .HasColumnName("delete")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ListEmpId)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Note).HasMaxLength(500);

                entity.Property(e => e.ReleaseDate).HasColumnType("datetime");

                entity.Property(e => e.SignedOn).HasColumnType("datetime");

                entity.Property(e => e.SubmissionDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<BiddingModel>(entity =>
            {
                entity.ToTable("BiddingModel", "dm");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay).HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.AllowDisplay')))");

                entity.Property(e => e.BiddingModelIndex).HasComputedColumnSql("(CONVERT([int],json_value([data],'$.BiddingModelIndex')))");

                entity.Property(e => e.BiddingModelName)
                    .HasMaxLength(250)
                    .HasComputedColumnSql("(CONVERT([nvarchar](250),json_value([data],'$.BiddingModelName')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.Note)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](500),json_value([data],'$.Note')))");
            });

            modelBuilder.Entity<BizModel>(entity =>
            {
                entity.ToTable("BizModel", "dm");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BizModeCode)
                    .HasMaxLength(10)
                    .HasComputedColumnSql("(CONVERT([nvarchar](10),json_value([data],'$.BizModeCode')))");

                entity.Property(e => e.BizModeNameEn)
                    .HasColumnName("BizModeNameEN")
                    .HasMaxLength(250)
                    .HasComputedColumnSql("(CONVERT([nvarchar](250),json_value([data],'$.BizModeNameEN')))");

                entity.Property(e => e.BizModeNameVn)
                    .HasColumnName("BizModeNameVN")
                    .HasMaxLength(250)
                    .HasComputedColumnSql("(CONVERT([nvarchar](250),json_value([data],'$.BizModeNameVN')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.modifiedDate')))");
            });

            modelBuilder.Entity<BloodGroup>(entity =>
            {
                entity.ToTable("BloodGroup", "cat");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay)
                    .HasColumnName("allowDisplay")
                    .HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.allowDisplay')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deletedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.deletedBy')))");

                entity.Property(e => e.DeletedDate)
                    .HasColumnName("deletedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.deletedDate')))");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .HasComputedColumnSql("(CONVERT([nvarchar](500),json_value([data],'$.description')))");

                entity.Property(e => e.GroupCode)
                    .HasColumnName("groupCode")
                    .HasMaxLength(50)
                    .HasComputedColumnSql("(CONVERT([nvarchar](50),json_value([data],'$.groupCode')))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.OrderIndex)
                    .HasColumnName("orderIndex")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.orderIndex')))");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComputedColumnSql("(CONVERT([int],json_value([dataDb],'$.status')))");
            });

            modelBuilder.Entity<Branchs>(entity =>
            {
                entity.ToTable("Branchs", "aut");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("data_db");

                entity.Property(e => e.Files).HasColumnName("files");

                entity.Property(e => e.ModelId).HasColumnName("modelId");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.Branchs)
                    .HasForeignKey(d => d.ModelId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Branchs__modelId__78D3EB5B");
            });

            modelBuilder.Entity<Certificate>(entity =>
            {
                entity.ToTable("Certificate", "cat");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay)
                    .HasColumnName("allowDisplay")
                    .HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.allowDisplay')))");

                entity.Property(e => e.CertificateCode)
                    .HasColumnName("certificateCode")
                    .HasMaxLength(50)
                    .HasComputedColumnSql("(CONVERT([nvarchar](50),json_value([data],'$.certificateCode')))");

                entity.Property(e => e.CertificateName)
                    .HasColumnName("certificateName")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([data],'$.certificateName')))");

                entity.Property(e => e.CertificateTypeId)
                    .HasColumnName("certificateTypeId")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.certificateTypeId')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deletedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.deletedBy')))");

                entity.Property(e => e.DeletedDate)
                    .HasColumnName("deletedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.deletedDate')))");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .HasComputedColumnSql("(CONVERT([nvarchar](500),json_value([data],'$.description')))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.OrderIndex)
                    .HasColumnName("orderIndex")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.orderIndex')))");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComputedColumnSql("(CONVERT([int],json_value([dataDb],'$.status')))");

                entity.HasOne(d => d.CertificateType)
                    .WithMany(p => p.Certificate)
                    .HasForeignKey(d => d.CertificateTypeId)
                    .HasConstraintName("FK_Certificate_CertificateType");
            });

            modelBuilder.Entity<CertificateType>(entity =>
            {
                entity.ToTable("CertificateType", "cat");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay)
                    .HasColumnName("allowDisplay")
                    .HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.allowDisplay')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deletedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.deletedBy')))");

                entity.Property(e => e.DeletedDate)
                    .HasColumnName("deletedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.deletedDate')))");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .HasComputedColumnSql("(CONVERT([nvarchar](500),json_value([data],'$.description')))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.OrderIndex)
                    .HasColumnName("orderIndex")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.orderIndex')))");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComputedColumnSql("(CONVERT([int],json_value([dataDb],'$.status')))");

                entity.Property(e => e.TypeCode)
                    .HasColumnName("typeCode")
                    .HasMaxLength(50)
                    .HasComputedColumnSql("(CONVERT([nvarchar](50),json_value([data],'$.typeCode')))");

                entity.Property(e => e.TypeName)
                    .HasColumnName("typeName")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([data],'$.typeName')))");
            });

            modelBuilder.Entity<CollateCosts>(entity =>
            {
                entity.ToTable("CollateCosts", "pm");

                entity.HasIndex(e => e.VouchersNumber)
                    .HasName("UQ__CollateC__A3FFF1EAE4A7A3AA")
                    .IsUnique();

                entity.Property(e => e.Accountant).HasComputedColumnSql("(CONVERT([int],json_value([data],'$.Accountant')))");

                entity.Property(e => e.AccountantName)
                    .HasMaxLength(200)
                    .HasComputedColumnSql("(CONVERT([nvarchar](200),json_value([data],'$.AccountantName')))");

                entity.Property(e => e.AllowDisplay).HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.AllowDisplay')))");

                entity.Property(e => e.AmountOfMoney)
                    .HasColumnType("numeric(20, 3)")
                    .HasComputedColumnSql("(CONVERT([numeric](20,3),json_value([data],'$.AmountOfMoney')))");

                entity.Property(e => e.BidId).HasComputedColumnSql("(CONVERT([int],json_value([data],'$.BidId')))");

                entity.Property(e => e.Classification)
                    .HasMaxLength(100)
                    .HasComputedColumnSql("(CONVERT([nvarchar](100),json_value([data],'$.Classification')))");

                entity.Property(e => e.Content).HasComputedColumnSql("(CONVERT([nvarchar](max),json_value([data],'$.Content')))");

                entity.Property(e => e.ContractId).HasComputedColumnSql("(CONVERT([int],json_value([data],'$.ContractId')))");

                entity.Property(e => e.CoordinationList)
                    .HasMaxLength(200)
                    .HasComputedColumnSql("(CONVERT([nvarchar](200),json_value([data],'$.CoordinationList')))");

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](50),json_value([dataDb],'$.CreateBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.CreatedDate')))");

                entity.Property(e => e.Currency)
                    .HasMaxLength(100)
                    .HasComputedColumnSql("(CONVERT([nvarchar](100),json_value([data],'$.Currency')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.DatePosted)
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([data],'$.DatePosted')))");

                entity.Property(e => e.EmpId).HasComputedColumnSql("(CONVERT([int],json_value([data],'$.EmpId')))");

                entity.Property(e => e.ExchangeRate)
                    .HasColumnType("numeric(20, 3)")
                    .HasComputedColumnSql("(CONVERT([numeric](20,3),json_value([data],'$.ExchangeRate')))");

                entity.Property(e => e.ExpItenId).HasComputedColumnSql("(CONVERT([int],json_value([data],'$.ExpItenId')))");

                entity.Property(e => e.FrameContract)
                    .HasMaxLength(200)
                    .HasComputedColumnSql("(CONVERT([nvarchar](200),json_value([data],'$.FrameContract')))");

                entity.Property(e => e.ImplementationSchedule)
                    .HasMaxLength(200)
                    .HasComputedColumnSql("(CONVERT([nvarchar](200),json_value([data],'$.ImplementationSchedule')))");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](50),json_value([dataDb],'$.ModifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.ModifiedDate')))");

                entity.Property(e => e.Note)
                    .HasMaxLength(500)
                    .HasComputedColumnSql("(CONVERT([nvarchar](500),json_value([data],'$.Note')))");

                entity.Property(e => e.PartId).HasComputedColumnSql("(CONVERT([int],json_value([data],'$.PartId')))");

                entity.Property(e => e.PaymentType)
                    .HasMaxLength(200)
                    .HasComputedColumnSql("(CONVERT([nvarchar](200),json_value([data],'$.PaymentType')))");

                entity.Property(e => e.Payments)
                    .HasColumnType("numeric(20, 3)")
                    .HasComputedColumnSql("(CONVERT([numeric](20,3),json_value([data],'$.Payments')))");

                entity.Property(e => e.ProjectId)
                    .HasMaxLength(20)
                    .HasComputedColumnSql("(CONVERT([nvarchar](20),json_value([data],'$.ProjectId')))");

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .HasComputedColumnSql("(CONVERT([nvarchar](100),json_value([data],'$.Status')))");

                entity.Property(e => e.VouchersDate)
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([data],'$.VouchersDate')))");

                entity.Property(e => e.VouchersNumber)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Commitment>(entity =>
            {
                entity.ToTable("Commitment", "cat");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay)
                    .HasColumnName("allowDisplay")
                    .HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.allowDisplay')))");

                entity.Property(e => e.CommitCode)
                    .HasColumnName("commitCode")
                    .HasMaxLength(50)
                    .HasComputedColumnSql("(CONVERT([nvarchar](50),json_value([data],'$.commitCode')))");

                entity.Property(e => e.CommitName)
                    .HasColumnName("commitName")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([data],'$.commitName')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deletedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.deletedBy')))");

                entity.Property(e => e.DeletedDate)
                    .HasColumnName("deletedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.deletedDate')))");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .HasComputedColumnSql("(CONVERT([nvarchar](500),json_value([data],'$.description')))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.OrderIndex)
                    .HasColumnName("orderIndex")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.orderIndex')))");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComputedColumnSql("(CONVERT([int],json_value([dataDb],'$.status')))");
            });

            modelBuilder.Entity<CompanyInfo>(entity =>
            {
                entity.ToTable("CompanyInfo", "cat");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccountName)
                    .HasColumnName("accountName")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataBank],'$.accountName')))");

                entity.Property(e => e.AccountNo)
                    .HasColumnName("accountNo")
                    .HasMaxLength(50)
                    .HasComputedColumnSql("(CONVERT([nvarchar](50),json_value([dataBank],'$.accountNo')))");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(500)
                    .HasComputedColumnSql("(CONVERT([nvarchar](500),json_value([dataContact],'$.address')))");

                entity.Property(e => e.AffiliatedOrganization)
                    .HasColumnName("affiliatedOrganization")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([data],'$.affiliatedOrganization')))");

                entity.Property(e => e.AllowDisplay)
                    .HasColumnName("allowDisplay")
                    .HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.allowDisplay')))");

                entity.Property(e => e.BankAddress)
                    .HasColumnName("bankAddress")
                    .HasMaxLength(500)
                    .HasComputedColumnSql("(CONVERT([nvarchar](500),json_value([dataBank],'$.bankAddress')))");

                entity.Property(e => e.BankCode)
                    .HasColumnName("bankCode")
                    .HasMaxLength(50)
                    .HasComputedColumnSql("(CONVERT([nvarchar](50),json_value([dataBank],'$.bankCode')))");

                entity.Property(e => e.BankName)
                    .HasColumnName("bankName")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataBank],'$.bankName')))");

                entity.Property(e => e.Branch)
                    .HasColumnName("branch")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataBank],'$.branch')))");

                entity.Property(e => e.BusinessTypeId).HasColumnName("businessTypeId");

                entity.Property(e => e.CertificateDate)
                    .HasColumnName("certificateDate")
                    .HasColumnType("date")
                    .HasComputedColumnSql("(CONVERT([date],json_value([data],'$.certificateDate')))");

                entity.Property(e => e.CertificateNo)
                    .HasColumnName("certificateNo")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([data],'$.certificateNo')))");

                entity.Property(e => e.CertificatePlace)
                    .HasColumnName("certificatePlace")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([data],'$.certificatePlace')))");

                entity.Property(e => e.ChiefAccountant)
                    .HasColumnName("chiefAccountant")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([data],'$.chiefAccountant')))");

                entity.Property(e => e.CommuneId)
                    .HasColumnName("communeId")
                    .HasComputedColumnSql("(CONVERT([int],json_value([dataContact],'$.communeId')))");

                entity.Property(e => e.CompanyCode)
                    .IsRequired()
                    .HasColumnName("companyCode")
                    .HasMaxLength(50);

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasColumnName("companyName")
                    .HasMaxLength(500);

                entity.Property(e => e.CountryId)
                    .HasColumnName("countryId")
                    .HasComputedColumnSql("(CONVERT([int],json_value([dataContact],'$.countryId')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataBank).HasColumnName("dataBank");

                entity.Property(e => e.DataContact).HasColumnName("dataContact");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .HasComputedColumnSql("(CONVERT([nvarchar](500),json_value([data],'$.description')))");

                entity.Property(e => e.Director)
                    .HasColumnName("director")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([data],'$.director')))");

                entity.Property(e => e.DistrictId)
                    .HasColumnName("districtId")
                    .HasComputedColumnSql("(CONVERT([int],json_value([dataContact],'$.districtId')))");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataContact],'$.email')))");

                entity.Property(e => e.Fax)
                    .HasColumnName("fax")
                    .HasMaxLength(50)
                    .HasComputedColumnSql("(CONVERT([nvarchar](50),json_value([dataContact],'$.fax')))");

                entity.Property(e => e.OrderIndex)
                    .HasColumnName("orderIndex")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.orderIndex')))");

                entity.Property(e => e.ParentId).HasColumnName("parentId");

                entity.Property(e => e.PartyPresident)
                    .HasColumnName("partyPresident")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([data],'$.partyPresident')))");

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(50)
                    .HasComputedColumnSql("(CONVERT([nvarchar](50),json_value([dataContact],'$.phone')))");

                entity.Property(e => e.Position)
                    .HasColumnName("position")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([data],'$.position')))");

                entity.Property(e => e.President)
                    .HasColumnName("president")
                    .HasMaxLength(50)
                    .HasComputedColumnSql("(CONVERT([nvarchar](50),json_value([data],'$.president')))");

                entity.Property(e => e.ProvinceId)
                    .HasColumnName("provinceId")
                    .HasComputedColumnSql("(CONVERT([int],json_value([dataContact],'$.provinceId')))");

                entity.Property(e => e.Rank)
                    .HasColumnName("rank")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.rank')))");

                entity.Property(e => e.RegulationCapital)
                    .HasColumnName("regulationCapital")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.regulationCapital')))");

                entity.Property(e => e.Representative)
                    .HasColumnName("representative")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([data],'$.representative')))");

                entity.Property(e => e.ShortName)
                    .IsRequired()
                    .HasColumnName("shortName")
                    .HasMaxLength(500);

                entity.Property(e => e.StockPrice)
                    .HasColumnName("stockPrice")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.stockPrice')))");

                entity.Property(e => e.TaxCode)
                    .HasColumnName("taxCode")
                    .HasMaxLength(50)
                    .HasComputedColumnSql("(CONVERT([nvarchar](50),json_value([data],'$.taxCode')))");

                entity.Property(e => e.TradingName)
                    .IsRequired()
                    .HasColumnName("tradingName")
                    .HasMaxLength(500);

                entity.Property(e => e.TypeId).HasColumnName("typeId");

                entity.Property(e => e.UnionPresident)
                    .HasColumnName("unionPresident")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([data],'$.unionPresident')))");

                entity.Property(e => e.Website)
                    .HasColumnName("website")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataContact],'$.website')))");

                entity.Property(e => e.YouthUnionPresident)
                    .HasColumnName("youthUnionPresident")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([data],'$.youthUnionPresident')))");

                entity.HasOne(d => d.BusinessType)
                    .WithMany(p => p.CompanyInfo)
                    .HasForeignKey(d => d.BusinessTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CompanyIn__busin__76969D2E");
            });

            modelBuilder.Entity<Configuration>(entity =>
            {
                entity.ToTable("Configuration", "cat");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay)
                    .HasColumnName("allowDisplay")
                    .HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.allowDisplay')))");

                entity.Property(e => e.ConfigCode)
                    .HasColumnName("configCode")
                    .HasMaxLength(50)
                    .HasComputedColumnSql("(CONVERT([nvarchar](50),json_value([data],'$.configCode')))");

                entity.Property(e => e.ConfigName)
                    .HasColumnName("configName")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([data],'$.configName')))");

                entity.Property(e => e.ConfigValue)
                    .HasColumnName("configValue")
                    .HasMaxLength(500)
                    .HasComputedColumnSql("(CONVERT([nvarchar](500),json_value([data],'$.configValue')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deletedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.deletedBy')))");

                entity.Property(e => e.DeletedDate)
                    .HasColumnName("deletedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.deletedDate')))");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .HasComputedColumnSql("(CONVERT([nvarchar](500),json_value([data],'$.description')))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.OrderIndex)
                    .HasColumnName("orderIndex")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.orderIndex')))");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComputedColumnSql("(CONVERT([int],json_value([dataDb],'$.status')))");
            });

            modelBuilder.Entity<ContractClassify>(entity =>
            {
                entity.ToTable("ContractClassify", "hrm");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay)
                    .HasColumnName("allowDisplay")
                    .HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.allowDisplay')))");

                entity.Property(e => e.ClassifyName)
                    .HasColumnName("classifyName")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([data],'$.classifyName')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deletedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.deletedBy')))");

                entity.Property(e => e.DeletedDate)
                    .HasColumnName("deletedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.deletedDate')))");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .HasComputedColumnSql("(CONVERT([nvarchar](500),json_value([data],'$.description')))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.OrderIndex)
                    .HasColumnName("orderIndex")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.orderIndex')))");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComputedColumnSql("(CONVERT([int],json_value([dataDb],'$.status')))");
            });

            modelBuilder.Entity<ContractForm>(entity =>
            {
                entity.ToTable("ContractForm", "dm");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay).HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.AllowDisplay')))");

                entity.Property(e => e.ContractFormIndex).HasComputedColumnSql("(CONVERT([int],json_value([data],'$.ContractFormIndex')))");

                entity.Property(e => e.ContractFormName)
                    .HasMaxLength(250)
                    .HasComputedColumnSql("(CONVERT([nvarchar](250),json_value([data],'$.ContractFormName')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.Note)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](500),json_value([data],'$.Note')))");
            });

            modelBuilder.Entity<ContractType>(entity =>
            {
                entity.ToTable("ContractType", "hrm");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay)
                    .HasColumnName("allowDisplay")
                    .HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.allowDisplay')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deletedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.deletedBy')))");

                entity.Property(e => e.DeletedDate)
                    .HasColumnName("deletedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.deletedDate')))");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .HasComputedColumnSql("(CONVERT([nvarchar](500),json_value([data],'$.description')))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.MonthNumber)
                    .HasColumnName("monthNumber")
                    .HasColumnType("decimal(3, 2)")
                    .HasComputedColumnSql("(CONVERT([decimal](3,2),json_value([data],'$.monthNumber')))");

                entity.Property(e => e.OrderIndex)
                    .HasColumnName("orderIndex")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.orderIndex')))");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComputedColumnSql("(CONVERT([int],json_value([dataDb],'$.status')))");

                entity.Property(e => e.TypeName)
                    .HasColumnName("typeName")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([data],'$.typeName')))");
            });

            modelBuilder.Entity<Contractor>(entity =>
            {
                entity.ToTable("Contractor", "dm");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay).HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.AllowDisplay')))");

                entity.Property(e => e.ContractorIndex).HasComputedColumnSql("(CONVERT([int],json_value([data],'$.ContractorIndex')))");

                entity.Property(e => e.ContractorName)
                    .HasMaxLength(250)
                    .HasComputedColumnSql("(CONVERT([nvarchar](250),json_value([data],'$.ContractorName')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.Note)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](500),json_value([data],'$.Note')))");
            });

            modelBuilder.Entity<Contracts>(entity =>
            {
                entity.ToTable("Contracts", "pm");

                entity.Property(e => e.AllowDisplay).HasDefaultValueSql("((1))");

                entity.Property(e => e.AmountGuarOfWarranty)
                    .HasColumnType("numeric(20, 3)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AmountOfAdvGuar)
                    .HasColumnType("numeric(20, 3)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AmountOfMakeAdvGuar)
                    .HasColumnType("numeric(20, 3)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ContractClassification).HasMaxLength(250);

                entity.Property(e => e.ContractCode)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.ContractName).HasMaxLength(500);

                entity.Property(e => e.ContractValue)
                    .HasColumnType("numeric(20, 3)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Currency)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfAdvanceGuarantee).HasColumnType("datetime");

                entity.Property(e => e.DateOfMakeAdvGuar).HasColumnType("datetime");

                entity.Property(e => e.DateOfSignedDecision).HasColumnType("datetime");

                entity.Property(e => e.DecisionNumber).HasMaxLength(100);

                entity.Property(e => e.DeductibleValue)
                    .HasColumnType("numeric(20, 3)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Delete)
                    .HasColumnName("delete")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DurationOfContract).HasDefaultValueSql("((0))");

                entity.Property(e => e.EffectiveDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EndDateOfAdvGuar).HasColumnType("datetime");

                entity.Property(e => e.EndDateOfMakeAdvGuar).HasColumnType("datetime");

                entity.Property(e => e.ExchangeRate)
                    .HasColumnType("numeric(20, 3)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.Index).HasColumnName("index");

                entity.Property(e => e.LiquidationDay).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Note).HasMaxLength(500);

                entity.Property(e => e.PercentAdvanceGuarantee).HasDefaultValueSql("((0))");

                entity.Property(e => e.PercentGuarOfWarranty).HasDefaultValueSql("((0))");

                entity.Property(e => e.PercentOfMakeAdvGuar).HasDefaultValueSql("((0))");

                entity.Property(e => e.PersionInChange).HasMaxLength(500);

                entity.Property(e => e.SignedOn).HasColumnType("datetime");

                entity.Property(e => e.WarrantyEndDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country", "cat");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay)
                    .HasColumnName("allowDisplay")
                    .HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.allowDisplay')))");

                entity.Property(e => e.CountryCode)
                    .HasColumnName("countryCode")
                    .HasMaxLength(50)
                    .HasComputedColumnSql("(CONVERT([nvarchar](50),json_value([data],'$.countryCode')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deletedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.deletedBy')))");

                entity.Property(e => e.DeletedDate)
                    .HasColumnName("deletedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.deletedDate')))");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .HasComputedColumnSql("(CONVERT([nvarchar](500),json_value([data],'$.description')))");

                entity.Property(e => e.FullNameEn)
                    .HasColumnName("fullNameEN")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([data],'$.fullNameEN')))");

                entity.Property(e => e.FullNameVn)
                    .HasColumnName("fullNameVN")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([data],'$.fullNameVN')))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.OrderIndex)
                    .HasColumnName("orderIndex")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.orderIndex')))");

                entity.Property(e => e.ShortNameEn)
                    .HasColumnName("shortNameEN")
                    .HasMaxLength(128)
                    .HasComputedColumnSql("(CONVERT([nvarchar](128),json_value([data],'$.shortNameEN')))");

                entity.Property(e => e.ShortNameVn)
                    .HasColumnName("shortNameVN")
                    .HasMaxLength(128)
                    .HasComputedColumnSql("(CONVERT([nvarchar](128),json_value([data],'$.shortNameVN')))");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComputedColumnSql("(CONVERT([int],json_value([dataDb],'$.status')))");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course", "cat");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay)
                    .HasColumnName("allowDisplay")
                    .HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.allowDisplay')))");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasMaxLength(500)
                    .HasComputedColumnSql("(CONVERT([nvarchar](500),json_value([data],'$.content')))");

                entity.Property(e => e.CourseCode)
                    .HasColumnName("courseCode")
                    .HasMaxLength(50)
                    .HasComputedColumnSql("(CONVERT([nvarchar](50),json_value([data],'$.courseCode')))");

                entity.Property(e => e.CourseName)
                    .HasColumnName("courseName")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([data],'$.courseName')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deletedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.deletedBy')))");

                entity.Property(e => e.DeletedDate)
                    .HasColumnName("deletedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.deletedDate')))");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .HasComputedColumnSql("(CONVERT([nvarchar](500),json_value([data],'$.description')))");

                entity.Property(e => e.EduTypeId)
                    .HasColumnName("eduTypeId")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.eduTypeId')))");

                entity.Property(e => e.MajorId)
                    .HasColumnName("majorId")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.majorId')))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.OrderIndex)
                    .HasColumnName("orderIndex")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.orderIndex')))");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComputedColumnSql("(CONVERT([int],json_value([dataDb],'$.status')))");

                entity.HasOne(d => d.EduType)
                    .WithMany(p => p.Course)
                    .HasForeignKey(d => d.EduTypeId)
                    .HasConstraintName("FK__Course__eduTypeI__4964CF5B");

                entity.HasOne(d => d.Major)
                    .WithMany(p => p.Course)
                    .HasForeignKey(d => d.MajorId)
                    .HasConstraintName("FK__Course__majorId__4A58F394");
            });

            modelBuilder.Entity<Cr>(entity =>
            {
                entity.ToTable("CR", "pm");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Delete)
                    .HasColumnName("delete")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NewValue).HasMaxLength(500);

                entity.Property(e => e.Note).HasMaxLength(500);

                entity.Property(e => e.OldValue).HasMaxLength(500);
            });

            modelBuilder.Entity<Criteria>(entity =>
            {
                entity.ToTable("Criteria", "cat");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay)
                    .HasColumnName("allowDisplay")
                    .HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.allowDisplay')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deletedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.deletedBy')))");

                entity.Property(e => e.DeletedDate)
                    .HasColumnName("deletedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.deletedDate')))");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .HasComputedColumnSql("(CONVERT([nvarchar](500),json_value([data],'$.description')))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([data],'$.name')))");

                entity.Property(e => e.OrderIndex)
                    .HasColumnName("orderIndex")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.orderIndex')))");

                entity.Property(e => e.Point)
                    .HasColumnName("point")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.point')))");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComputedColumnSql("(CONVERT([int],json_value([dataDb],'$.status')))");
            });

            modelBuilder.Entity<Crtype>(entity =>
            {
                entity.ToTable("CRType", "dm");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay).HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.AllowDisplay')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Crname)
                    .HasColumnName("CRName")
                    .HasMaxLength(250)
                    .HasComputedColumnSql("(CONVERT([nvarchar](250),json_value([data],'$.CRName')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.Note)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](500),json_value([data],'$.Note')))");
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.HasKey(e => e.Iso)
                    .HasName("PK__Currency__DC5090748950CA34");

                entity.ToTable("Currency", "dm");

                entity.Property(e => e.Iso)
                    .HasColumnName("iso")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('VND')");

                entity.Property(e => e.CurrencyName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department", "cat");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(500)
                    .HasComputedColumnSql("(CONVERT([nvarchar](500),json_value([data],'$.address')))");

                entity.Property(e => e.AllowDisplay)
                    .HasColumnName("allowDisplay")
                    .HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.allowDisplay')))");

                entity.Property(e => e.CompanyId).HasColumnName("companyId");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.DataInfo).HasColumnName("dataInfo");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deletedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.deletedBy')))");

                entity.Property(e => e.DeletedDate)
                    .HasColumnName("deletedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.deletedDate')))");

                entity.Property(e => e.DepCode)
                    .IsRequired()
                    .HasColumnName("depCode")
                    .HasMaxLength(50);

                entity.Property(e => e.DepName)
                    .IsRequired()
                    .HasColumnName("depName")
                    .HasMaxLength(500);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .HasComputedColumnSql("(CONVERT([nvarchar](500),json_value([data],'$.description')))");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([data],'$.email')))");

                entity.Property(e => e.Fax)
                    .HasColumnName("fax")
                    .HasMaxLength(50)
                    .HasComputedColumnSql("(CONVERT([nvarchar](50),json_value([data],'$.fax')))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.OrderIndex)
                    .HasColumnName("orderIndex")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.orderIndex')))");

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(50)
                    .HasComputedColumnSql("(CONVERT([nvarchar](50),json_value([data],'$.phone')))");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComputedColumnSql("(CONVERT([int],json_value([dataDb],'$.status')))");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Department)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Departmen__compa__797309D9");
            });

            modelBuilder.Entity<Device>(entity =>
            {
                entity.ToTable("Device", "cat");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay)
                    .HasColumnName("allowDisplay")
                    .HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.allowDisplay')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deletedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.deletedBy')))");

                entity.Property(e => e.DeletedDate)
                    .HasColumnName("deletedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.deletedDate')))");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .HasComputedColumnSql("(CONVERT([nvarchar](500),json_value([data],'$.description')))");

                entity.Property(e => e.DeviceCode)
                    .HasColumnName("deviceCode")
                    .HasMaxLength(50)
                    .HasComputedColumnSql("(CONVERT([nvarchar](50),json_value([data],'$.deviceCode')))");

                entity.Property(e => e.DeviceName)
                    .HasColumnName("deviceName")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([data],'$.deviceName')))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.OrderIndex)
                    .HasColumnName("orderIndex")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.orderIndex')))");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComputedColumnSql("(CONVERT([int],json_value([dataDb],'$.status')))");
            });

            modelBuilder.Entity<Discuss>(entity =>
            {
                entity.ToTable("Discuss", "pm");

                entity.Property(e => e.AllowDisplay).HasDefaultValueSql("((1))");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PeopleInvolved)
                    .HasColumnName("peopleInvolved")
                    .HasMaxLength(250);

                entity.Property(e => e.Topic)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Division>(entity =>
            {
                entity.ToTable("Division", "cat");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(500)
                    .HasComputedColumnSql("(CONVERT([nvarchar](500),json_value([data],'$.address')))");

                entity.Property(e => e.AllowDisplay)
                    .HasColumnName("allowDisplay")
                    .HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.allowDisplay')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deletedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.deletedBy')))");

                entity.Property(e => e.DeletedDate)
                    .HasColumnName("deletedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.deletedDate')))");

                entity.Property(e => e.DepId).HasColumnName("depId");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .HasComputedColumnSql("(CONVERT([nvarchar](500),json_value([data],'$.description')))");

                entity.Property(e => e.DivCode)
                    .IsRequired()
                    .HasColumnName("divCode")
                    .HasMaxLength(50);

                entity.Property(e => e.DivName)
                    .IsRequired()
                    .HasColumnName("divName")
                    .HasMaxLength(500);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([data],'$.email')))");

                entity.Property(e => e.Fax)
                    .HasColumnName("fax")
                    .HasMaxLength(50)
                    .HasComputedColumnSql("(CONVERT([nvarchar](50),json_value([data],'$.fax')))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.OrderIndex)
                    .HasColumnName("orderIndex")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.orderIndex')))");

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(50)
                    .HasComputedColumnSql("(CONVERT([nvarchar](50),json_value([data],'$.phone')))");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComputedColumnSql("(CONVERT([int],json_value([dataDb],'$.status')))");

                entity.HasOne(d => d.Dep)
                    .WithMany(p => p.Division)
                    .HasForeignKey(d => d.DepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Division__depId__7C4F7684");
            });

            modelBuilder.Entity<EducationLevel>(entity =>
            {
                entity.ToTable("EducationLevel", "cat");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay)
                    .HasColumnName("allowDisplay")
                    .HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.allowDisplay')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deletedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.deletedBy')))");

                entity.Property(e => e.DeletedDate)
                    .HasColumnName("deletedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.deletedDate')))");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .HasComputedColumnSql("(CONVERT([nvarchar](500),json_value([data],'$.description')))");

                entity.Property(e => e.LevelCode)
                    .HasColumnName("levelCode")
                    .HasMaxLength(50)
                    .HasComputedColumnSql("(CONVERT([nvarchar](50),json_value([data],'$.levelCode')))");

                entity.Property(e => e.LevelName)
                    .HasColumnName("levelName")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([data],'$.levelName')))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.OrderIndex)
                    .HasColumnName("orderIndex")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.orderIndex')))");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComputedColumnSql("(CONVERT([int],json_value([dataDb],'$.status')))");
            });

            modelBuilder.Entity<EmailTemplate>(entity =>
            {
                entity.ToTable("EmailTemplate", "cat");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay)
                    .HasColumnName("allowDisplay")
                    .HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.allowDisplay')))");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasMaxLength(3000)
                    .HasComputedColumnSql("(CONVERT([nvarchar](3000),json_value([data],'$.content')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deletedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.deletedBy')))");

                entity.Property(e => e.DeletedDate)
                    .HasColumnName("deletedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.deletedDate')))");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .HasComputedColumnSql("(CONVERT([nvarchar](500),json_value([data],'$.description')))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.OrderIndex)
                    .HasColumnName("orderIndex")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.orderIndex')))");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComputedColumnSql("(CONVERT([int],json_value([dataDb],'$.status')))");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([data],'$.title')))");
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.ToTable("Employees", "hrm");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Accuracy).HasColumnName("accuracy");

                entity.Property(e => e.Army).HasColumnName("army");

                entity.Property(e => e.Basic).HasColumnName("basic");

                entity.Property(e => e.CapacityProfile).HasColumnName("capacityProfile");

                entity.Property(e => e.Contact).HasColumnName("contact");

                entity.Property(e => e.Contracts).HasColumnName("contracts");

                entity.Property(e => e.CurentJob).HasColumnName("curentJob");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.DecisionHistory).HasColumnName("decisionHistory");

                entity.Property(e => e.Federation).HasColumnName("federation");

                entity.Property(e => e.Files).HasColumnName("files");

                entity.Property(e => e.Finance).HasColumnName("finance");

                entity.Property(e => e.Health).HasColumnName("health");

                entity.Property(e => e.Jobs).HasColumnName("jobs");

                entity.Property(e => e.PartyDelegation).HasColumnName("partyDelegation");

                entity.Property(e => e.Relationships).HasColumnName("relationships");

                entity.Property(e => e.RevolutionaryHistory).HasColumnName("revolutionaryHistory");

                entity.Property(e => e.Story).HasColumnName("story");
            });

            modelBuilder.Entity<Ethnic>(entity =>
            {
                entity.ToTable("Ethnic", "cat");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay)
                    .HasColumnName("allowDisplay")
                    .HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.allowDisplay')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deletedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.deletedBy')))");

                entity.Property(e => e.DeletedDate)
                    .HasColumnName("deletedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.deletedDate')))");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .HasComputedColumnSql("(CONVERT([nvarchar](500),json_value([data],'$.description')))");

                entity.Property(e => e.EthnicCode)
                    .HasColumnName("ethnicCode")
                    .HasMaxLength(50)
                    .HasComputedColumnSql("(CONVERT([nvarchar](50),json_value([data],'$.ethnicCode')))");

                entity.Property(e => e.EthnicName)
                    .HasColumnName("ethnicName")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([data],'$.ethnicName')))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.OrderIndex)
                    .HasColumnName("orderIndex")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.orderIndex')))");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComputedColumnSql("(CONVERT([int],json_value([dataDb],'$.status')))");
            });

            modelBuilder.Entity<EvaluationTemplate>(entity =>
            {
                entity.ToTable("EvaluationTemplate", "cat");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay)
                    .HasColumnName("allowDisplay")
                    .HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.allowDisplay')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Criteria)
                    .HasColumnName("criteria")
                    .HasMaxLength(500)
                    .HasComputedColumnSql("(CONVERT([nvarchar](500),json_value([data],'$.criteria')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deletedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.deletedBy')))");

                entity.Property(e => e.DeletedDate)
                    .HasColumnName("deletedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.deletedDate')))");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .HasComputedColumnSql("(CONVERT([nvarchar](500),json_value([data],'$.description')))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.OrderIndex)
                    .HasColumnName("orderIndex")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.orderIndex')))");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComputedColumnSql("(CONVERT([int],json_value([dataDb],'$.status')))");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([data],'$.title')))");
            });

            modelBuilder.Entity<ExpectedCosts>(entity =>
            {
                entity.ToTable("ExpectedCosts", "pm");

                entity.Property(e => e.AllowDisplay).HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.AllowDisplay')))");

                entity.Property(e => e.AmountOfMoney)
                    .HasColumnType("numeric(20, 3)")
                    .HasComputedColumnSql("(CONVERT([numeric](20,3),json_value([data],'$.AmountOfMoney')))");

                entity.Property(e => e.CostName)
                    .HasMaxLength(500)
                    .HasComputedColumnSql("(CONVERT([nvarchar](500),json_value([data],'$.CostName')))");

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](50),json_value([dataDb],'$.CreateBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.CreatedDate')))");

                entity.Property(e => e.Currency)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](10),json_value([data],'$.Currency')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.DateFounded)
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([data],'$.DateFounded')))");

                entity.Property(e => e.EmpId).HasComputedColumnSql("(CONVERT([int],json_value([data],'$.EmpId')))");

                entity.Property(e => e.ExchangeRate)
                    .HasColumnType("numeric(20, 3)")
                    .HasComputedColumnSql("(CONVERT([numeric](20,3),json_value([data],'$.ExchangeRate')))");

                entity.Property(e => e.ExpItemGroupId).HasComputedColumnSql("(CONVERT([int],json_value([data],'$.ExpItemGroupId')))");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](50),json_value([dataDb],'$.ModifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.ModifiedDate')))");

                entity.Property(e => e.Note)
                    .HasMaxLength(500)
                    .HasComputedColumnSql("(CONVERT([nvarchar](500),json_value([data],'$.Note')))");

                entity.Property(e => e.Percentage).HasComputedColumnSql("(CONVERT([int],json_value([data],'$.Percentage')))");

                entity.Property(e => e.ProjectId).HasComputedColumnSql("(CONVERT([int],json_value([data],'$.ProjectId')))");

                entity.Property(e => e.StatusPjojId).HasComputedColumnSql("(CONVERT([int],json_value([data],'$.StatusPjojId')))");
            });

            modelBuilder.Entity<ExpensesItem>(entity =>
            {
                entity.ToTable("ExpensesItem", "dm");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay).HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.AllowDisplay')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.ExpItemGrpId).HasComputedColumnSql("(CONVERT([int],json_value([data],'$.ExpItemGrpId')))");

                entity.Property(e => e.ExpensesItemIndex).HasComputedColumnSql("(CONVERT([int],json_value([data],'$.ExpensesItemIndex')))");

                entity.Property(e => e.ExpensesItemName)
                    .HasMaxLength(250)
                    .HasComputedColumnSql("(CONVERT([nvarchar](250),json_value([data],'$.ExpensesItemName')))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.Note)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](500),json_value([data],'$.Note')))");
            });

            modelBuilder.Entity<ExpensesItemGroup>(entity =>
            {
                entity.ToTable("ExpensesItemGroup", "dm");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay).HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.AllowDisplay')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.ExpensesItemGroupIndex).HasComputedColumnSql("(CONVERT([int],json_value([data],'$.ExpensesItemGroupIndex')))");

                entity.Property(e => e.ExpensesItemGroupName)
                    .HasMaxLength(250)
                    .HasComputedColumnSql("(CONVERT([nvarchar](250),json_value([data],'$.ExpensesItemGroupName')))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.Note)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](500),json_value([data],'$.Note')))");
            });

            modelBuilder.Entity<Expert>(entity =>
            {
                entity.ToTable("Expert", "cat");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay)
                    .HasColumnName("allowDisplay")
                    .HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.allowDisplay')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deletedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.deletedBy')))");

                entity.Property(e => e.DeletedDate)
                    .HasColumnName("deletedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.deletedDate')))");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .HasComputedColumnSql("(CONVERT([nvarchar](500),json_value([data],'$.description')))");

                entity.Property(e => e.ExpertCode)
                    .HasColumnName("expertCode")
                    .HasMaxLength(50)
                    .HasComputedColumnSql("(CONVERT([nvarchar](50),json_value([data],'$.expertCode')))");

                entity.Property(e => e.ExpertName)
                    .HasColumnName("expertName")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([data],'$.expertName')))");

                entity.Property(e => e.MajorId)
                    .HasColumnName("majorId")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.majorId')))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.OrderIndex)
                    .HasColumnName("orderIndex")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.orderIndex')))");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComputedColumnSql("(CONVERT([int],json_value([dataDb],'$.status')))");

                entity.HasOne(d => d.Major)
                    .WithMany(p => p.Expert)
                    .HasForeignKey(d => d.MajorId)
                    .HasConstraintName("FK__Expert__majorId__4C413C06");
            });

            modelBuilder.Entity<FieldOfActivity>(entity =>
            {
                entity.ToTable("FieldOfActivity", "dm");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ActivityIndex).HasComputedColumnSql("(CONVERT([int],json_value([data],'$.ActivityIndex')))");

                entity.Property(e => e.AllowDisplay).HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.AllowDisplay')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.FieldOfActivityName)
                    .HasMaxLength(250)
                    .HasComputedColumnSql("(CONVERT([nvarchar](250),json_value([data],'$.FieldOfActivityName')))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.Note)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](500),json_value([data],'$.Note')))");
            });

            modelBuilder.Entity<Files>(entity =>
            {
                entity.ToTable("Files", "stm");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.Source).HasColumnName("source");
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.ToTable("Gender", "cat");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay)
                    .HasColumnName("allowDisplay")
                    .HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.allowDisplay')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deletedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.deletedBy')))");

                entity.Property(e => e.DeletedDate)
                    .HasColumnName("deletedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.deletedDate')))");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .HasComputedColumnSql("(CONVERT([nvarchar](500),json_value([data],'$.description')))");

                entity.Property(e => e.GenderCode)
                    .HasColumnName("genderCode")
                    .HasMaxLength(50)
                    .HasComputedColumnSql("(CONVERT([nvarchar](50),json_value([data],'$.genderCode')))");

                entity.Property(e => e.GenderName)
                    .HasColumnName("genderName")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([data],'$.genderName')))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.OrderIndex)
                    .HasColumnName("orderIndex")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.orderIndex')))");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComputedColumnSql("(CONVERT([int],json_value([dataDb],'$.status')))");
            });

            modelBuilder.Entity<General>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("data_db");

                entity.Property(e => e.Files).HasColumnName("files");

                entity.Property(e => e.ModelId).HasColumnName("modelId");
            });

            modelBuilder.Entity<HandoverSchedule>(entity =>
            {
                entity.ToTable("HandoverSchedule", "pm");

                entity.Property(e => e.AcceptanceValue)
                    .HasColumnType("numeric(20, 3)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AllowDisplay).HasDefaultValueSql("((1))");

                entity.Property(e => e.BillDate).HasColumnType("datetime");

                entity.Property(e => e.BillNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Content).HasMaxLength(500);

                entity.Property(e => e.ContractCodeBase).HasMaxLength(200);

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Delete)
                    .HasColumnName("delete")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EstimatedDate).HasColumnType("datetime");

                entity.Property(e => e.EstimatedValue)
                    .HasColumnType("numeric(20, 3)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.HandoverClassification)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('T?m tính')");

                entity.Property(e => e.Mass).HasDefaultValueSql("((0))");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Note).HasMaxLength(500);

                entity.Property(e => e.PercentMass).HasDefaultValueSql("((0))");

                entity.Property(e => e.Process).HasMaxLength(200);

                entity.Property(e => e.ProductName).HasMaxLength(500);

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Invests>(entity =>
            {
                entity.ToTable("Invests", "dm");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay).HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.AllowDisplay')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.InvestIndex).HasComputedColumnSql("(CONVERT([int],json_value([data],'$.InvestIndex')))");

                entity.Property(e => e.InvestName)
                    .HasMaxLength(250)
                    .HasComputedColumnSql("(CONVERT([nvarchar](250),json_value([data],'$.InvestName')))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.Note)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](500),json_value([data],'$.Note')))");
            });

            modelBuilder.Entity<Issue>(entity =>
            {
                entity.ToTable("Issue", "pm");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BeginDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CompletedDate).HasColumnType("datetime");

                entity.Property(e => e.ContactList).HasMaxLength(500);

                entity.Property(e => e.CoordinationList).HasMaxLength(500);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Delete)
                    .HasColumnName("delete")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Flag).HasColumnName("flag");

                entity.Property(e => e.IssueName).HasMaxLength(250);

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Note).HasMaxLength(500);

                entity.Property(e => e.PercentCompleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.Solusion).HasMaxLength(500);
            });

            modelBuilder.Entity<IssueCauses>(entity =>
            {
                entity.ToTable("IssueCauses", "dm");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay).HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.AllowDisplay')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.IssueCausesIndex).HasComputedColumnSql("(CONVERT([int],json_value([data],'$.IssueCausesIndex')))");

                entity.Property(e => e.IssueCausesName)
                    .HasMaxLength(250)
                    .HasComputedColumnSql("(CONVERT([nvarchar](250),json_value([data],'$.IssueCausesName')))");

                entity.Property(e => e.IssueId).HasComputedColumnSql("(CONVERT([int],json_value([data],'$.IssueId')))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.Note)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](500),json_value([data],'$.Note')))");
            });

            modelBuilder.Entity<IssueType>(entity =>
            {
                entity.ToTable("IssueType", "dm");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay).HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.AllowDisplay')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.IssueTypeIndex).HasComputedColumnSql("(CONVERT([int],json_value([data],'$.IssueTypeIndex')))");

                entity.Property(e => e.IssueTypeName)
                    .HasMaxLength(250)
                    .HasComputedColumnSql("(CONVERT([nvarchar](250),json_value([data],'$.IssueTypeName')))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.Note)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](500),json_value([data],'$.Note')))");
            });

            modelBuilder.Entity<JobPosition>(entity =>
            {
                entity.ToTable("JobPosition", "cat");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay)
                    .HasColumnName("allowDisplay")
                    .HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.allowDisplay')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deletedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.deletedBy')))");

                entity.Property(e => e.DeletedDate)
                    .HasColumnName("deletedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.deletedDate')))");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .HasComputedColumnSql("(CONVERT([nvarchar](500),json_value([data],'$.description')))");

                entity.Property(e => e.JobCode)
                    .HasColumnName("jobCode")
                    .HasMaxLength(50)
                    .HasComputedColumnSql("(CONVERT([nvarchar](50),json_value([data],'$.jobCode')))");

                entity.Property(e => e.JobName)
                    .HasColumnName("jobName")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([data],'$.jobName')))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.OrderIndex)
                    .HasColumnName("orderIndex")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.orderIndex')))");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComputedColumnSql("(CONVERT([int],json_value([dataDb],'$.status')))");
            });

            modelBuilder.Entity<Logworks>(entity =>
            {
                entity.ToTable("Logworks", "pm");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content).HasMaxLength(500);

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CurrentDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Major>(entity =>
            {
                entity.ToTable("Major", "cat");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay)
                    .HasColumnName("allowDisplay")
                    .HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.allowDisplay')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deletedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.deletedBy')))");

                entity.Property(e => e.DeletedDate)
                    .HasColumnName("deletedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.deletedDate')))");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .HasComputedColumnSql("(CONVERT([nvarchar](500),json_value([data],'$.description')))");

                entity.Property(e => e.MajorCode)
                    .HasColumnName("majorCode")
                    .HasMaxLength(50)
                    .HasComputedColumnSql("(CONVERT([nvarchar](50),json_value([data],'$.majorCode')))");

                entity.Property(e => e.MajorName)
                    .HasColumnName("majorName")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([data],'$.majorName')))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.OrderIndex)
                    .HasColumnName("orderIndex")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.orderIndex')))");

                entity.Property(e => e.ParentId)
                    .HasColumnName("parentId")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.parentId')))");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComputedColumnSql("(CONVERT([int],json_value([dataDb],'$.status')))");
            });

            modelBuilder.Entity<ManagementForm>(entity =>
            {
                entity.ToTable("ManagementForm", "dm");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay).HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.AllowDisplay')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.MntFormIndex).HasComputedColumnSql("(CONVERT([int],json_value([data],'$.MntFormIndex')))");

                entity.Property(e => e.MntFormName)
                    .HasMaxLength(250)
                    .HasComputedColumnSql("(CONVERT([nvarchar](250),json_value([data],'$.MntFormName')))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.Note)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](500),json_value([data],'$.Note')))");
            });

            modelBuilder.Entity<Marital>(entity =>
            {
                entity.ToTable("Marital", "cat");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay)
                    .HasColumnName("allowDisplay")
                    .HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.allowDisplay')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deletedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.deletedBy')))");

                entity.Property(e => e.DeletedDate)
                    .HasColumnName("deletedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.deletedDate')))");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .HasComputedColumnSql("(CONVERT([nvarchar](500),json_value([data],'$.description')))");

                entity.Property(e => e.MaritalCode)
                    .HasColumnName("maritalCode")
                    .HasMaxLength(50)
                    .HasComputedColumnSql("(CONVERT([nvarchar](50),json_value([data],'$.maritalCode')))");

                entity.Property(e => e.MaritalName)
                    .HasColumnName("maritalName")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([data],'$.maritalName')))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.OrderIndex)
                    .HasColumnName("orderIndex")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.orderIndex')))");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComputedColumnSql("(CONVERT([int],json_value([dataDb],'$.status')))");
            });

            modelBuilder.Entity<Master>(entity =>
            {
                entity.ToTable("Master", "cat");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay)
                    .HasColumnName("allowDisplay")
                    .HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.allowDisplay')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deletedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.deletedBy')))");

                entity.Property(e => e.DeletedDate)
                    .HasColumnName("deletedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.deletedDate')))");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .HasComputedColumnSql("(CONVERT([nvarchar](500),json_value([data],'$.description')))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.OrderIndex)
                    .HasColumnName("orderIndex")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.orderIndex')))");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComputedColumnSql("(CONVERT([int],json_value([dataDb],'$.status')))");

                entity.Property(e => e.TitleCode)
                    .HasColumnName("titleCode")
                    .HasMaxLength(50)
                    .HasComputedColumnSql("(CONVERT([nvarchar](50),json_value([data],'$.titleCode')))");

                entity.Property(e => e.TitleName)
                    .HasColumnName("titleName")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([data],'$.titleName')))");
            });

            modelBuilder.Entity<ModeBidding>(entity =>
            {
                entity.ToTable("ModeBidding", "dm");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Createby)
                    .IsRequired()
                    .HasColumnName("CREATEBY")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Createdate)
                    .HasColumnName("CREATEDATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Display)
                    .HasColumnName("DISPLAY")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Modebiddingindex)
                    .HasColumnName("MODEBIDDINGINDEX")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Modebiddingname)
                    .HasColumnName("MODEBIDDINGNAME")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Modifyby)
                    .IsRequired()
                    .HasColumnName("MODIFYBY")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Modifydate)
                    .HasColumnName("MODIFYDATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Note)
                    .HasColumnName("NOTE")
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Occupational>(entity =>
            {
                entity.ToTable("Occupational", "cat");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay)
                    .HasColumnName("allowDisplay")
                    .HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.allowDisplay')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deletedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.deletedBy')))");

                entity.Property(e => e.DeletedDate)
                    .HasColumnName("deletedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.deletedDate')))");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .HasComputedColumnSql("(CONVERT([nvarchar](500),json_value([data],'$.description')))");

                entity.Property(e => e.MajorId)
                    .HasColumnName("majorId")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.majorId')))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.OccupationalCode)
                    .HasColumnName("occupationalCode")
                    .HasMaxLength(50)
                    .HasComputedColumnSql("(CONVERT([nvarchar](50),json_value([data],'$.occupationalCode')))");

                entity.Property(e => e.OccupationalName)
                    .HasColumnName("occupationalName")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([data],'$.occupationalName')))");

                entity.Property(e => e.OrderIndex)
                    .HasColumnName("orderIndex")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.orderIndex')))");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComputedColumnSql("(CONVERT([int],json_value([dataDb],'$.status')))");

                entity.HasOne(d => d.Major)
                    .WithMany(p => p.Occupational)
                    .HasForeignKey(d => d.MajorId)
                    .HasConstraintName("FK__Occupatio__major__2BD46C74");
            });

            modelBuilder.Entity<OccupationalDisease>(entity =>
            {
                entity.ToTable("OccupationalDisease", "cat");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay)
                    .HasColumnName("allowDisplay")
                    .HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.allowDisplay')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deletedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.deletedBy')))");

                entity.Property(e => e.DeletedDate)
                    .HasColumnName("deletedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.deletedDate')))");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .HasComputedColumnSql("(CONVERT([nvarchar](500),json_value([data],'$.description')))");

                entity.Property(e => e.DiseaseCode)
                    .HasColumnName("diseaseCode")
                    .HasMaxLength(50)
                    .HasComputedColumnSql("(CONVERT([nvarchar](50),json_value([data],'$.diseaseCode')))");

                entity.Property(e => e.DiseaseGroupId)
                    .HasColumnName("diseaseGroupId")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.diseaseGroupId')))");

                entity.Property(e => e.DiseaseName)
                    .HasColumnName("diseaseName")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([data],'$.diseaseName')))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.OrderIndex)
                    .HasColumnName("orderIndex")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.orderIndex')))");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComputedColumnSql("(CONVERT([int],json_value([dataDb],'$.status')))");

                entity.HasOne(d => d.DiseaseGroup)
                    .WithMany(p => p.OccupationalDisease)
                    .HasForeignKey(d => d.DiseaseGroupId)
                    .HasConstraintName("FK__Occupatio__disea__2803DB90");
            });

            modelBuilder.Entity<OccupationalDiseaseGroup>(entity =>
            {
                entity.ToTable("OccupationalDiseaseGroup", "cat");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay)
                    .HasColumnName("allowDisplay")
                    .HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.allowDisplay')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deletedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.deletedBy')))");

                entity.Property(e => e.DeletedDate)
                    .HasColumnName("deletedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.deletedDate')))");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .HasComputedColumnSql("(CONVERT([nvarchar](500),json_value([data],'$.description')))");

                entity.Property(e => e.DisGroupCode)
                    .HasColumnName("disGroupCode")
                    .HasMaxLength(50)
                    .HasComputedColumnSql("(CONVERT([nvarchar](50),json_value([data],'$.disGroupCode')))");

                entity.Property(e => e.DisGroupName)
                    .HasColumnName("disGroupName")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([data],'$.disGroupName')))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.OrderIndex)
                    .HasColumnName("orderIndex")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.orderIndex')))");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComputedColumnSql("(CONVERT([int],json_value([dataDb],'$.status')))");
            });

            modelBuilder.Entity<Originated>(entity =>
            {
                entity.ToTable("Originated", "cat");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay)
                    .HasColumnName("allowDisplay")
                    .HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.allowDisplay')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deletedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.deletedBy')))");

                entity.Property(e => e.DeletedDate)
                    .HasColumnName("deletedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.deletedDate')))");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .HasComputedColumnSql("(CONVERT([nvarchar](500),json_value([data],'$.description')))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.OrderIndex)
                    .HasColumnName("orderIndex")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.orderIndex')))");

                entity.Property(e => e.OriginateCode)
                    .HasColumnName("originateCode")
                    .HasMaxLength(50)
                    .HasComputedColumnSql("(CONVERT([nvarchar](50),json_value([data],'$.originateCode')))");

                entity.Property(e => e.OriginateName)
                    .HasColumnName("originateName")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([data],'$.originateName')))");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComputedColumnSql("(CONVERT([int],json_value([dataDb],'$.status')))");
            });

            modelBuilder.Entity<PackageBids>(entity =>
            {
                entity.ToTable("PackageBids", "pm");

                entity.Property(e => e.AllowDisplay).HasDefaultValueSql("((1))");

                entity.Property(e => e.BestBid).HasColumnType("numeric(20, 3)");

                entity.Property(e => e.BidPrice).HasColumnType("numeric(20, 3)");

                entity.Property(e => e.ContractPrice).HasColumnType("numeric(20, 3)");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Currency)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Delete)
                    .HasColumnName("delete")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.EstimatedPrice).HasColumnType("numeric(20, 3)");

                entity.Property(e => e.ExchangeRate).HasColumnType("numeric(20, 3)");

                entity.Property(e => e.LastDay)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ListEmpId)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PackageBidName).HasMaxLength(500);

                entity.Property(e => e.ProjId).HasColumnName("ProjID");

                entity.Property(e => e.StartDay)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Partner>(entity =>
            {
                entity.ToTable("Partner", "dm");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](500),json_value([data],'$.Address')))");

                entity.Property(e => e.AllowDisplay).HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.AllowDisplay')))");

                entity.Property(e => e.Contact)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](500),json_value([data],'$.Contact')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.Email)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](150),json_value([data],'$.Email')))");

                entity.Property(e => e.Fax)
                    .HasMaxLength(30)
                    .HasComputedColumnSql("(CONVERT([nvarchar](30),json_value([data],'$.Fax')))");

                entity.Property(e => e.IdCountry).HasComputedColumnSql("(CONVERT([int],json_value([data],'$.IdCountry')))");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(30)
                    .HasComputedColumnSql("(CONVERT([nvarchar](30),json_value([data],'$.Mobile')))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.Note)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](500),json_value([data],'$.Note')))");

                entity.Property(e => e.PartCode)
                    .HasMaxLength(30)
                    .HasComputedColumnSql("(CONVERT([nvarchar](30),json_value([data],'$.PartCode')))");

                entity.Property(e => e.PartGroupId).HasComputedColumnSql("(CONVERT([int],json_value([data],'$.PartGroupId')))");

                entity.Property(e => e.PartnerNameEn)
                    .HasColumnName("PartnerNameEN")
                    .HasMaxLength(250)
                    .HasComputedColumnSql("(CONVERT([nvarchar](250),json_value([data],'$.PartnerNameEN')))");

                entity.Property(e => e.PartnerNameVn)
                    .HasColumnName("PartnerNameVN")
                    .HasMaxLength(250)
                    .HasComputedColumnSql("(CONVERT([nvarchar](250),json_value([data],'$.PartnerNameVN')))");

                entity.Property(e => e.TaxCode)
                    .HasMaxLength(30)
                    .HasComputedColumnSql("(CONVERT([nvarchar](30),json_value([data],'$.TaxCode')))");

                entity.Property(e => e.Tel)
                    .HasMaxLength(30)
                    .HasComputedColumnSql("(CONVERT([nvarchar](30),json_value([data],'$.Tel')))");

                entity.Property(e => e.Website)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](150),json_value([data],'$.Website')))");

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(30)
                    .HasComputedColumnSql("(CONVERT([nvarchar](30),json_value([data],'$.ZipCode')))");
            });

            modelBuilder.Entity<PartnerGroup>(entity =>
            {
                entity.ToTable("PartnerGroup", "dm");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay).HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.AllowDisplay')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.Note)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](500),json_value([data],'$.Note')))");

                entity.Property(e => e.PartnerGroupCode)
                    .HasMaxLength(10)
                    .HasComputedColumnSql("(CONVERT([nvarchar](10),json_value([data],'$.PartnerGroupCode')))");

                entity.Property(e => e.PartnerGroupNameEn)
                    .HasColumnName("PartnerGroupNameEN")
                    .HasMaxLength(250)
                    .HasComputedColumnSql("(CONVERT([nvarchar](250),json_value([data],'$.PartnerGroupNameEN')))");

                entity.Property(e => e.PartnerGroupNameVn)
                    .HasColumnName("PartnerGroupNameVN")
                    .HasMaxLength(250)
                    .HasComputedColumnSql("(CONVERT([nvarchar](250),json_value([data],'$.PartnerGroupNameVN')))");
            });

            modelBuilder.Entity<PaymentSchedule>(entity =>
            {
                entity.ToTable("PaymentSchedule", "pm");

                entity.Property(e => e.AllowDisplay).HasDefaultValueSql("((1))");

                entity.Property(e => e.AmountOfMoney)
                    .HasColumnType("numeric(20, 3)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AppointmentDate).HasColumnType("datetime");

                entity.Property(e => e.BonusRatio).HasDefaultValueSql("((0))");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Delete)
                    .HasColumnName("delete")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Note).IsUnicode(false);

                entity.Property(e => e.NumberOfBonusDays).HasDefaultValueSql("((0))");

                entity.Property(e => e.NumberOfDay).HasDefaultValueSql("((0))");

                entity.Property(e => e.NumberOfPenaltyDays).HasDefaultValueSql("((0))");

                entity.Property(e => e.PenaltyDate).HasColumnType("datetime");

                entity.Property(e => e.PenaltyRate).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProductCode).HasColumnName("productCode");

                entity.Property(e => e.RewardDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<PaymentType>(entity =>
            {
                entity.ToTable("PaymentType", "dm");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.Note)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](500),json_value([data],'$.Note')))");

                entity.Property(e => e.PaymentTypeName)
                    .HasMaxLength(250)
                    .HasComputedColumnSql("(CONVERT([nvarchar](250),json_value([data],'$.PaymentTypeName')))");
            });

            modelBuilder.Entity<Performance>(entity =>
            {
                entity.ToTable("Performance", "cat");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay)
                    .HasColumnName("allowDisplay")
                    .HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.allowDisplay')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deletedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.deletedBy')))");

                entity.Property(e => e.DeletedDate)
                    .HasColumnName("deletedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.deletedDate')))");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .HasComputedColumnSql("(CONVERT([nvarchar](500),json_value([data],'$.description')))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.OrderIndex)
                    .HasColumnName("orderIndex")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.orderIndex')))");

                entity.Property(e => e.PerformanceCode)
                    .HasColumnName("performanceCode")
                    .HasMaxLength(50)
                    .HasComputedColumnSql("(CONVERT([nvarchar](50),json_value([data],'$.performanceCode')))");

                entity.Property(e => e.PerformanceName)
                    .HasColumnName("performanceName")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([data],'$.performanceName')))");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComputedColumnSql("(CONVERT([int],json_value([dataDb],'$.status')))");
            });

            modelBuilder.Entity<Personality>(entity =>
            {
                entity.ToTable("Personality", "cat");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay)
                    .HasColumnName("allowDisplay")
                    .HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.allowDisplay')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deletedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.deletedBy')))");

                entity.Property(e => e.DeletedDate)
                    .HasColumnName("deletedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.deletedDate')))");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .HasComputedColumnSql("(CONVERT([nvarchar](500),json_value([data],'$.description')))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.OrderIndex)
                    .HasColumnName("orderIndex")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.orderIndex')))");

                entity.Property(e => e.PersionalityCode)
                    .HasColumnName("persionalityCode")
                    .HasMaxLength(50)
                    .HasComputedColumnSql("(CONVERT([nvarchar](50),json_value([data],'$.persionalityCode')))");

                entity.Property(e => e.PersionalityName)
                    .HasColumnName("persionalityName")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([data],'$.persionalityName')))");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComputedColumnSql("(CONVERT([int],json_value([dataDb],'$.status')))");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.ToTable("Position", "cat");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay)
                    .HasColumnName("allowDisplay")
                    .HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.allowDisplay')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deletedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.deletedBy')))");

                entity.Property(e => e.DeletedDate)
                    .HasColumnName("deletedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.deletedDate')))");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .HasComputedColumnSql("(CONVERT([nvarchar](500),json_value([data],'$.description')))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.OrderIndex)
                    .HasColumnName("orderIndex")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.orderIndex')))");

                entity.Property(e => e.PositionCode)
                    .HasColumnName("positionCode")
                    .HasMaxLength(50)
                    .HasComputedColumnSql("(CONVERT([nvarchar](50),json_value([data],'$.positionCode')))");

                entity.Property(e => e.PositionName)
                    .HasColumnName("positionName")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([data],'$.positionName')))");

                entity.Property(e => e.PositionTypeId)
                    .HasColumnName("positionTypeId")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.positionTypeId')))");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComputedColumnSql("(CONVERT([int],json_value([dataDb],'$.status')))");

                entity.Property(e => e.WorkId)
                    .HasColumnName("workId")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.workId')))");

                entity.HasOne(d => d.PositionType)
                    .WithMany(p => p.Position)
                    .HasForeignKey(d => d.PositionTypeId)
                    .HasConstraintName("FK__Position__positi__42B7D1CC");
            });

            modelBuilder.Entity<PositionType>(entity =>
            {
                entity.ToTable("PositionType", "cat");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay)
                    .HasColumnName("allowDisplay")
                    .HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.allowDisplay')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deletedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.deletedBy')))");

                entity.Property(e => e.DeletedDate)
                    .HasColumnName("deletedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.deletedDate')))");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .HasComputedColumnSql("(CONVERT([nvarchar](500),json_value([data],'$.description')))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.OrderIndex)
                    .HasColumnName("orderIndex")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.orderIndex')))");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComputedColumnSql("(CONVERT([int],json_value([dataDb],'$.status')))");

                entity.Property(e => e.TypeCode)
                    .HasColumnName("typeCode")
                    .HasMaxLength(50)
                    .HasComputedColumnSql("(CONVERT([nvarchar](50),json_value([data],'$.typeCode')))");

                entity.Property(e => e.TypeName)
                    .HasColumnName("typeName")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([data],'$.typeName')))");
            });

            modelBuilder.Entity<ProductServices>(entity =>
            {
                entity.ToTable("ProductServices", "dm");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.ProdServ).HasComputedColumnSql("(CONVERT([int],json_value([data],'$.ProdServ')))");

                entity.Property(e => e.ProdServCode)
                    .HasMaxLength(10)
                    .HasComputedColumnSql("(CONVERT([nvarchar](10),json_value([data],'$.ProdServCode')))");

                entity.Property(e => e.ProdServNameEn)
                    .HasColumnName("ProdServNameEN")
                    .HasMaxLength(250)
                    .HasComputedColumnSql("(CONVERT([nvarchar](250),json_value([data],'$.ProdServNameEN')))");

                entity.Property(e => e.ProdServNameVn)
                    .HasColumnName("ProdServNameVN")
                    .HasMaxLength(250)
                    .HasComputedColumnSql("(CONVERT([nvarchar](250),json_value([data],'$.ProdServNameVN')))");
            });

            modelBuilder.Entity<Professor>(entity =>
            {
                entity.ToTable("Professor", "cat");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay)
                    .HasColumnName("allowDisplay")
                    .HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.allowDisplay')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deletedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.deletedBy')))");

                entity.Property(e => e.DeletedDate)
                    .HasColumnName("deletedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.deletedDate')))");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .HasComputedColumnSql("(CONVERT([nvarchar](500),json_value([data],'$.description')))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.OrderIndex)
                    .HasColumnName("orderIndex")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.orderIndex')))");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComputedColumnSql("(CONVERT([int],json_value([dataDb],'$.status')))");

                entity.Property(e => e.TitleCode)
                    .HasColumnName("titleCode")
                    .HasMaxLength(50)
                    .HasComputedColumnSql("(CONVERT([nvarchar](50),json_value([data],'$.titleCode')))");

                entity.Property(e => e.TitleName)
                    .HasColumnName("titleName")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([data],'$.titleName')))");
            });

            modelBuilder.Entity<ProjGeneral>(entity =>
            {
                entity.ToTable("ProjGeneral", "pm");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowEmail).HasDefaultValueSql("((1))");

                entity.Property(e => e.BeginDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.BudgetRemaining)
                    .HasColumnType("numeric(20, 3)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CompletedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CoordinatorDep).HasMaxLength(250);

                entity.Property(e => e.CostBooks)
                    .HasColumnType("numeric(20, 3)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Crbudget)
                    .HasColumnName("CRBudget")
                    .HasColumnType("numeric(20, 3)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Currency)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('VND')");

                entity.Property(e => e.CustomerGroupId).HasColumnName("customerGroupId");

                entity.Property(e => e.CustomerId).HasColumnName("customerId");

                entity.Property(e => e.Delete)
                    .HasColumnName("delete")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EstimatedBudget)
                    .HasColumnType("numeric(20, 3)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ExchangeRate)
                    .HasColumnType("numeric(20, 3)")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FeasibilityCrbudget)
                    .HasColumnName("FeasibilityCRBudget")
                    .HasColumnType("numeric(20, 3)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FeasibilityStadyBudget)
                    .HasColumnType("numeric(20, 3)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LearderName).HasMaxLength(200);

                entity.Property(e => e.Memory).HasMaxLength(500);

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PartGroupId).HasDefaultValueSql("((0))");

                entity.Property(e => e.PlanBudget)
                    .HasColumnType("numeric(20, 3)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ProjCode)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ProjName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.ProjPercent).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProjPriority).HasMaxLength(80);

                entity.Property(e => e.ProjectMembers).HasMaxLength(250);

                entity.Property(e => e.ProposedBudget)
                    .HasColumnType("numeric(20, 3)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SalesPlan)
                    .HasColumnType("numeric(20, 3)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalContractAmount)
                    .HasColumnType("numeric(20, 3)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalContractExpenses)
                    .HasColumnType("numeric(20, 3)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalContractPayment)
                    .HasColumnType("numeric(20, 3)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalContractRemaining)
                    .HasColumnType("numeric(20, 3)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalCostContract)
                    .HasColumnType("numeric(20, 3)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalOperatingExpenses)
                    .HasColumnType("numeric(20, 3)")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<ProjProfileDetail>(entity =>
            {
                entity.ToTable("ProjProfileDetail", "dm");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay).HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.AllowDisplay')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.Note)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](500),json_value([data],'$.Note')))");

                entity.Property(e => e.ProfDetailName)
                    .HasMaxLength(250)
                    .HasComputedColumnSql("(CONVERT([nvarchar](250),json_value([data],'$.ProfDetailName')))");

                entity.Property(e => e.ProfileDtlIndex).HasComputedColumnSql("(CONVERT([int],json_value([data],'$.ProfileDtlIndex')))");

                entity.Property(e => e.ProjProfileId).HasComputedColumnSql("(CONVERT([int],json_value([data],'$.ProjProfileId')))");

                entity.Property(e => e.StatusId).HasComputedColumnSql("(CONVERT([int],json_value([data],'$.StatusId')))");
            });

            modelBuilder.Entity<ProjectGroup>(entity =>
            {
                entity.ToTable("ProjectGroup", "dm");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay).HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.AllowDisplay')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.Note)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](500),json_value([data],'$.Note')))");

                entity.Property(e => e.ProjGroupNameEn)
                    .HasColumnName("ProjGroupNameEN")
                    .HasMaxLength(250)
                    .HasComputedColumnSql("(CONVERT([nvarchar](250),json_value([data],'$.ProjGroupNameEN')))");

                entity.Property(e => e.ProjGroupNameVn)
                    .HasColumnName("ProjGroupNameVN")
                    .HasMaxLength(250)
                    .HasComputedColumnSql("(CONVERT([nvarchar](250),json_value([data],'$.ProjGroupNameVN')))");

                entity.Property(e => e.ProjGrpCode).HasComputedColumnSql("(CONVERT([int],json_value([data],'$.ProjGrpCode')))");

                entity.Property(e => e.ProjIndex).HasComputedColumnSql("(CONVERT([int],json_value([data],'$.ProjIndex')))");
            });

            modelBuilder.Entity<ProjectProfile>(entity =>
            {
                entity.ToTable("ProjectProfile", "dm");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay).HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.AllowDisplay')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.Note)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](500),json_value([data],'$.Note')))");

                entity.Property(e => e.ProfileCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](50),json_value([data],'$.ProfileCode')))");

                entity.Property(e => e.ProfileNameEn)
                    .HasColumnName("ProfileNameEN")
                    .HasMaxLength(250)
                    .HasComputedColumnSql("(CONVERT([nvarchar](250),json_value([data],'$.ProFileNameEN')))");

                entity.Property(e => e.ProfileNameVn)
                    .HasColumnName("ProfileNameVN")
                    .HasMaxLength(250)
                    .HasComputedColumnSql("(CONVERT([nvarchar](250),json_value([data],'$.ProFileNameVN')))");
            });

            modelBuilder.Entity<ProjectResources>(entity =>
            {
                entity.ToTable("ProjectResources", "pm");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BeginDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasColumnName("createdBy")
                    .HasMaxLength(256);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Delete)
                    .HasColumnName("delete")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PercentResource).HasDefaultValueSql("((0))");

                entity.Property(e => e.RelatedList)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProjectType>(entity =>
            {
                entity.ToTable("ProjectType", "dm");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay).HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.AllowDisplay')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.Note)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](500),json_value([data],'$.Note')))");

                entity.Property(e => e.ProjTypeNameEn)
                    .HasColumnName("ProjTypeNameEN")
                    .HasMaxLength(250)
                    .HasComputedColumnSql("(CONVERT([nvarchar](250),json_value([data],'$.ProjTypeNameEN')))");

                entity.Property(e => e.ProjTypeNameVn)
                    .HasColumnName("ProjTypeNameVN")
                    .HasMaxLength(250)
                    .HasComputedColumnSql("(CONVERT([nvarchar](250),json_value([data],'$.ProjTypeNameVN')))");
            });

            modelBuilder.Entity<Projworks>(entity =>
            {
                entity.ToTable("Projworks", "pm");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BeginDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CompleteDate)
                    .HasColumnName("completeDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Contact)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Content).HasMaxLength(500);

                entity.Property(e => e.CoordinationList)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Delete)
                    .HasColumnName("delete")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Note).HasMaxLength(500);

                entity.Property(e => e.PerrentId).HasDefaultValueSql("((0))");

                entity.Property(e => e.TimePlan).HasDefaultValueSql("((1))");

                entity.Property(e => e.TimeReality).HasDefaultValueSql("((1))");

                entity.Property(e => e.WorkCompleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.WorkName)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<RecruitmentApplicant>(entity =>
            {
                entity.ToTable("RecruitmentApplicant", "hrm");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Accuracy).HasColumnName("accuracy");

                entity.Property(e => e.Basic).HasColumnName("basic");

                entity.Property(e => e.CapacityProfile).HasColumnName("capacityProfile");

                entity.Property(e => e.Contact).HasColumnName("contact");

                entity.Property(e => e.CurrentTurnId)
                    .HasColumnName("currentTurnId")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.Extend).HasColumnName("extend");

                entity.Property(e => e.Files).HasColumnName("files");

                entity.Property(e => e.Finance).HasColumnName("finance");

                entity.Property(e => e.Health).HasColumnName("health");

                entity.Property(e => e.Relationships).HasColumnName("relationships");

                entity.Property(e => e.Story).HasColumnName("story");

                entity.Property(e => e.TurnHistory).HasColumnName("turnHistory");
            });

            modelBuilder.Entity<RecruitmentPlan>(entity =>
            {
                entity.ToTable("RecruitmentPlan", "hrm");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Channel).HasColumnName("channel");

                entity.Property(e => e.CostIncurred).HasColumnName("costIncurred");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.DataExtend).HasColumnName("dataExtend");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deletedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.deletedBy')))");

                entity.Property(e => e.DeletedDate)
                    .HasColumnName("deletedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.deletedDate')))");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.FileAttach).HasColumnName("fileAttach");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.Note).HasColumnName("note");

                entity.Property(e => e.Phase).HasColumnName("phase");

                entity.Property(e => e.PlanCode)
                    .IsRequired()
                    .HasColumnName("planCode")
                    .HasMaxLength(50);

                entity.Property(e => e.PlanName)
                    .HasColumnName("planName")
                    .HasMaxLength(256);

                entity.Property(e => e.PlanStatus).HasColumnName("planStatus");

                entity.Property(e => e.Reason).HasColumnName("reason");

                entity.Property(e => e.Request)
                    .IsRequired()
                    .HasColumnName("request");

                entity.Property(e => e.Require).HasColumnName("require");

                entity.Property(e => e.SignApproved).HasColumnName("signApproved");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComputedColumnSql("(CONVERT([int],json_value([dataDb],'$.status')))");
            });

            modelBuilder.Entity<RecruitmentRequest>(entity =>
            {
                entity.ToTable("RecruitmentRequest", "hrm");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.DataExtend).HasColumnName("dataExtend");

                entity.Property(e => e.Department).HasColumnName("department");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.ExpectedDate)
                    .HasColumnName("expectedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ExpectedDateTo)
                    .HasColumnName("expectedDateTo")
                    .HasColumnType("datetime");

                entity.Property(e => e.ExpectedSalary)
                    .HasColumnName("expectedSalary")
                    .HasColumnType("money");

                entity.Property(e => e.ExpectedSalaryUpTo)
                    .HasColumnName("expectedSalaryUpTo")
                    .HasColumnType("money");

                entity.Property(e => e.JobPosition).HasColumnName("jobPosition");

                entity.Property(e => e.Note).HasColumnName("note");

                entity.Property(e => e.Reason).HasColumnName("reason");

                entity.Property(e => e.RequestCode)
                    .IsRequired()
                    .HasColumnName("requestCode")
                    .HasMaxLength(50);

                entity.Property(e => e.RequestName)
                    .HasColumnName("requestName")
                    .HasMaxLength(256);

                entity.Property(e => e.RequestStatus).HasColumnName("requestStatus");

                entity.Property(e => e.RequestType).HasColumnName("requestType");

                entity.Property(e => e.Require).HasColumnName("require");

                entity.Property(e => e.SignApproved).HasColumnName("signApproved");

                entity.Property(e => e.Template).HasColumnName("template");
            });

            modelBuilder.Entity<RecyclebBin>(entity =>
            {
                entity.ToTable("RecyclebBin", "dm");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.DmlDdlType)
                    .HasMaxLength(250)
                    .HasComputedColumnSql("(CONVERT([nvarchar](250),json_value([data],'$.DmlDdlType')))");

                entity.Property(e => e.Note)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](500),json_value([data],'$.Note')))");

                entity.Property(e => e.TableName)
                    .HasMaxLength(250)
                    .HasComputedColumnSql("(CONVERT([nvarchar](250),json_value([data],'$.TableName')))");

                entity.Property(e => e.ValData).HasComputedColumnSql("(CONVERT([nvarchar](max),json_value([data],'$.ValData')))");
            });

            modelBuilder.Entity<Relationship>(entity =>
            {
                entity.ToTable("Relationship", "cat");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay)
                    .HasColumnName("allowDisplay")
                    .HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.allowDisplay')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deletedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.deletedBy')))");

                entity.Property(e => e.DeletedDate)
                    .HasColumnName("deletedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.deletedDate')))");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .HasComputedColumnSql("(CONVERT([nvarchar](500),json_value([data],'$.description')))");

                entity.Property(e => e.GenderId)
                    .HasColumnName("genderId")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.genderId')))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.OrderIndex)
                    .HasColumnName("orderIndex")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.orderIndex')))");

                entity.Property(e => e.RelationCode)
                    .HasColumnName("relationCode")
                    .HasMaxLength(50)
                    .HasComputedColumnSql("(CONVERT([nvarchar](50),json_value([data],'$.relationCode')))");

                entity.Property(e => e.RelationName)
                    .HasColumnName("relationName")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([data],'$.relationName')))");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComputedColumnSql("(CONVERT([int],json_value([dataDb],'$.status')))");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Relationship)
                    .HasForeignKey(d => d.GenderId)
                    .HasConstraintName("FK__Relations__gende__40CF895A");
            });

            modelBuilder.Entity<Religion>(entity =>
            {
                entity.ToTable("Religion", "cat");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay)
                    .HasColumnName("allowDisplay")
                    .HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.allowDisplay')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deletedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.deletedBy')))");

                entity.Property(e => e.DeletedDate)
                    .HasColumnName("deletedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.deletedDate')))");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .HasComputedColumnSql("(CONVERT([nvarchar](500),json_value([data],'$.description')))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.OrderIndex)
                    .HasColumnName("orderIndex")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.orderIndex')))");

                entity.Property(e => e.ReligionCode)
                    .HasColumnName("religionCode")
                    .HasMaxLength(50)
                    .HasComputedColumnSql("(CONVERT([nvarchar](50),json_value([data],'$.religionCode')))");

                entity.Property(e => e.ReligionName)
                    .HasColumnName("religionName")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([data],'$.religionName')))");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComputedColumnSql("(CONVERT([int],json_value([dataDb],'$.status')))");
            });

            modelBuilder.Entity<Revenues>(entity =>
            {
                entity.ToTable("Revenues", "pm");

                entity.HasIndex(e => e.VouchersNumber)
                    .HasName("UQ__Revenues__A3FFF1EAB70B4294")
                    .IsUnique();

                entity.Property(e => e.Accountant).HasComputedColumnSql("(CONVERT([int],json_value([data],'$.Accountant')))");

                entity.Property(e => e.AllowDisplay).HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.AllowDisplay')))");

                entity.Property(e => e.AmountOfMoney)
                    .HasColumnType("numeric(20, 3)")
                    .HasComputedColumnSql("(CONVERT([numeric](20,3),json_value([data],'$.AmountOfMoney')))");

                entity.Property(e => e.AmountReceived)
                    .HasColumnType("numeric(20, 3)")
                    .HasComputedColumnSql("(CONVERT([numeric](20,3),json_value([data],'$.AmountReceived')))");

                entity.Property(e => e.BidId).HasComputedColumnSql("(CONVERT([int],json_value([data],'$.BidId')))");

                entity.Property(e => e.Classification)
                    .HasMaxLength(100)
                    .HasComputedColumnSql("(CONVERT([nvarchar](100),json_value([data],'$.Classification')))");

                entity.Property(e => e.Content).HasComputedColumnSql("(CONVERT([nvarchar](max),json_value([data],'$.Content')))");

                entity.Property(e => e.ContractId).HasComputedColumnSql("(CONVERT([int],json_value([data],'$.ContractId')))");

                entity.Property(e => e.CoordinationList)
                    .HasMaxLength(200)
                    .HasComputedColumnSql("(CONVERT([nvarchar](200),json_value([data],'$.CoordinationList')))");

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](50),json_value([dataDb],'$.CreateBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.CreatedDate')))");

                entity.Property(e => e.Currency)
                    .HasMaxLength(100)
                    .HasComputedColumnSql("(CONVERT([nvarchar](100),json_value([data],'$.Currency')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.DatePosted)
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([data],'$.DatePosted')))");

                entity.Property(e => e.EmpId).HasComputedColumnSql("(CONVERT([int],json_value([data],'$.EmpId')))");

                entity.Property(e => e.ExchangeRate)
                    .HasColumnType("numeric(20, 3)")
                    .HasComputedColumnSql("(CONVERT([numeric](20,3),json_value([data],'$.ExchangeRate')))");

                entity.Property(e => e.ExpItenId).HasComputedColumnSql("(CONVERT([int],json_value([data],'$.ExpItenId')))");

                entity.Property(e => e.FrameContract)
                    .HasMaxLength(200)
                    .HasComputedColumnSql("(CONVERT([nvarchar](200),json_value([data],'$.FrameContract')))");

                entity.Property(e => e.ImplementationSchedule)
                    .HasMaxLength(200)
                    .HasComputedColumnSql("(CONVERT([nvarchar](200),json_value([data],'$.ImplementationSchedule')))");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](50),json_value([dataDb],'$.ModifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.ModifiedDate')))");

                entity.Property(e => e.Note)
                    .HasMaxLength(500)
                    .HasComputedColumnSql("(CONVERT([nvarchar](500),json_value([data],'$.Note')))");

                entity.Property(e => e.PartId).HasComputedColumnSql("(CONVERT([int],json_value([data],'$.PartId')))");

                entity.Property(e => e.PaymentType)
                    .HasMaxLength(200)
                    .HasComputedColumnSql("(CONVERT([nvarchar](200),json_value([data],'$.PaymentType')))");

                entity.Property(e => e.Payments)
                    .HasColumnType("numeric(20, 3)")
                    .HasComputedColumnSql("(CONVERT([numeric](20,3),json_value([data],'$.Payments')))");

                entity.Property(e => e.ProjectId)
                    .HasMaxLength(20)
                    .HasComputedColumnSql("(CONVERT([nvarchar](20),json_value([data],'$.ProjectId')))");

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .HasComputedColumnSql("(CONVERT([nvarchar](100),json_value([data],'$.Status')))");

                entity.Property(e => e.Taxpay)
                    .HasColumnType("numeric(20, 3)")
                    .HasComputedColumnSql("(CONVERT([numeric](20,3),json_value([data],'$.Taxpay')))");

                entity.Property(e => e.VouchersDate)
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([data],'$.VouchersDate')))");

                entity.Property(e => e.VouchersNumber)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<RoleClaims>(entity =>
            {
                entity.ToTable("RoleClaims", "aut");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClaimType).HasColumnName("claimType");

                entity.Property(e => e.ClaimValue).HasColumnName("claimValue");

                entity.Property(e => e.RoleId).HasColumnName("roleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleClaims)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__RoleClaim__roleI__79C80F94");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.ToTable("Roles", "aut");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ConcurrencyStamp).HasColumnName("concurrencyStamp");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("data_db");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(256);

                entity.Property(e => e.NormalizedName)
                    .HasColumnName("normalizedName")
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.ToTable("Skill", "cat");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay)
                    .HasColumnName("allowDisplay")
                    .HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.allowDisplay')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deletedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.deletedBy')))");

                entity.Property(e => e.DeletedDate)
                    .HasColumnName("deletedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.deletedDate')))");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .HasComputedColumnSql("(CONVERT([nvarchar](500),json_value([data],'$.description')))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.OrderIndex)
                    .HasColumnName("orderIndex")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.orderIndex')))");

                entity.Property(e => e.SkillCode)
                    .HasColumnName("skillCode")
                    .HasMaxLength(50)
                    .HasComputedColumnSql("(CONVERT([nvarchar](50),json_value([data],'$.skillCode')))");

                entity.Property(e => e.SkillGroupId)
                    .HasColumnName("skillGroupId")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.skillGroupId')))");

                entity.Property(e => e.SkillName)
                    .HasColumnName("skillName")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([data],'$.skillName')))");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComputedColumnSql("(CONVERT([int],json_value([dataDb],'$.status')))");
            });

            modelBuilder.Entity<SkillGroup>(entity =>
            {
                entity.ToTable("SkillGroup", "cat");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay)
                    .HasColumnName("allowDisplay")
                    .HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.allowDisplay')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deletedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.deletedBy')))");

                entity.Property(e => e.DeletedDate)
                    .HasColumnName("deletedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.deletedDate')))");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .HasComputedColumnSql("(CONVERT([nvarchar](500),json_value([data],'$.description')))");

                entity.Property(e => e.GroupCode)
                    .HasColumnName("groupCode")
                    .HasMaxLength(50)
                    .HasComputedColumnSql("(CONVERT([nvarchar](50),json_value([data],'$.groupCode')))");

                entity.Property(e => e.GroupName)
                    .HasColumnName("groupName")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([data],'$.groupName')))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.OrderIndex)
                    .HasColumnName("orderIndex")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.orderIndex')))");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComputedColumnSql("(CONVERT([int],json_value([dataDb],'$.status')))");
            });

            modelBuilder.Entity<SkillLevel>(entity =>
            {
                entity.ToTable("SkillLevel", "cat");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay)
                    .HasColumnName("allowDisplay")
                    .HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.allowDisplay')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deletedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.deletedBy')))");

                entity.Property(e => e.DeletedDate)
                    .HasColumnName("deletedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.deletedDate')))");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .HasComputedColumnSql("(CONVERT([nvarchar](500),json_value([data],'$.description')))");

                entity.Property(e => e.LevelName)
                    .HasColumnName("levelName")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([data],'$.levelName')))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.OrderIndex)
                    .HasColumnName("orderIndex")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.orderIndex')))");

                entity.Property(e => e.SkillId)
                    .HasColumnName("skillId")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.skillId')))");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComputedColumnSql("(CONVERT([int],json_value([dataDb],'$.status')))");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status", "dm");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.Note)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](500),json_value([data],'$.Note')))");

                entity.Property(e => e.StatusName)
                    .HasMaxLength(250)
                    .HasComputedColumnSql("(CONVERT([nvarchar](250),json_value([data],'$.StatusName')))");

                entity.Property(e => e.StatusType).HasComputedColumnSql("(CONVERT([int],json_value([data],'$.StatusType')))");
            });

            modelBuilder.Entity<StorageCabinets>(entity =>
            {
                entity.ToTable("StorageCabinets", "dm");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AmountCabin).HasComputedColumnSql("(CONVERT([int],json_value([data],'$.AmountCabin')))");

                entity.Property(e => e.CabCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](20),json_value([data],'$.CabCode')))");

                entity.Property(e => e.CabinetName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](200),json_value([data],'$.CabinetName')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.EmpId).HasComputedColumnSql("(CONVERT([int],json_value([data],'$.EmpId')))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.Note)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](500),json_value([data],'$.Note')))");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("Supplier", "cat");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay)
                    .HasColumnName("allowDisplay")
                    .HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.allowDisplay')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deletedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.deletedBy')))");

                entity.Property(e => e.DeletedDate)
                    .HasColumnName("deletedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.deletedDate')))");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .HasComputedColumnSql("(CONVERT([nvarchar](500),json_value([data],'$.description')))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.OrderIndex)
                    .HasColumnName("orderIndex")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.orderIndex')))");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComputedColumnSql("(CONVERT([int],json_value([dataDb],'$.status')))");

                entity.Property(e => e.SupplierCode)
                    .HasColumnName("supplierCode")
                    .HasMaxLength(50)
                    .HasComputedColumnSql("(CONVERT([nvarchar](50),json_value([data],'$.supplierCode')))");

                entity.Property(e => e.SupplierName)
                    .HasColumnName("supplierName")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([data],'$.supplierName')))");
            });

            modelBuilder.Entity<TableModel>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("data_db");

                entity.Property(e => e.Files).HasColumnName("files");
            });

            modelBuilder.Entity<Target>(entity =>
            {
                entity.ToTable("Target", "dm");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay).HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.AllowDisplay')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.Note)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](500),json_value([data],'$.Note')))");

                entity.Property(e => e.TargetNameEn)
                    .HasColumnName("TargetNameEN")
                    .HasMaxLength(250)
                    .HasComputedColumnSql("(CONVERT([nvarchar](250),json_value([data],'$.TargetNameEN')))");

                entity.Property(e => e.TargetNameVn)
                    .HasColumnName("TargetNameVN")
                    .HasMaxLength(250)
                    .HasComputedColumnSql("(CONVERT([nvarchar](250),json_value([data],'$.TargetNameVN')))");
            });

            modelBuilder.Entity<TargetDetail>(entity =>
            {
                entity.ToTable("TargetDetail", "dm");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay).HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.AllowDisplay')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.Idtarget).HasComputedColumnSql("(CONVERT([int],json_value([data],'$.Idtarget')))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.Note)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](500),json_value([data],'$.Note')))");

                entity.Property(e => e.StageColor)
                    .HasMaxLength(30)
                    .HasComputedColumnSql("(CONVERT([nvarchar](30),json_value([data],'$.StageColor')))");

                entity.Property(e => e.StageIndex).HasComputedColumnSql("(CONVERT([int],json_value([data],'$.StageIndex')))");

                entity.Property(e => e.StagePercent).HasComputedColumnSql("(CONVERT([int],json_value([data],'$.StagePercent')))");

                entity.Property(e => e.TargetDetailNameEn)
                    .HasColumnName("TargetDetailNameEN")
                    .HasMaxLength(250)
                    .HasComputedColumnSql("(CONVERT([nvarchar](250),json_value([data],'$.TargetDetailNameEN')))");

                entity.Property(e => e.TargetDetailNameVn)
                    .HasColumnName("TargetDetailNameVN")
                    .HasMaxLength(250)
                    .HasComputedColumnSql("(CONVERT([nvarchar](250),json_value([data],'$.TargetDetailNameVN')))");
            });

            modelBuilder.Entity<Template>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");
            });

            modelBuilder.Entity<TermsOfPayment>(entity =>
            {
                entity.ToTable("TermsOfPayment", "dm");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay).HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.AllowDisplay')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.Note)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](500),json_value([data],'$.Note')))");

                entity.Property(e => e.TermsOfPaymentName)
                    .HasMaxLength(250)
                    .HasComputedColumnSql("(CONVERT([nvarchar](250),json_value([data],'$.TermsOfPaymentName')))");
            });

            modelBuilder.Entity<TermsPayDetail>(entity =>
            {
                entity.ToTable("TermsPayDetail", "dm");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BonusRate).HasComputedColumnSql("(CONVERT([int],json_value([data],'$.BonusRate')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.DayNumber).HasComputedColumnSql("(CONVERT([int],json_value([data],'$.DayNumber')))");

                entity.Property(e => e.DurationBonus).HasComputedColumnSql("(CONVERT([int],json_value([data],'$.DurationBonus')))");

                entity.Property(e => e.DurationPenalty).HasComputedColumnSql("(CONVERT([int],json_value([data],'$.DurationPenalty')))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.Note)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](500),json_value([data],'$.Note')))");

                entity.Property(e => e.PenaltyRate).HasComputedColumnSql("(CONVERT([int],json_value([data],'$.PenaltyRate')))");

                entity.Property(e => e.Rate).HasComputedColumnSql("(CONVERT([int],json_value([data],'$.Rate')))");

                entity.Property(e => e.TermsOfPayId).HasComputedColumnSql("(CONVERT([int],json_value([data],'$.TermsOfPayId')))");
            });

            modelBuilder.Entity<TimeSheet>(entity =>
            {
                entity.ToTable("TimeSheet", "pm");

                entity.Property(e => e.Cn)
                    .HasColumnName("CN")
                    .HasColumnType("numeric(10, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DateNumber).HasDefaultValueSql("((0))");

                entity.Property(e => e.Delete)
                    .HasColumnName("delete")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StartDay)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.T2)
                    .HasColumnType("numeric(10, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.T3)
                    .HasColumnType("numeric(10, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.T4)
                    .HasColumnType("numeric(10, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.T5)
                    .HasColumnType("numeric(10, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.T6)
                    .HasColumnType("numeric(10, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.T7)
                    .HasColumnType("numeric(10, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Topic).HasMaxLength(250);
            });

            modelBuilder.Entity<TimeSheetDetail>(entity =>
            {
                entity.ToTable("TimeSheetDetail", "pm");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.Days).HasColumnName("days");

                entity.Property(e => e.TimeSheetId).HasColumnName("TimeSheetID");

                entity.Property(e => e.Times).HasColumnName("times");
            });

            modelBuilder.Entity<TrainingLecturers>(entity =>
            {
                entity.ToTable("TrainingLecturers", "cat");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasMaxLength(256);

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<TrainningPartner>(entity =>
            {
                entity.ToTable("TrainningPartner", "cat");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");
            });

            modelBuilder.Entity<TrainningPlan>(entity =>
            {
                entity.ToTable("TrainningPlan", "hrm");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Basic).HasColumnName("basic");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasMaxLength(256);

                entity.Property(e => e.Commitment).HasColumnName("commitment");

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.Files).HasColumnName("files");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(256);

                entity.Property(e => e.PartnerId).HasColumnName("partnerId");

                entity.Property(e => e.PerformanceId)
                    .HasColumnName("performanceId")
                    .HasComputedColumnSql("(CONVERT([int],json_value([result],'$.performanceId')))");

                entity.Property(e => e.Result).HasColumnName("result");

                entity.Property(e => e.TrainningPlanEmployee).HasColumnName("trainningPlanEmployee");

                entity.Property(e => e.TrainningRequestId).HasColumnName("trainningRequestId");

                entity.HasOne(d => d.Partner)
                    .WithMany(p => p.TrainningPlan)
                    .HasForeignKey(d => d.PartnerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Trainning__partn__69D19EED");

                entity.HasOne(d => d.TrainingLecturers)
                    .WithMany(p => p.TrainningPlan)
                    .HasForeignKey(d => d.TrainingLecturersId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Trainning__Train__6BB9E75F");

                entity.HasOne(d => d.TrainningRequest)
                    .WithMany(p => p.TrainningPlan)
                    .HasForeignKey(d => d.TrainningRequestId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Trainning__train__6AC5C326");
            });

            modelBuilder.Entity<TrainningPlanEmployee>(entity =>
            {
                entity.HasKey(e => new { e.TrainningPlanId, e.EmployeeId })
                    .HasName("PK__Trainnin__13B0AFB7FA8B72CB");

                entity.ToTable("TrainningPlanEmployee", "hrm");

                entity.Property(e => e.TrainningPlanId).HasColumnName("trainningPlanId");

                entity.Property(e => e.EmployeeId).HasColumnName("employeeId");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.TrainningPlanEmployee)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Trainning__emplo__0B3292B8");

                entity.HasOne(d => d.TrainningPlan)
                    .WithMany(p => p.TrainningPlanEmployeeNavigation)
                    .HasForeignKey(d => d.TrainningPlanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Trainning__train__0A3E6E7F");
            });

            modelBuilder.Entity<TrainningRequest>(entity =>
            {
                entity.ToTable("TrainningRequest", "hrm");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Basic).HasColumnName("basic");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasMaxLength(256);

                entity.Property(e => e.CompanyInfoId).HasColumnName("companyInfoId");

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.CourseId).HasColumnName("courseId");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.ExpertId).HasColumnName("expertId");

                entity.Property(e => e.Files).HasColumnName("files");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(256);

                entity.Property(e => e.PartnerId).HasColumnName("partnerId");

                entity.Property(e => e.TypeOfEducationId).HasColumnName("typeOfEducationId");

                entity.HasOne(d => d.CompanyInfo)
                    .WithMany(p => p.TrainningRequest)
                    .HasForeignKey(d => d.CompanyInfoId)
                    .HasConstraintName("FK_TrainningRequest_CompanyInfo");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.TrainningRequest)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_TrainningRequest_Course");

                entity.HasOne(d => d.Expert)
                    .WithMany(p => p.TrainningRequest)
                    .HasForeignKey(d => d.ExpertId)
                    .HasConstraintName("FK_TrainningRequest_Expert");

                entity.HasOne(d => d.Partner)
                    .WithMany(p => p.TrainningRequest)
                    .HasForeignKey(d => d.PartnerId)
                    .HasConstraintName("FK_TrainningRequest_TrainningPartner");

                entity.HasOne(d => d.TypeOfEducation)
                    .WithMany(p => p.TrainningRequest)
                    .HasForeignKey(d => d.TypeOfEducationId)
                    .HasConstraintName("FK_TrainningRequest_TypeOfEducation");
            });

            modelBuilder.Entity<TypeOfBusiness>(entity =>
            {
                entity.ToTable("TypeOfBusiness", "cat");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay)
                    .HasColumnName("allowDisplay")
                    .HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.allowDisplay')))");

                entity.Property(e => e.BusinessTypeCode)
                    .HasColumnName("businessTypeCode")
                    .HasMaxLength(50)
                    .HasComputedColumnSql("(CONVERT([nvarchar](50),json_value([data],'$.businessTypeCode')))");

                entity.Property(e => e.BusinessTypeName)
                    .HasColumnName("businessTypeName")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([data],'$.businessTypeName')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deletedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.deletedBy')))");

                entity.Property(e => e.DeletedDate)
                    .HasColumnName("deletedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.deletedDate')))");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .HasComputedColumnSql("(CONVERT([nvarchar](500),json_value([data],'$.description')))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.OrderIndex)
                    .HasColumnName("orderIndex")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.orderIndex')))");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComputedColumnSql("(CONVERT([int],json_value([dataDb],'$.status')))");
            });

            modelBuilder.Entity<TypeOfEducation>(entity =>
            {
                entity.ToTable("TypeOfEducation", "cat");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay)
                    .HasColumnName("allowDisplay")
                    .HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.allowDisplay')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deletedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.deletedBy')))");

                entity.Property(e => e.DeletedDate)
                    .HasColumnName("deletedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.deletedDate')))");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .HasComputedColumnSql("(CONVERT([nvarchar](500),json_value([data],'$.description')))");

                entity.Property(e => e.EduTypeCode)
                    .HasColumnName("eduTypeCode")
                    .HasMaxLength(50)
                    .HasComputedColumnSql("(CONVERT([nvarchar](50),json_value([data],'$.eduTypeCode')))");

                entity.Property(e => e.EduTypeName)
                    .HasColumnName("eduTypeName")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([data],'$.eduTypeName')))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.OrderIndex)
                    .HasColumnName("orderIndex")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.orderIndex')))");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComputedColumnSql("(CONVERT([int],json_value([dataDb],'$.status')))");
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.ToTable("Unit", "cat");

                entity.HasIndex(e => e.ParentId)
                    .HasName("index_parentId");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay)
                    .HasColumnName("allowDisplay")
                    .HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.allowDisplay')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deletedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.deletedBy')))");

                entity.Property(e => e.DeletedDate)
                    .HasColumnName("deletedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.deletedDate')))");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .HasComputedColumnSql("(CONVERT([nvarchar](500),json_value([data],'$.description')))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.OrderIndex)
                    .HasColumnName("orderIndex")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.orderIndex')))");

                entity.Property(e => e.ParentId)
                    .HasColumnName("parentId")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.parentId')))");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComputedColumnSql("(CONVERT([int],json_value([dataDb],'$.status')))");

                entity.Property(e => e.UnitCode)
                    .HasColumnName("unitCode")
                    .HasMaxLength(50)
                    .HasComputedColumnSql("(CONVERT([nvarchar](50),json_value([data],'$.unitCode')))");

                entity.Property(e => e.UnitName)
                    .HasColumnName("unitName")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([data],'$.unitName')))");

                entity.Property(e => e.UnitTypeId)
                    .HasColumnName("unitTypeId")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.unitTypeId')))");

                entity.HasOne(d => d.UnitType)
                    .WithMany(p => p.Unit)
                    .HasForeignKey(d => d.UnitTypeId)
                    .HasConstraintName("FK__Unit__unitTypeId__2FA4FD58");
            });

            modelBuilder.Entity<UnitType>(entity =>
            {
                entity.ToTable("UnitType", "cat");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay)
                    .HasColumnName("allowDisplay")
                    .HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.allowDisplay')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deletedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.deletedBy')))");

                entity.Property(e => e.DeletedDate)
                    .HasColumnName("deletedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.deletedDate')))");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .HasComputedColumnSql("(CONVERT([nvarchar](500),json_value([data],'$.description')))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.OrderIndex)
                    .HasColumnName("orderIndex")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.orderIndex')))");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComputedColumnSql("(CONVERT([int],json_value([dataDb],'$.status')))");

                entity.Property(e => e.UnitTypeCode)
                    .HasColumnName("unitTypeCode")
                    .HasMaxLength(50)
                    .HasComputedColumnSql("(CONVERT([nvarchar](50),json_value([data],'$.unitTypeCode')))");

                entity.Property(e => e.UnitTypeName)
                    .HasColumnName("unitTypeName")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([data],'$.unitTypeName')))");
            });

            modelBuilder.Entity<UserClaims>(entity =>
            {
                entity.ToTable("UserClaims", "aut");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClaimType).HasColumnName("claimType");

                entity.Property(e => e.ClaimValue).HasColumnName("claimValue");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserClaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UserClaim__userI__7ABC33CD");
            });

            modelBuilder.Entity<UserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey })
                    .HasName("PK__UserLogi__473D8ACB306F2044");

                entity.ToTable("UserLogins", "aut");

                entity.Property(e => e.LoginProvider).HasColumnName("loginProvider");

                entity.Property(e => e.ProviderKey).HasColumnName("providerKey");

                entity.Property(e => e.ProviderDisplayName).HasColumnName("providerDisplayName");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserLogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UserLogin__userI__7BB05806");
            });

            modelBuilder.Entity<UserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PK__UserRole__7743989D8FF9A701");

                entity.ToTable("UserRoles", "aut");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.RoleId).HasColumnName("roleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__UserRoles__roleI__7CA47C3F");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UserRoles__userI__7D98A078");
            });

            modelBuilder.Entity<UserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name })
                    .HasName("PK__UserToke__A21948E2D672616E");

                entity.ToTable("UserTokens", "aut");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.LoginProvider).HasColumnName("loginProvider");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Value).HasColumnName("value");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("Users", "aut");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccessFailedCount).HasColumnName("accessFailedCount");

                entity.Property(e => e.ConcurrencyStamp).HasColumnName("concurrencyStamp");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(256);

                entity.Property(e => e.EmailConfirmed).HasColumnName("emailConfirmed");

                entity.Property(e => e.Files).HasColumnName("files");

                entity.Property(e => e.LockoutEnabled).HasColumnName("lockoutEnabled");

                entity.Property(e => e.LockoutEnd).HasColumnName("lockoutEnd");

                entity.Property(e => e.NormalizedEmail)
                    .HasColumnName("normalizedEmail")
                    .HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName)
                    .HasColumnName("normalizedUserName")
                    .HasMaxLength(256);

                entity.Property(e => e.PasswordHash).HasColumnName("passwordHash");

                entity.Property(e => e.PhoneNumber).HasColumnName("phoneNumber");

                entity.Property(e => e.PhoneNumberConfirmed).HasColumnName("phoneNumberConfirmed");

                entity.Property(e => e.SecurityStamp).HasColumnName("securityStamp");

                entity.Property(e => e.TwoFactorEnabled).HasColumnName("twoFactorEnabled");

                entity.Property(e => e.UserName)
                    .HasColumnName("userName")
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<WorkEnvironment>(entity =>
            {
                entity.ToTable("WorkEnvironment", "cat");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay)
                    .HasColumnName("allowDisplay")
                    .HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.allowDisplay')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deletedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.deletedBy')))");

                entity.Property(e => e.DeletedDate)
                    .HasColumnName("deletedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.deletedDate')))");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .HasComputedColumnSql("(CONVERT([nvarchar](500),json_value([data],'$.description')))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.OrderIndex)
                    .HasColumnName("orderIndex")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.orderIndex')))");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComputedColumnSql("(CONVERT([int],json_value([dataDb],'$.status')))");

                entity.Property(e => e.WorkCode)
                    .HasColumnName("workCode")
                    .HasMaxLength(50)
                    .HasComputedColumnSql("(CONVERT([nvarchar](50),json_value([data],'$.workCode')))");

                entity.Property(e => e.WorkName)
                    .HasColumnName("workName")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([data],'$.workName')))");
            });

            modelBuilder.Entity<WorkType>(entity =>
            {
                entity.ToTable("WorkType", "dm");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay).HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.AllowDisplay')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasColumnType("datetime")
                    .HasComputedColumnSql("(CONVERT([datetime],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.Note)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(CONVERT([varchar](500),json_value([data],'$.Note')))");

                entity.Property(e => e.WorkTypeIndex).HasComputedColumnSql("(CONVERT([int],json_value([data],'$.WorrkTypeIndex')))");

                entity.Property(e => e.WorkTypeName)
                    .HasMaxLength(250)
                    .HasComputedColumnSql("(CONVERT([nvarchar](250),json_value([data],'$.WorkTypeName')))");
            });

            modelBuilder.Entity<WorkmanshipLevel>(entity =>
            {
                entity.ToTable("WorkmanshipLevel", "cat");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllowDisplay)
                    .HasColumnName("allowDisplay")
                    .HasComputedColumnSql("(CONVERT([bit],json_value([data],'$.allowDisplay')))");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.createdBy')))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("createdDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.createdDate')))");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DataDb).HasColumnName("dataDb");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deletedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.deletedBy')))");

                entity.Property(e => e.DeletedDate)
                    .HasColumnName("deletedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.deletedDate')))");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .HasComputedColumnSql("(CONVERT([nvarchar](500),json_value([data],'$.description')))");

                entity.Property(e => e.LevelCode)
                    .HasColumnName("levelCode")
                    .HasMaxLength(50)
                    .HasComputedColumnSql("(CONVERT([nvarchar](50),json_value([data],'$.levelCode')))");

                entity.Property(e => e.LevelName)
                    .HasColumnName("levelName")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([data],'$.levelName')))");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256)
                    .HasComputedColumnSql("(CONVERT([nvarchar](256),json_value([dataDb],'$.modifiedBy')))");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasComputedColumnSql("(CONVERT([datetime2],json_value([dataDb],'$.modifiedDate')))");

                entity.Property(e => e.OrderIndex)
                    .HasColumnName("orderIndex")
                    .HasComputedColumnSql("(CONVERT([int],json_value([data],'$.orderIndex')))");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComputedColumnSql("(CONVERT([int],json_value([dataDb],'$.status')))");
            });
        }
    }
}
