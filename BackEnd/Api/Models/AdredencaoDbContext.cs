using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Api.Models;

public partial class AdredencaoDbContext : DbContext
{
    public AdredencaoDbContext()
    {
    }

    public AdredencaoDbContext(DbContextOptions<AdredencaoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<AddressChurch> AddressChurches { get; set; }

    public virtual DbSet<AddressEvent> AddressEvents { get; set; }

    public virtual DbSet<Church> Churches { get; set; }

    public virtual DbSet<EcclesiasticalPosition> EcclesiasticalPositions { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<LogsDelete> LogsDeletes { get; set; }

    public virtual DbSet<LogsException> LogsExceptions { get; set; }

    public virtual DbSet<LogsInsert> LogsInserts { get; set; }

    public virtual DbSet<LogsUpdate> LogsUpdates { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Telephone> Telephones { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=adredencao_db;user=admin;password=@Asdf7513a", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.34-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("address");

            entity.HasIndex(e => e.UserId, "fk_user_id_idx");

            entity.HasIndex(e => e.Id, "id_UNIQUE").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AddOnAddress)
                .HasMaxLength(45)
                .HasColumnName("add_on_address");
            entity.Property(e => e.City)
                .HasMaxLength(45)
                .HasColumnName("city");
            entity.Property(e => e.District)
                .HasMaxLength(45)
                .HasColumnName("district");
            entity.Property(e => e.Number)
                .HasMaxLength(45)
                .HasColumnName("number");
            entity.Property(e => e.State)
                .HasMaxLength(45)
                .HasColumnName("state");
            entity.Property(e => e.Street)
                .HasMaxLength(45)
                .HasColumnName("street");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.ZipCode)
                .HasMaxLength(45)
                .HasColumnName("zip_code");

            entity.HasOne(d => d.User).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user_id");
        });

        modelBuilder.Entity<AddressChurch>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("address_churches");

            entity.HasIndex(e => e.ChurcheId, "fk_churche_id_idx");

