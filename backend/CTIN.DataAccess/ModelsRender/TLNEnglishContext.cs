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

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Categoryfilm> Categoryfilm { get; set; }
        public virtual DbSet<Extraone> Extraone { get; set; }
        public virtual DbSet<Files> Files { get; set; }
        public virtual DbSet<Tips> Tips { get; set; }
        public virtual DbSet<UserLeanning> UserLeanning { get; set; }
        public virtual DbSet<Users> Users { get; set; }

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

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Discriminator).IsRequired();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.FullName).HasMaxLength(150);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Categoryfilm>(entity =>
            {
                entity.ToTable("categoryfilm");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DataDb)
                    .HasColumnName("dataDb")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Discription).HasColumnName("discription");

                entity.Property(e => e.Level).HasColumnName("level");

                entity.Property(e => e.LinkImg)
                    .HasColumnName("linkImg")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Pointword).HasColumnName("pointword");

                entity.Property(e => e.TotalUser).HasColumnName("totalUser");

                entity.Property(e => e.TotalWord).HasColumnName("totalWord");
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

                entity.Property(e => e.Size).HasColumnName("size");

                entity.Property(e => e.Stt).HasColumnName("stt");

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

            modelBuilder.Entity<UserLeanning>(entity =>
            {
                entity.ToTable("userLeanning");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DataDb)
                    .HasColumnName("dataDb")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Filmfinish).HasColumnName("filmfinish");

                entity.Property(e => e.Filmforgeted).HasColumnName("filmforgeted");

                entity.Property(e => e.Filmleanning).HasColumnName("filmleanning");

                entity.Property(e => e.Filmpunishing).HasColumnName("filmpunishing");

                entity.Property(e => e.Information)
                    .HasColumnName("information")
                    .HasMaxLength(500);

                entity.Property(e => e.Listfrendid)
                    .HasColumnName("listfrendid")
                    .IsUnicode(false);

                entity.Property(e => e.Point).HasColumnName("point");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Birthday).HasColumnName("birthday");

                entity.Property(e => e.DataDb).HasColumnName("dataDB");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500);

                entity.Property(e => e.LatestLogin).HasColumnName("latestLogin");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.NickName)
                    .IsRequired()
                    .HasColumnName("nickName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasColumnName("userPassword")
                    .HasMaxLength(50);
            });
        }
    }
}
