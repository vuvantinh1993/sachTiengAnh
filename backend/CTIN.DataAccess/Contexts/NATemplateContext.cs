using CTIN.DataAccess.Bases;
using CTIN.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Expressions;

namespace CTIN.DataAccess.Contexts
{
    public partial class NATemplateContext : DbContext
    {
        public NATemplateContext()
        {
        }

        public NATemplateContext(DbContextOptions<NATemplateContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Template> Template { get; set; }
        public virtual DbSet<ProjWorks> ProjWorks { get; set; }
        public virtual DbSet<Target> Target { get; set; }
        public virtual DbSet<Partner> Partner { get; set; }
        public virtual DbSet<Bidding> Bidding { get; set; }
        public virtual DbSet<BiddingModel> BiddingModel { get; set; }
        public virtual DbSet<Contractor> Contractor { get; set; }
        public virtual DbSet<Cr> Cr { get; set; }
        public virtual DbSet<LogWork> LogWork { get; set; }
        public virtual DbSet<ProjGeneral> ProjGeneral { get; set; }
        public virtual DbSet<Issue> Issue { get; set; }
        public virtual DbSet<WorkType> WorkType { get; set; }
        public virtual DbSet<IssueType> IssueType { get; set; }
        public virtual DbSet<IssueCauses> IssueCauses { get; set; }
        public virtual DbSet<ExpensesItemGroup> ExpensesItemGroup { get; set; }
        public virtual DbSet<ExpensesItem> ExpensesItem { get; set; }
        public virtual DbSet<ContractForm> ContractForm { get; set; }
        public virtual DbSet<PartnerGroup> PartnerGroup { get; set; }
        public virtual DbSet<ProjectGroup> ProjectGroup { get; set; }
        public virtual DbSet<ManagementForm> ManagementForm { get; set; }
        public virtual DbSet<Invests> Invests { get; set; }
        public virtual DbSet<ProductServices> ProductServices { get; set; }
        public virtual DbSet<BizModel> BizModel { get; set; }
        public virtual DbSet<ProjectType> ProjectType { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<TargetDetail> TargetDetail { get; set; }
        public virtual DbSet<ProjectProfile> ProjectProfile { get; set; }
        public virtual DbSet<ProjProfileDetail> ProjProfileDetail { get; set; }
        public virtual DbSet<RecyclebBin> RecyclebBin { get; set; }
        public virtual DbSet<ProjectResources> ProjectResources { get; set; }
        public virtual DbSet<BiddingDocuments> BiddingDocuments { get; set; }
        public virtual DbSet<PackageBids> PackageBids { get; set; }
        public virtual DbSet<Acttachments> Acttachments { get; set; }
        public virtual DbSet<Contracts> Contracts { get; set; }
        public virtual DbSet<TermsOfPayment> TermsOfPayment { get; set; }
        public virtual DbSet<PaymentType> PaymentType { get; set; }
        public virtual DbSet<Currency> Currency { get; set; }
        public virtual DbSet<HandoverSchedule> HandoverSchedule { get; set; }
        public virtual DbSet<Crtype> Crtype { get; set; }
        public virtual DbSet<Files> Files { get; set; }
        public virtual DbSet<ExpectedCosts> ExpectedCosts { get; set; }
        public virtual DbSet<ModeBidding> ModeBidding { get; set; }
        public virtual DbSet<StorageCabinets> StorageCabinets { get; set; }
        public virtual DbSet<FieldOfActivity> FieldOfActivity { get; set; }
        public virtual DbSet<ActualCosts> ActualCosts { get; set; }
        public virtual DbSet<CollateCosts> CollateCosts { get; set; }
        public virtual DbSet<Revenues> Revenues { get; set; }
        public virtual DbSet<TimeSheet> TimeSheet { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<CompanyInfo> CompanyInfo { get; set; }
        public virtual DbSet<TypeOfBusiness> TypeOfBusiness { get; set; }
        public virtual DbSet<PaymentSchedule> PaymentSchedule { get; set; }
        public virtual DbSet<TimeSheetDetail> TimeSheetDetail { get; set; }



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
            var jsonValueMethod = typeof(DbFunction).GetMethod(nameof(DbFunction.JsonValue));
            modelBuilder.HasDbFunction(jsonValueMethod)
            .HasTranslation(args =>
            {
                return new SqlFunctionExpression("JSON_VALUE", jsonValueMethod.ReturnType, args);
            });
            modelBuilder.Entity<ProjGeneral>(entity =>
            {
                entity.ToTable("ProjGeneral", "pm");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.allowEmail).HasDefaultValueSql("((1))");

                entity.Property(e => e.beginDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.budgetRemaining)
                    .HasColumnType("numeric(20, 3)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.completedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.content).IsUnicode(true);

                entity.Property(e => e.costBooks)
                    .HasColumnType("numeric(20, 3)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.crbudget)
                    .HasColumnName("CRBudget")
                    .HasColumnType("numeric(20, 3)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.createdBy)
                    .HasMaxLength(50)
                    .HasColumnName("createBy");

                entity.Property(e => e.createdDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.currency)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('VND')");

                entity.Property(e => e.endDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.estimatedBudget)
                    .HasColumnType("numeric(20, 3)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.exchangeRate)
                    .HasColumnType("numeric(20, 3)")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.feasibilityCrbudget)
                    .HasColumnName("FeasibilityCRBudget")
                    .HasColumnType("numeric(20, 3)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.feasibilityStadyBudget)
                    .HasColumnType("numeric(20, 3)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.learderName)
                    .HasMaxLength(200);

                entity.Property(e => e.memory)
                    .HasMaxLength(500);

                entity.Property(e => e.modifiedBy)
                    .HasMaxLength(50);

                entity.Property(e => e.modifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.note)
                    .HasMaxLength(500);

                entity.Property(e => e.planBudget)
                    .HasColumnType("numeric(20, 3)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.pmName)
                    .HasMaxLength(70);

                entity.Property(e => e.projCode)
                    .HasMaxLength(15);

                entity.Property(e => e.projName)
                    .HasMaxLength(150);

                entity.Property(e => e.projPercent).HasDefaultValueSql("((0))");

                entity.Property(e => e.projPriority)
                    .HasMaxLength(80);

                entity.Property(e => e.proposedBudget)
                    .HasColumnType("numeric(20, 3)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.salesPlan)
                    .HasColumnType("numeric(20, 3)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.totalContractAmount)
                    .HasColumnType("numeric(20, 3)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.totalContractExpenses)
                    .HasColumnType("numeric(20, 3)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.totalContractPayment)
                    .HasColumnType("numeric(20, 3)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.totalContractRemaining)
                    .HasColumnType("numeric(20, 3)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.totalCostContract)
                    .HasColumnType("numeric(20, 3)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.totalOperatingExpenses)
                    .HasColumnType("numeric(20, 3)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.projectMembers).HasMaxLength(250).IsJson();

                entity.Property(e => e.coordinatorDep).HasMaxLength(250).IsJson();
            });

            modelBuilder.Entity<Bidding>(entity =>
            {
                entity.ToTable("Bidding", "dm");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.data).HasColumnName("data").IsJson();

                entity.Property(e => e.dataDb).HasColumnName("dataDb").IsJson();
            });

            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity<Template>(entity =>
            {
                entity.Property(e => e.id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.address)
                    .HasColumnName("address")
                    .HasMaxLength(256);

                entity.Property(e => e.dataDb).HasColumnName("dataDb").IsJson();

                entity.Property(e => e.name)
                    .HasColumnName("name")
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<BiddingModel>(entity =>
             {
                 entity.ToTable("BiddingModel", "dm");

                 entity.Property(e => e.id).HasColumnName("id");

                 entity.Property(e => e.data).HasColumnName("data").IsJson();

                 entity.Property(e => e.dataDb).HasColumnName("dataDb").IsJson();
             });

            modelBuilder.Entity<Contractor>(entity =>
            {
                entity.ToTable("Contractor", "dm");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.data).HasColumnName("data").IsJson();

                entity.Property(e => e.dataDb).HasColumnName("dataDb").IsJson();
            });

            modelBuilder.Entity<ProjWorks>(entity =>
            {
                entity.ToTable("Projworks", "pm");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.beginDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.completeDate)
                    .HasColumnName("completeDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.contact)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.content).HasMaxLength(500);

                entity.Property(e => e.coordinationList)
                    .HasMaxLength(500).IsJson();

                entity.Property(e => e.createdBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.createdDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.delete)
                    .HasColumnName("delete")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.endDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.modifiedBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.modifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.note).HasMaxLength(500);

                entity.Property(e => e.perrentId).HasDefaultValueSql("((0))");

                entity.Property(e => e.workCompleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.workName)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<Acttachments>(entity =>
            {
                entity.ToTable("Acttachments", "pm");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.fileData).HasColumnName("FileData").IsJson();

                entity.Property(e => e.dataDb).HasColumnName("dataDb").IsJson();
            });

            modelBuilder.Entity<Target>(entity =>
            {
                entity.ToTable("Target", "dm");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.data).HasColumnName("data").IsJson();

                entity.Property(e => e.dataDb).HasColumnName("dataDb").IsJson();
            });

            modelBuilder.Entity<Cr>(entity =>
            {
                entity.ToTable("Cr", "pm");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.createdBy)
                    .HasMaxLength(50);

                entity.Property(e => e.createdDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.modifiedBy)
                    .HasMaxLength(50);

                entity.Property(e => e.modifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.newValue)
                    .HasMaxLength(500);

                entity.Property(e => e.note)
                    .HasMaxLength(500);

                entity.Property(e => e.oldValue)
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<Partner>(entity =>
            {
                entity.ToTable("Partner", "dm");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.data).HasColumnName("data").IsJson();

                entity.Property(e => e.dataDb).HasColumnName("dataDb").IsJson();

                entity.HasOne(p => p.projGeneral)
                .WithOne(pg => pg.pmNam)
                .HasForeignKey<ProjGeneral>(pg => pg.pmName);
            });

            modelBuilder.Entity<LogWork>(entity =>
            {
                entity.ToTable("LogWorks", "pm");

                entity.Property(e => e.id).HasColumnName("id");
                entity.Property(e => e.emmpId).HasColumnName("emmpId");

                entity.Property(e => e.content)
                    .HasMaxLength(500);

                entity.Property(e => e.currentdate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Issue>(entity =>
            {
                entity.ToTable("Issue", "pm");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.beginDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.completedDate).HasColumnType("datetime");

                entity.Property(e => e.contactList)
                    .HasMaxLength(500);

                entity.Property(e => e.content).IsUnicode(true);

                entity.Property(e => e.coordinationList)
                   .HasMaxLength(500)
                   .IsUnicode(true)
                   .IsJson();

                entity.Property(e => e.createdBy)
                    .HasMaxLength(100);

                entity.Property(e => e.createdDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.endDate).HasColumnType("datetime");

                entity.Property(e => e.modifiedBy)
                    .HasMaxLength(100);

                entity.Property(e => e.modifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.percentCompleted).HasDefaultValueSql("((0))");



                //entity.Property(e => e.timePlan)
                //    .HasColumnType("numeric(2, 2)")
                //    .HasDefaultValueSql("((0))");

                //entity.Property(e => e.timeReality)
                //    .HasColumnType("numeric(2, 2)")
                //    .HasDefaultValueSql("((0))");

                entity.Property(e => e.issueName)
                    .HasMaxLength(250);

                entity.Property(e => e.note).HasMaxLength(500);
                entity.Property(e => e.solusion).HasMaxLength(500);
            });

            modelBuilder.Entity<WorkType>(entity =>
            {
                entity.ToTable("WorkType", "dm");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.data).HasColumnName("data").IsJson();

                entity.Property(e => e.dataDb).HasColumnName("dataDb").IsJson();
            });

            modelBuilder.Entity<IssueType>(entity =>
            {
                entity.ToTable("IssueType", "dm");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.data).HasColumnName("data").IsJson();

                entity.Property(e => e.dataDb).HasColumnName("dataDb").IsJson();
            });

            modelBuilder.Entity<IssueCauses>(entity =>
            {
                entity.ToTable("IssueCauses", "dm");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.data).HasColumnName("data").IsJson();

                entity.Property(e => e.dataDb).HasColumnName("dataDb").IsJson();
            });

            modelBuilder.Entity<ExpensesItemGroup>(entity =>
            {
                entity.ToTable("ExpensesItemGroup", "dm");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.data).HasColumnName("data").IsJson();

                entity.Property(e => e.dataDb).HasColumnName("dataDb").IsJson();
            });

            modelBuilder.Entity<ExpensesItem>(entity =>
            {
                entity.ToTable("ExpensesItem", "dm");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.data).HasColumnName("data").IsJson();

                entity.Property(e => e.dataDb).HasColumnName("dataDb").IsJson();
            });

            modelBuilder.Entity<ContractForm>(entity =>
            {
                entity.ToTable("ContractForm", "dm");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.data).HasColumnName("data").IsJson();

                entity.Property(e => e.dataDb).HasColumnName("dataDb").IsJson();
            });

            modelBuilder.Entity<PartnerGroup>(entity =>
            {
                entity.ToTable("PartnerGroup", "dm");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.data).HasColumnName("data").IsJson();

                entity.Property(e => e.dataDb).HasColumnName("dataDb").IsJson();
            });

            modelBuilder.Entity<ProjectGroup>(entity =>
            {
                entity.ToTable("ProjectGroup", "dm");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.data).HasColumnName("data").IsJson();

                entity.Property(e => e.dataDb).HasColumnName("dataDb").IsJson();
            });

            modelBuilder.Entity<ManagementForm>(entity =>
            {
                entity.ToTable("ManagementForm", "dm");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.data).HasColumnName("data").IsJson();

                entity.Property(e => e.dataDb).HasColumnName("dataDb").IsJson();
            });

            modelBuilder.Entity<Invests>(entity =>
            {
                entity.ToTable("Invests", "dm");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.data).HasColumnName("data").IsJson();

                entity.Property(e => e.dataDb).HasColumnName("dataDb").IsJson();
            });

            modelBuilder.Entity<ProductServices>(entity =>
            {
                entity.ToTable("ProductServices", "dm");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.data).HasColumnName("data").IsJson();

                entity.Property(e => e.dataDb).HasColumnName("dataDb").IsJson();
            });

            modelBuilder.Entity<BizModel>(entity =>
             {
                 entity.ToTable("BizModel", "dm");

                 entity.Property(e => e.id).HasColumnName("id");

                 entity.Property(e => e.data).HasColumnName("data").IsJson();

                 entity.Property(e => e.dataDb).HasColumnName("dataDb").IsJson();
             });

            modelBuilder.Entity<ProjectType>(entity =>
            {
                entity.ToTable("ProjectType", "dm");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.data).HasColumnName("data").IsJson();

                entity.Property(e => e.dataDb).HasColumnName("dataDb").IsJson();
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status", "dm");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.data).HasColumnName("data").IsJson();

                entity.Property(e => e.dataDb).HasColumnName("dataDb").IsJson();
            });

            modelBuilder.Entity<TargetDetail>(entity =>
            {
                entity.ToTable("TargetDetail", "dm");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.data).HasColumnName("data").IsJson();

                entity.Property(e => e.dataDb).HasColumnName("dataDb").IsJson();
            });

            modelBuilder.Entity<ProjectProfile>(entity =>
            {
                entity.ToTable("ProjectProfile", "dm");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.data).HasColumnName("data").IsJson();

                entity.Property(e => e.dataDb).HasColumnName("dataDb").IsJson();
            });

            modelBuilder.Entity<ProjProfileDetail>(entity =>
            {
                entity.ToTable("ProjProfileDetail", "dm");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.data).HasColumnName("data").IsJson();

                entity.Property(e => e.dataDb).HasColumnName("dataDb").IsJson();
            });

            modelBuilder.Entity<RecyclebBin>(entity =>
            {
                entity.ToTable("RecyclebBin", "dm");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.data).HasColumnName("data").IsJson();

                entity.Property(e => e.dataDb).HasColumnName("dataDb").IsJson();
            });

            modelBuilder.Entity<ProjectResources>(entity =>
            {
                entity.ToTable("ProjectResources", "pm");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.beginDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.createdBy)
                    .HasColumnName("createdBy")
                    .HasMaxLength(256);

                entity.Property(e => e.createdDate)
                    .HasColumnName("createdDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.endDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.modifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(256);

                entity.Property(e => e.modifiedDate)
                    .HasColumnName("modifiedDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.note)
                    .HasMaxLength(500);

                entity.Property(e => e.relatedList).HasColumnName("RelatedList").IsJson();

                entity.Property(e => e.percentResource).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<BiddingDocuments>(entity =>
            {
                entity.ToTable("BiddingDocuments", "pm");

                entity.Property(e => e.adjustmentDate).HasColumnType("datetime");

                entity.Property(e => e.allowDisplay).HasDefaultValueSql("((1))");

                entity.Property(e => e.createdBy)
                    .HasMaxLength(50)
                    .HasColumnType("createBy");

                entity.Property(e => e.createdDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.dateOfApproval).HasColumnType("datetime");

                entity.Property(e => e.dateOfBidSubmission).HasColumnType("datetime");

                entity.Property(e => e.dateOfVerification).HasColumnType("datetime");

                entity.Property(e => e.datePassed).HasColumnType("datetime");

                entity.Property(e => e.decisionNumber)
                    .HasMaxLength(200);

                entity.Property(e => e.listEmpId)
                    .HasMaxLength(200)
                    .IsJson();

                entity.Property(e => e.modifiedBy)
                    .HasMaxLength(50);

                entity.Property(e => e.modifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.note).IsUnicode(true);

                entity.Property(e => e.releaseDate).HasColumnType("datetime");

                entity.Property(e => e.signedOn).HasColumnType("datetime");

                entity.Property(e => e.submissionDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<PackageBids>(entity =>
            {
                entity.ToTable("PackageBids", "pm");

                entity.Property(e => e.bestBid)
                    .HasColumnType("numeric(20, 3)");

                entity.Property(e => e.bidPrice)
                    .HasColumnType("numeric(20, 3)");

                entity.Property(e => e.contractPrice)
                    .HasColumnType("numeric(20, 3)");

                entity.Property(e => e.createdBy)
                    .HasMaxLength(50)
                    .HasColumnName("createBy");

                entity.Property(e => e.createdDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.currency)
                    .HasMaxLength(5);

                entity.Property(e => e.estimatedPrice)
                    .HasColumnType("numeric(20, 3)");

                entity.Property(e => e.lastDay)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.listEmpId)
                    .HasMaxLength(200).IsJson();

                entity.Property(e => e.modifiedBy)
                    .HasMaxLength(50);

                entity.Property(e => e.modifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.note).IsUnicode(true);

                entity.Property(e => e.packageBidName)
                    .HasMaxLength(500);

                entity.Property(e => e.projId).HasColumnName("ProjID");

                entity.Property(e => e.startDay)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.allowDisplay).HasDefaultValueSql("((1))");

                entity.Property(e => e.exchangeRate).HasColumnType("numeric(20, 3)");
            });

            modelBuilder.Entity<Contracts>(entity =>
            {
                entity.ToTable("Contracts", "pm");

                entity.Property(e => e.allowDisplay).HasDefaultValueSql("((1))");

                entity.Property(e => e.amountGuarOfWarranty)
                    .HasColumnType("numeric(20, 3)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.amountOfAdvGuar)
                    .HasColumnType("numeric(20, 3)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.amountOfMakeAdvGuar)
                    .HasColumnType("numeric(20, 3)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.contractClassification).HasMaxLength(250);

                entity.Property(e => e.contractCode).HasMaxLength(250);

                entity.Property(e => e.contractName).HasMaxLength(500);

                entity.Property(e => e.contractValue)
                    .HasColumnType("numeric(20, 3)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.createdBy)
                    .HasColumnName("createBy")
                    .HasMaxLength(50);

                entity.Property(e => e.createdDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.currency)
                    .HasMaxLength(10);

                entity.Property(e => e.dateOfAdvanceGuarantee).HasColumnType("datetime");

                entity.Property(e => e.dateOfMakeAdvGuar).HasColumnType("datetime");

                entity.Property(e => e.dateOfSignedDecision).HasColumnType("datetime");

                entity.Property(e => e.decisionNumber).HasMaxLength(100);

                entity.Property(e => e.deductibleValue)
                    .HasColumnType("numeric(20, 3)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.durationOfContract).HasDefaultValueSql("((0))");

                entity.Property(e => e.effectiveDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.endDateOfAdvGuar).HasColumnType("datetime");

                entity.Property(e => e.endDateOfMakeAdvGuar).HasColumnType("datetime");

                entity.Property(e => e.exchangeRate)
                    .HasColumnType("numeric(20, 3)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.expiryDate).HasColumnType("datetime");

                entity.Property(e => e.liquidationDay).HasColumnType("datetime");

                entity.Property(e => e.modifiedBy)
                    .HasMaxLength(50);

                entity.Property(e => e.modifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.note).HasMaxLength(500);

                entity.Property(e => e.percentAdvanceGuarantee).HasDefaultValueSql("((0))");

                entity.Property(e => e.percentGuarOfWarranty).HasDefaultValueSql("((0))");

                entity.Property(e => e.percentOfMakeAdvGuar).HasDefaultValueSql("((0))");

                entity.Property(e => e.persionInChange).HasMaxLength(500);

                entity.Property(e => e.signedOn).HasColumnType("datetime");

                entity.Property(e => e.warrantyEndDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TermsOfPayment>(entity =>
            {
                entity.ToTable("TermsOfPayment", "dm");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.data).HasColumnName("data").IsJson();

                entity.Property(e => e.dataDb).HasColumnName("dataDb").IsJson();
            });

            modelBuilder.Entity<PaymentType>(entity =>
            {
                entity.ToTable("PaymentType", "dm");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.data).HasColumnName("data").IsJson();

                entity.Property(e => e.dataDb).HasColumnName("dataDb").IsJson();
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.HasKey(e => e.iso)
                    .HasName("PK__Currency__DC5090748950CA34");

                entity.ToTable("Currency", "dm");

                entity.Property(e => e.iso)
                    .HasColumnName("iso")
                    .HasMaxLength(3)
                    .HasDefaultValueSql("('VND')");

                entity.Property(e => e.currencyName)
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<HandoverSchedule>(entity =>
            {
                entity.ToTable("HandoverSchedule", "pm");

                entity.Property(e => e.acceptanceValue)
                    .HasColumnType("numeric(20, 3)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.allowDisplay).HasDefaultValueSql("((1))");

                entity.Property(e => e.billDate).HasColumnType("datetime");

                entity.Property(e => e.billNumber)
                    .HasMaxLength(50);

                entity.Property(e => e.content)
                    .HasMaxLength(500);

                entity.Property(e => e.contractCodeBase)
                    .HasMaxLength(200);

                entity.Property(e => e.createdBy)
                    .HasMaxLength(50)
                    .HasColumnName("createBy");

                entity.Property(e => e.createdDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.endDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.estimatedValue)
                    .HasColumnType("numeric(20, 3)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.handoverClassification)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('tamtinh')");

                entity.Property(e => e.mass).HasDefaultValueSql("((0))");

                entity.Property(e => e.modifiedBy)
                    .HasMaxLength(50);

                entity.Property(e => e.modifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.note).IsUnicode(true);

                entity.Property(e => e.percentMass).HasDefaultValueSql("((0))");

                entity.Property(e => e.process)
                    .HasMaxLength(250);

                entity.Property(e => e.productName)
                    .HasMaxLength(500);

                entity.Property(e => e.startDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.estimatedDate)
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Crtype>(entity =>
            {
                entity.ToTable("Crtype", "dm");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.data).HasColumnName("data").IsJson();

                entity.Property(e => e.dataDb).HasColumnName("dataDb").IsJson();
            });

            modelBuilder.Entity<Files>(entity =>
            {
                entity.ToTable("Files", "stm");

                entity.Property(e => e.id)
                     .HasColumnName("id");

                entity.Property(e => e.data).HasColumnName("data").IsJson();

                entity.Property(e => e.dataDb).HasColumnName("dataDb").IsJson();

                entity.Property(e => e.source)
                    .HasColumnName("source");
            });

            modelBuilder.Entity<ExpectedCosts>(entity =>
            {
                entity.ToTable("ExpectedCosts", "pm");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.data).HasColumnName("data").IsJson();

                entity.Property(e => e.dataDb).HasColumnName("dataDb").IsJson();

                entity.Property(e => e.projectId).HasColumnName("ProjectId").HasComputedColumnSql("(CONVERT([int],json_value([data],'$.projectId')))");
            });

            modelBuilder.Entity<ModeBidding>(entity =>
            {
                entity.ToTable("ModeBidding", "dm");

                entity.Property(e => e.id).HasColumnName("ID");

                entity.Property(e => e.createby)
                    .HasColumnName("CREATEBY")
                    .HasMaxLength(150);

                entity.Property(e => e.createdate)
                    .HasColumnName("CREATEDATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.display)
                    .HasColumnName("DISPLAY")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.modebiddingindex)
                    .HasColumnName("MODEBIDDINGINDEX")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.modebiddingname)
                    .HasColumnName("MODEBIDDINGNAME")
                    .HasMaxLength(200);

                entity.Property(e => e.modifyby)
                    .HasColumnName("MODIFYBY")
                    .HasMaxLength(150);

                entity.Property(e => e.modifydate)
                    .HasColumnName("MODIFYDATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.note)
                    .HasColumnName("NOTE")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<StorageCabinets>(entity =>
            {
                entity.ToTable("StorageCabinets", "dm");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.data).HasColumnName("data").IsJson();

                entity.Property(e => e.dataDb).HasColumnName("dataDb").IsJson();
            });

            modelBuilder.Entity<FieldOfActivity>(entity =>
            {
                entity.ToTable("FieldOfActivity", "dm");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.data).HasColumnName("data").IsJson();

                entity.Property(e => e.dataDb).HasColumnName("dataDb").IsJson();
            });

            modelBuilder.Entity<ActualCosts>(entity =>
            {
                entity.ToTable("ActualCosts", "pm");

                entity.Property(e => e.id).HasColumnName("Id");

                entity.HasIndex(e => e.vouchersNumber)
                   .HasName("UQ__ActualCo__A3FFF1EA8DEC8373")
                   .IsUnique();

                entity.Property(e => e.data).HasColumnName("data").IsJson();

                entity.Property(e => e.dataDb).HasColumnName("dataDb").IsJson();
            });

            modelBuilder.Entity<CollateCosts>(entity =>
            {
                entity.ToTable("CollateCosts", "pm");

                entity.Property(e => e.id).HasColumnName("Id");

                entity.HasIndex(e => e.vouchersNumber)
                   .HasName("UQ__CollateC__A3FFF1EAE4A7A3AA")
                   .IsUnique();

                entity.Property(e => e.data).HasColumnName("data").IsJson();

                entity.Property(e => e.dataDb).HasColumnName("dataDb").IsJson();
            });

            modelBuilder.Entity<Revenues>(entity =>
            {
                entity.ToTable("Revenues", "pm");

                entity.Property(e => e.id).HasColumnName("Id");

                entity.HasIndex(e => e.vouchersNumber)
                   .HasName("UQ__Revenues__A3FFF1EAB70B4294")
                   .IsUnique();

                entity.Property(e => e.data).HasColumnName("data").IsJson();

                entity.Property(e => e.dataDb).HasColumnName("dataDb").IsJson();
            });

            modelBuilder.Entity<TimeSheet>(entity =>
            {
                entity.ToTable("TimeSheet", "pm");

                entity.Property(e => e.cn)
                    .HasColumnName("CN")
                    .HasColumnType("numeric(10, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.dateNumber).HasDefaultValueSql("((0))");

                entity.Property(e => e.endDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.startDay)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.t2)
                    .HasColumnType("numeric(10, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.t3)
                    .HasColumnType("numeric(10, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.t4)
                    .HasColumnType("numeric(10, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.t5)
                    .HasColumnType("numeric(10, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.t6)
                    .HasColumnType("numeric(10, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.t7)
                    .HasColumnType("numeric(10, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.topic)
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<CompanyInfo>(entity =>
            {
                entity.ToTable("CompanyInfo", "cat");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.businessTypeId).HasColumnName("businessTypeId");

                entity.Property(e => e.companyCode)
                    .HasColumnName("companyCode")
                    .HasMaxLength(50);

                entity.Property(e => e.companyName)
                    .HasColumnName("companyName")
                    .HasMaxLength(500);

                entity.Property(e => e.data).HasColumnName("data").IsJson();

                entity.Property(e => e.dataBank).HasColumnName("dataBank").IsJson();

                entity.Property(e => e.dataContact).HasColumnName("dataContact").IsJson();

                entity.Property(e => e.dataDb).HasColumnName("dataDb").IsJson();

                entity.Property(e => e.parentId).HasColumnName("parentId");

                entity.Property(e => e.shortName)
                    .HasColumnName("shortName")
                    .HasMaxLength(500);

                entity.Property(e => e.tradingName)
                    .HasColumnName("tradingName")
                    .HasMaxLength(500);

                entity.Property(e => e.typeId).HasColumnName("typeId");

                entity.HasOne(d => d.BusinessType)
                    .WithMany(p => p.CompanyInfo)
                    .HasForeignKey(d => d.businessTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CompanyIn__busin__76969D2E");
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.ToTable("Employees", "hrm");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.accuracy).HasColumnName("accuracy").IsJson();

                entity.Property(e => e.army).HasColumnName("army").IsJson();

                entity.Property(e => e.basic).HasColumnName("basic").IsJson();

                entity.Property(e => e.contact).HasColumnName("contact").IsJson();

                entity.Property(e => e.dataDb).HasColumnName("dataDb").IsJson();

                entity.Property(e => e.files).HasColumnName("files").IsJson();

                entity.Property(e => e.finance).HasColumnName("finance").IsJson();

                entity.Property(e => e.health).HasColumnName("health").IsJson();

                entity.Property(e => e.relationships).HasColumnName("relationships").IsJson();

                entity.Property(e => e.federation).HasColumnName("federation").IsJson();

                entity.Property(e => e.partyDelegation).HasColumnName("partyDelegation").IsJson();

                entity.Property(e => e.revolutionaryHistory).HasColumnName("revolutionaryHistory").IsJson();

                entity.Property(e => e.story).HasColumnName("story").IsJson();

                entity.Property(e => e.contracts).HasColumnName("contracts").IsJson();

                entity.Property(e => e.jobs).HasColumnName("jobs").IsJson();

                entity.Property(e => e.capacityProfile).HasColumnName("capacityProfile").IsJson();

            });

            modelBuilder.Entity<TypeOfBusiness>(entity =>
            {
                entity.ToTable("TypeOfBusiness", "cat");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.data).HasColumnName("data").IsJson();

                entity.Property(e => e.dataDb).HasColumnName("dataDb").IsJson();
            });

            modelBuilder.Entity<PaymentSchedule>(entity =>
            {
                entity.ToTable("PaymentSchedule", "pm");

                entity.Property(e => e.allowDisplay).HasDefaultValueSql("((1))");

                entity.Property(e => e.amountOfMoney)
                    .HasColumnType("numeric(20, 3)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.appointmentDate).HasColumnType("datetime");

                entity.Property(e => e.bonusRatio).HasDefaultValueSql("((0))");

                entity.Property(e => e.createdBy)
                    .HasColumnName("createBy")
                    .HasMaxLength(50);

                entity.Property(e => e.createdDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.explain).IsUnicode(true);

                entity.Property(e => e.modifiedBy)
                    .HasMaxLength(50);

                entity.Property(e => e.modifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.note).IsUnicode(true);

                entity.Property(e => e.productCode).IsUnicode(true);

                entity.Property(e => e.numberOfBonusDays).HasDefaultValueSql("((0))");

                entity.Property(e => e.numberOfDay).HasDefaultValueSql("((0))");

                entity.Property(e => e.numberOfPenaltyDays).HasDefaultValueSql("((0))");

                entity.Property(e => e.penaltyDate).HasColumnType("datetime");

                entity.Property(e => e.penaltyRate).HasDefaultValueSql("((0))");

                entity.Property(e => e.rewardDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TimeSheetDetail>(entity =>
            {
                entity.ToTable("TimeSheetDetail", "pm");

                entity.Property(e => e.dataDb).HasColumnName("dataDb").IsJson();

                entity.Property(e => e.days).HasColumnName("days").IsJson();

                entity.Property(e => e.timeSheetId).HasColumnName("TimeSheetID");

                entity.Property(e => e.times).HasColumnName("times").IsJson();
            });

        }
    }
}
