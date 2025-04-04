using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SmartFitness.Models;

public partial class DbSmartFitness1Context : DbContext
{
    public DbSmartFitness1Context()
    {
    }

    public DbSmartFitness1Context(DbContextOptions<DbSmartFitness1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Membership> Memberships { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<ScheduleWeekday> ScheduleWeekdays { get; set; }

    public virtual DbSet<Trainer> Trainers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=Y3_MAX\\SQLEXPRESS;Initial Catalog=DB_Smart_Fitness_1;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("PK__Clients__BF21A424F06864A7");

            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.BirthDate).HasColumnName("birth_date");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("first_name");
            entity.Property(e => e.Group).HasColumnName("group");
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("last_name");
            entity.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(16)
                .HasColumnName("phone");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.Unassigned)
                .HasDefaultValue(0)
                .HasColumnName("unassigned");

            entity.HasOne(d => d.GroupNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.Group)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ClientsGroups");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.GroupId).HasName("PK__Groups__D57795A0274390C0");

            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.Description)
                .HasMaxLength(150)
                .HasColumnName("description");
            entity.Property(e => e.FreeSeats)
                .HasDefaultValue(15)
                .HasColumnName("free_seats");
            entity.Property(e => e.GroupName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("group_name");
            entity.Property(e => e.ScheduleTime).HasColumnName("schedule_time");
            entity.Property(e => e.ScheduleWeekday).HasColumnName("schedule_weekday");
            entity.Property(e => e.Trainer).HasColumnName("trainer");

            entity.HasOne(d => d.ScheduleWeekdayNavigation).WithMany(p => p.Groups)
                .HasForeignKey(d => d.ScheduleWeekday)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GroupsSchedule_weekdays");

            entity.HasOne(d => d.TrainerNavigation).WithMany(p => p.Groups)
                .HasForeignKey(d => d.Trainer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GroupsTrainers");
        });

        modelBuilder.Entity<Membership>(entity =>
        {
            entity.HasKey(e => e.MembershipId).HasName("PK__Membersh__CAE49DDD3F007637");

            entity.Property(e => e.MembershipId).HasColumnName("membership_id");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.MembershipType)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("membership_type");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("price");
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasKey(e => new { e.Date, e.Time }).HasName("PK__Schedule__A7A1B612BBAB492D");

            entity.ToTable("Schedule");

            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Time).HasColumnName("time");
            entity.Property(e => e.Group).HasColumnName("group");
            entity.Property(e => e.Spent).HasColumnName("spent");

            entity.HasOne(d => d.GroupNavigation).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.Group)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Schedule_Groups");
        });

        modelBuilder.Entity<ScheduleWeekday>(entity =>
        {
            entity.HasKey(e => e.ScheduleWeekdayId).HasName("PK__Schedule__4C64AC56138DFE48");

            entity.ToTable("Schedule_weekdays");

            entity.Property(e => e.ScheduleWeekdayId).HasColumnName("schedule_weekday_id");
            entity.Property(e => e.ScheduleWeekdayType)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("schedule_weekday_type");
        });

        modelBuilder.Entity<Trainer>(entity =>
        {
            entity.HasKey(e => e.TrainerId).HasName("PK__Trainers__65A4B62990F9AE83");

            entity.Property(e => e.TrainerId).HasColumnName("trainer_id");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("last_name");
            entity.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(16)
                .HasColumnName("phone");
            entity.Property(e => e.Specialization)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("specialization");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
