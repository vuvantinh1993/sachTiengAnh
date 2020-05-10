using CTIN.DataAccess.Bases;
using CTIN.DataAccess.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query.Expressions;

namespace CTIN.DataAccess.Contexts
{
    public partial class NATemplateContext : IdentityDbContext<ApplicationUser>
    {
        public NATemplateContext(DbContextOptions<NATemplateContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Acttachments> Acttachments { get; set; }
        public virtual DbSet<Files> Files { get; set; }
        public virtual DbSet<Categoryfilm> Categoryfilm { get; set; }
        public virtual DbSet<Tips> Tips { get; set; }
        public virtual DbSet<UserLeanning> UserLeanning { get; set; }
        public virtual DbSet<Extraone> Extraone { get; set; }
        public virtual DbSet<Rank> Rank { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
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
                    .IsUnicode(false).IsJson();

                entity.Property(e => e.level).HasColumnName("level");

                entity.Property(e => e.pointword).HasColumnName("pointword");

                entity.Property(e => e.discription).HasColumnName("discription");

                entity.Property(e => e.linkImg).HasColumnName("linkImg");

                entity.Property(e => e.totalWord).HasColumnName("totalWord");

                entity.Property(e => e.totalUser).HasColumnName("totalUser").HasDefaultValue(0);

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

            });

            modelBuilder.Entity<Extraone>(entity =>
            {
                entity.ToTable("extraone");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.audio)
                    .HasColumnName("audio");

                entity.Property(e => e.dataDb)
                    .HasColumnName("dataDb")
                    .HasMaxLength(200)
                    .IsUnicode(false).IsJson();

                entity.Property(e => e.doubtid)
                    .HasColumnName("doubtid")
                    .HasMaxLength(70)
                    .IsUnicode(false).IsJson();

                entity.Property(e => e.textVn)
                    .HasColumnName("textVn")
                    .HasMaxLength(500);

                entity.Property(e => e.fullName)
                    .HasColumnName("fullname")
                    .HasMaxLength(500);

                entity.Property(e => e.textEn)
                    .HasColumnName("textEn")
                    .HasMaxLength(500);

                entity.Property(e => e.unselectid)
                    .HasColumnName("unselectid")
                    .HasMaxLength(70)
                    .IsUnicode(false).IsJson();

                entity.Property(e => e.urlaudio)
                    .HasColumnName("urlaudio")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.answerWrongEn).HasColumnName("answerWrongEn");

                entity.Property(e => e.answerWrongVn).HasColumnName("answerWrongVn");
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
                   .HasMaxLength(200)
                   .IsUnicode(false).IsJson();
            });

            modelBuilder.Entity<UserLeanning>(entity =>
            {
                entity.ToTable("userLeanning");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.dataDb)
                    .HasColumnName("dataDb")
                    .HasMaxLength(200)
                    .IsUnicode(false).IsJson();

                entity.Property(e => e.filmforgeted).HasColumnName("filmforgeted").IsJson();

                entity.Property(e => e.filmleanning).HasColumnName("filmleanning").IsJson();

                entity.Property(e => e.filmpunishing).HasColumnName("filmpunishing").IsJson();

                entity.Property(e => e.filmfinish).HasColumnName("filmfinish").IsJson();

                entity.Property(e => e.listfrendid)
                    .HasColumnName("listfrendid")
                    .IsUnicode(false).IsJson();

                entity.Property(e => e.point).HasColumnName("point").HasDefaultValue(0);


            });

            modelBuilder.Entity<Rank>(entity =>
            {
                entity.ToTable("rank");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.dataDb)
                    .HasColumnName("dataDb")
                    .HasMaxLength(200)
                    .IsUnicode(false).IsJson();

                entity.Property(e => e.name).HasColumnName("name");

                entity.Property(e => e.pointStage).HasColumnName("pointStage");
            });
        }
    }
}
