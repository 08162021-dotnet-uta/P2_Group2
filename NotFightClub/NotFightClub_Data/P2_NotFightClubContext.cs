using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using NotFightClub_Models.Models;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace NotFightClub_Data
{
  public partial class P2_NotFightClubContext : DbContext
  {
    public P2_NotFightClubContext()
    {
    }

    public P2_NotFightClubContext(DbContextOptions<P2_NotFightClubContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Character> Characters { get; set; }
    public virtual DbSet<Comment> Comments { get; set; }
    public virtual DbSet<Fight> Fights { get; set; }
    public virtual DbSet<Fighter> Fighters { get; set; }
    public virtual DbSet<Location> Locations { get; set; }
    public virtual DbSet<Trait> Traits { get; set; }
    public virtual DbSet<UserInfo> UserInfos { get; set; }
    public virtual DbSet<Wager> Wagers { get; set; }
    public virtual DbSet<Weapon> Weapons { get; set; }
    public virtual DbSet<Weather> Weathers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //optionsBuilder.UseSqlServer("Server=08162021dotnetuta.database.windows.net;Database=P2_NotFightClub;User Id=sqladmin;Password=Password12345;");
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=P2_NotFightClub;Trusted_Connection=True;");
      }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

      modelBuilder.Entity<Character>(entity =>
      {
        entity.ToTable("Character");

        entity.Property(e => e.Baseform).HasMaxLength(100);

        entity.Property(e => e.Name)
                  .IsRequired()
                  .HasMaxLength(100);

        entity.HasOne(d => d.Trait)
                  .WithMany(p => p.Characters)
                  .HasForeignKey(d => d.TraitId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK__Character__Trait__2D27B809");

        entity.HasOne(d => d.User)
                  .WithMany(p => p.Characters)
                  .HasForeignKey(d => d.UserId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK__Character__UserI__2C3393D0");

        entity.HasOne(d => d.Weapon)
                  .WithMany(p => p.Characters)
                  .HasForeignKey(d => d.WeaponId)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK__Character__Weapo__2E1BDC42");
      });

      modelBuilder.Entity<Comment>(entity =>
      {
        entity.ToTable("Comment");

        entity.Property(e => e.Comment1)
                  .HasMaxLength(1000)
                  .HasColumnName("Comment");

        entity.Property(e => e.Date)
                  .HasColumnType("date")
                  .HasDefaultValueSql("(getdate())");

        entity.HasOne(d => d.Fight)
                  .WithMany(p => p.Comments)
                  .HasForeignKey(d => d.FightId)
                  .OnDelete(DeleteBehavior.Cascade)
                  .HasConstraintName("FK__Comment__FightId__44FF419A");

        entity.HasOne(d => d.ParentcommentNavigation)
                  .WithMany(p => p.InverseParentcommentNavigation)
                  .HasForeignKey(d => d.Parentcomment)
                  .HasConstraintName("FK__Comment__Parentc__47DBAE45");

        entity.HasOne(d => d.User)
                  .WithMany(p => p.Comments)
                  .HasForeignKey(d => d.UserId)
                  .HasConstraintName("FK__Comment__UserId__45F365D3");
      });

      modelBuilder.Entity<Fight>(entity =>
      {
        entity.ToTable("Fight");

        entity.Property(e => e.Date)
                  .HasColumnType("date")
                  .HasDefaultValueSql("(getdate())");

        entity.Property(e => e.Result).HasMaxLength(300);

        entity.HasOne(d => d.LocationNavigation)
                  .WithMany(p => p.Fights)
                  .HasForeignKey(d => d.Location)
                  .HasConstraintName("FK__Fight__Location__3D5E1FD2");

        entity.HasOne(d => d.LoserNavigation)
                  .WithMany(p => p.FightLoserNavigations)
                  .HasForeignKey(d => d.Loser)
                  .HasConstraintName("FK__Fight__Loser__3B75D760");

        entity.HasOne(d => d.WeatherNavigation)
                  .WithMany(p => p.Fights)
                  .HasForeignKey(d => d.Weather)
                  .HasConstraintName("FK__Fight__Weather__3E52440B");

        entity.HasOne(d => d.WinnerNavigation)
                  .WithMany(p => p.FightWinnerNavigations)
                  .HasForeignKey(d => d.Winner)
                  .HasConstraintName("FK__Fight__Winner__3A81B327");
      });

      modelBuilder.Entity<Fighter>(entity =>
      {
        entity.ToTable("Fighter");

        entity.HasOne(d => d.Character)
                  .WithMany(p => p.Fighters)
                  .HasForeignKey(d => d.CharacterId)
                  .HasConstraintName("FK__Fighter__Charact__4222D4EF");

        entity.HasOne(d => d.Fight)
                  .WithMany(p => p.Fighters)
                  .HasForeignKey(d => d.FightId)
                  .HasConstraintName("FK__Fighter__FightId__412EB0B6");
      });

      modelBuilder.Entity<Location>(entity =>
      {
        entity.ToTable("Location");

        entity.Property(e => e.Location1)
                  .IsRequired()
                  .HasMaxLength(100)
                  .HasColumnName("Location");
      });

      modelBuilder.Entity<Trait>(entity =>
      {
        entity.ToTable("Trait");

        entity.Property(e => e.Description).HasMaxLength(300);
      });

      modelBuilder.Entity<UserInfo>(entity =>
      {
        entity.HasKey(e => e.UserId)
                  .HasName("PK__UserInfo__1788CC4CD411C4DF");

        entity.ToTable("UserInfo");

        entity.Property(e => e.UserId).HasDefaultValueSql("(newid())");

        entity.Property(e => e.Bucks).HasDefaultValueSql("((20))");

        entity.Property(e => e.Dob)
                  .HasColumnType("date")
                  .HasColumnName("DOB");

        entity.Property(e => e.Email).HasMaxLength(50);

        entity.Property(e => e.Pword)
                  .IsRequired()
                  .HasMaxLength(100)
                  .HasColumnName("PWord");

        entity.Property(e => e.UserName)
                  .IsRequired()
                  .HasMaxLength(50);
      });

      modelBuilder.Entity<Wager>(entity =>
      {
        entity.ToTable("Wager");

        entity.HasOne(d => d.Fight)
                  .WithMany(p => p.Wagers)
                  .HasForeignKey(d => d.FightId)
                  .OnDelete(DeleteBehavior.Cascade)
                  .HasConstraintName("FK__Wager__FightId__4BAC3F29");

        entity.HasOne(d => d.Fighter)
                  .WithMany(p => p.Wagers)
                  .HasForeignKey(d => d.FighterId)
                  .HasConstraintName("FK__Wager__FighterId__4CA06362");

        entity.HasOne(d => d.User)
                  .WithMany(p => p.Wagers)
                  .HasForeignKey(d => d.UserId)
                  .HasConstraintName("FK__Wager__UserId__4AB81AF0");
      });

      modelBuilder.Entity<Weapon>(entity =>
      {
        entity.ToTable("Weapon");

        entity.Property(e => e.Description).HasMaxLength(300);
      });

      modelBuilder.Entity<Weather>(entity =>
      {
        entity.ToTable("Weather");

        entity.Property(e => e.Description)
                  .IsRequired()
                  .HasMaxLength(100);
      });

      OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
  }
}