            entity.HasIndex(e => e.Id, "id_UNIQUE").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AddOnAddress)
                .HasMaxLength(45)
                .HasColumnName("add_on_address");
            entity.Property(e => e.ChurcheId).HasColumnName("churche_id");
            entity.Property(e => e.City)
                .HasMaxLength(45)
                .HasColumnName("city");
            entity.Property(e => e.District)
                .HasMaxLength(45)
                .HasColumnName("district");
            entity.Property(e => e.Number)
                .HasMaxLength(45)
                .HasColumnName("number");
            entity.Property(e => e.State)
                .HasMaxLength(45)
                .HasColumnName("state");
            entity.Property(e => e.Street)
                .HasMaxLength(45)
                .HasColumnName("street");
            entity.Property(e => e.ZipCode)
                .HasMaxLength(45)
                .HasColumnName("zip_code");

            entity.HasOne(d => d.Churche).WithMany(p => p.AddressChurches)
                .HasForeignKey(d => d.ChurcheId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_churche_id");
        });

        modelBuilder.Entity<AddressEvent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("address_events");

            entity.HasIndex(e => e.EventId, "fk_event_id_idx");

            entity.HasIndex(e => e.Id, "id_UNIQUE").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AddOnAddress)
                .HasMaxLength(45)
                .HasColumnName("add_on_address");
            entity.Property(e => e.City)
                .HasMaxLength(45)
                .HasColumnName("city");
            entity.Property(e => e.District)
                .HasMaxLength(45)
                .HasColumnName("district");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.Number)
                .HasMaxLength(45)
                .HasColumnName("number");
            entity.Property(e => e.State)
                .HasMaxLength(45)
                .HasColumnName("state");
            entity.Property(e => e.Street)
                .HasMaxLength(45)
                .HasColumnName("street");
            entity.Property(e => e.ZipCode)
                .HasMaxLength(45)
                .HasColumnName("zip_code");

            entity.HasOne(d => d.Event).WithMany(p => p.AddressEvents)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_event_id");
        });

        modelBuilder.Entity<Church>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("churches");

            entity.HasIndex(e => e.Id, "id_UNIQUE").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Churche)
                .HasMaxLength(45)
                .HasColumnName("churche");
        });

        modelBuilder.Entity<EcclesiasticalPosition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("ecclesiastical_positions");

            entity.HasIndex(e => e.Id, "id_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Name, "name_UNIQUE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("events");

            entity.HasIndex(e => e.ChurcheId, "churche_id_idx");

            entity.HasIndex(e => e.Id, "id_UNIQUE").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ChurcheId).HasColumnName("churche_id");
            entity.Property(e => e.DateHour)
                .HasColumnType("datetime")
                .HasColumnName("date_hour");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Title)
                .HasMaxLength(45)
                .HasColumnName("title");

            entity.HasOne(d => d.Churche).WithMany(p => p.Events)
                .HasForeignKey(d => d.ChurcheId)
                .HasConstraintName("churche_id");
        });

        modelBuilder.Entity<LogsDelete>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("logs_deletes");

            entity.HasIndex(e => e.UserId, "fk_user_id_idx");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.LogsDeletes)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user_id1");
        });

        modelBuilder.Entity<LogsException>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("logs_exceptions");

            entity.HasIndex(e => e.UserId, "fk_user_id_idx");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CompleteException)
                .HasColumnType("text")
                .HasColumnName("complete_exception");
            entity.Property(e => e.SummaryException)
                .HasMaxLength(255)
                .HasColumnName("summary_exception");
            entity.Property(e => e.TitleException)
                .HasMaxLength(255)
                .HasColumnName("title_exception");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.LogsExceptions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user_id10");
        });

        modelBuilder.Entity<LogsInsert>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("logs_inserts");

            entity.HasIndex(e => e.UserId, "fk_user_id_idx");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.LogsInserts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user_id_loginsert");
        });

        modelBuilder.Entity<LogsUpdate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("logs_updates");

            entity.HasIndex(e => e.UserId, "fk_user_id_idx");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.LogsUpdates)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user_id0");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("roles");

            entity.HasIndex(e => e.Id, "id_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Name, "name_UNIQUE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Telephone>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("telephones");

            entity.HasIndex(e => e.UserId, "fk_user_id_idx");

            entity.HasIndex(e => e.Id, "id_UNIQUE").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Telephone1)
                .HasMaxLength(45)
                .HasColumnName("telephone");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Telephones)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_userid");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("users");

            entity.HasIndex(e => e.Cpf, "cpf_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Email, "email_UNIQUE").IsUnique();

            entity.HasIndex(e => e.EcclesiasticalPositionId, "fk_ecclesiatical_posicional_idx");

            entity.HasIndex(e => e.RoleId, "fk_roles_idx");

            entity.HasIndex(e => e.Id, "id_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Rg, "rg_UNIQUE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cpf)
                .HasMaxLength(15)
                .HasColumnName("cpf");
            entity.Property(e => e.DateOfBaptism).HasColumnName("date_of_baptism");
            entity.Property(e => e.DateOfBirth).HasColumnName("date_of_birth");
            entity.Property(e => e.DateOfUnion).HasColumnName("date_of_union");
            entity.Property(e => e.EcclesiasticalPositionId).HasColumnName("ecclesiastical_position_id");
            entity.Property(e => e.Education).HasColumnName("education");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .HasColumnName("email");
            entity.Property(e => e.Employed).HasColumnName("employed");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.IsALeader).HasColumnName("is_a_leader");
            entity.Property(e => e.MaritalStatus).HasColumnName("marital_status");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.NameComplete)
                .HasMaxLength(45)
                .HasColumnName("name_complete");
            entity.Property(e => e.NameFather)
                .HasMaxLength(45)
                .HasColumnName("name_father");
            entity.Property(e => e.NameMother)
                .HasMaxLength(45)
                .HasColumnName("name_mother");
            entity.Property(e => e.Profession)
                .HasMaxLength(45)
                .HasColumnName("profession");
            entity.Property(e => e.Rg)
                .HasMaxLength(15)
                .HasColumnName("rg");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.Situation).HasColumnName("situation");

            entity.HasOne(d => d.EcclesiasticalPosition).WithMany(p => p.Users)
                .HasForeignKey(d => d.EcclesiasticalPositionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ecclesiatical_posicional");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_roles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
