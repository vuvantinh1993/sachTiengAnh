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
        public virtual DbSet<Acttachments> Acttachments { get; set; }
        public virtual DbSet<Files> Files { get; set; }

        public virtual DbSet<Categoryfilm> Categoryfilm { get; set; }
        public virtual DbSet<Extraone> Easy { get; set; }
        public virtual DbSet<Tips> Tips { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Extraone> Extraone { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=TINHVV_DES\\SQLEXPRESS;Database=TLNEnglish;user id=sa;password=123456;Trusted_Connection=False;");
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

            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity<Acttachments>(entity =>
            {
                entity.ToTable("Acttachments", "pm");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.fileData).HasColumnName("FileData").IsJson();

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

            modelBuilder.Entity<Categoryfilm>(entity =>
            {
                entity.ToTable("categoryfilm");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.dataDb)
                    .HasColumnName("dataDb")
                    .HasMaxLength(100)
                    .IsUnicode(false).IsJson();

                entity.Property(e => e.level).HasColumnName("level");

                entity.Property(e => e.pointword).HasColumnName("pointword");

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Extraone>(entity =>
            {
                entity.ToTable("extraone");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.audioanswer)
                    .IsRequired()
                    .HasColumnName("audioanswer")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.audioquestion)
                    .IsRequired()
                    .HasColumnName("audioquestion")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.categoryfilmid).HasColumnName("categoryfilmid");

                entity.Property(e => e.dataDb)
                    .HasColumnName("dataDb")
                    .HasMaxLength(100)
                    .IsUnicode(false).IsJson();

                entity.Property(e => e.doubtid)
                    .HasColumnName("doubtid")
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.textanswer)
                    .IsRequired()
                    .HasColumnName("textanswer")
                    .HasMaxLength(100);

                entity.Property(e => e.textquestion)
                    .IsRequired()
                    .HasColumnName("textquestion")
                    .HasMaxLength(100);

                entity.Property(e => e.unselectid)
                    .HasColumnName("unselectid")
                    .HasMaxLength(70)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tips>(entity =>
            {
                entity.ToTable("tips");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.content)
                    .IsRequired()
                    .HasColumnName("content")
                    .HasMaxLength(100);

                entity.Property(e => e.dataDb)
                   .HasColumnName("dataDb")
                   .HasMaxLength(100)
                   .IsUnicode(false).IsJson();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.dataDb)
                    .HasColumnName("dataDb")
                    .HasMaxLength(100)
                    .IsUnicode(false).IsJson();

                entity.Property(e => e.email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.filmleanning)
                    .HasColumnName("filmleanning")
                    .IsUnicode(false).IsJson();

                entity.Property(e => e.listfrendid)
                    .HasColumnName("listfrendid")
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.phone)
                    .HasColumnName("phone")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.point).HasColumnName("point");
            });

        }
    }
}
