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
        public virtual DbSet<Tips> Tips { get; set; }
        public virtual DbSet<User> User { get; set; }

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
            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity<Categoryfilm>(entity =>
            {
                entity.ToTable("categoryfilm");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DataDb)
                    .HasColumnName("dataDb")
                    .HasMaxLength(100)
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

                entity.Property(e => e.Audioanswer)
                    .IsRequired()
                    .HasColumnName("audioanswer")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Audioquestion)
                    .IsRequired()
                    .HasColumnName("audioquestion")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Categoryfilmid).HasColumnName("categoryfilmid");

                entity.Property(e => e.DataDb)
                    .HasColumnName("dataDb")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Doubtid)
                    .HasColumnName("doubtid")
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Textanswer)
                    .IsRequired()
                    .HasColumnName("textanswer")
                    .HasMaxLength(100);

                entity.Property(e => e.Textquestion)
                    .IsRequired()
                    .HasColumnName("textquestion")
                    .HasMaxLength(100);

                entity.Property(e => e.Unselectid)
                    .HasColumnName("unselectid")
                    .HasMaxLength(70)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tips>(entity =>
            {
                entity.ToTable("tips");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnName("content")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DataDb)
                    .HasColumnName("dataDb")
                    .HasMaxLength(100)
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
