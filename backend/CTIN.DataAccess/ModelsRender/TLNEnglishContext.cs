using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CTIN.DataAccess.ModelsRender
{
    public partial class TLNEnglishContext : DbContext
    {
        public TLNEnglishContext()
        {
        }

        public TLNEnglishContext(DbContextOptions<TLNEnglishContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoryfilm> Categoryfilm { get; set; }
        public virtual DbSet<Extraone> Extraone { get; set; }
        public virtual DbSet<Files> Files { get; set; }
        public virtual DbSet<Tips> Tips { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-VKP9EEJ\\VUVANTINH;Database=TLNEnglish;user id=sa;password=123456;Trusted_Connection=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity<Categoryfilm>(entity =>
            {
                entity.ToTable("categoryfilm");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DataDb)
                    .HasColumnName("dataDb")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Level).HasColumnName("level");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Pointword).HasColumnName("pointword");
            });

            modelBuilder.Entity<Extraone>(entity =>
            {
                entity.ToTable("extraone");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AnswerWrongEn).HasColumnName("answerWrongEn");

                entity.Property(e => e.AnswerWrongVn).HasColumnName("answerWrongVn");

                entity.Property(e => e.Audio).HasColumnName("audio");

                entity.Property(e => e.Categoryfilmid).HasColumnName("categoryfilmid");

                entity.Property(e => e.DataDb)
                    .HasColumnName("dataDb")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Doubtid)
                    .HasColumnName("doubtid")
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Fullname)
                    .HasColumnName("fullname")
                    .HasMaxLength(500);

                entity.Property(e => e.TextEn)
                    .HasColumnName("textEn")
                    .HasMaxLength(500);

                entity.Property(e => e.TextVn)
                    .HasColumnName("textVn")
                    .HasMaxLength(500);

                entity.Property(e => e.Unselectid)
                    .HasColumnName("unselectid")
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Urlaudio)
                    .HasColumnName("urlaudio")
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Files>(entity =>
            {
                entity.ToTable("files");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.DataDb)
                    .HasColumnName("dataDb")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasColumnName("source")
                    .HasMaxLength(1);
            });

            modelBuilder.Entity<Tips>(entity =>
            {
                entity.ToTable("tips");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnName("content")
                    .HasMaxLength(100);

                entity.Property(e => e.DataDb)
                    .HasColumnName("dataDb")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DataDb)
                    .HasColumnName("dataDb")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Filmleanning)
                    .HasColumnName("filmleanning")
                    .IsUnicode(false);

                entity.Property(e => e.Listfrendid)
                    .HasColumnName("listfrendid")
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Point).HasColumnName("point");
            });
        }
    }
}
