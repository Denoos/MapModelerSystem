using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Grido.Models;

public partial class QwertyContext : DbContext
{
    public QwertyContext()
    {
    }

    public QwertyContext(DbContextOptions<QwertyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Map> Maps { get; set; }

    public virtual DbSet<Object> Objects { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=192.168.200.13;user=student;password=student;database=_qwerty", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.3.39-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Map>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("maps");

            entity.HasIndex(e => e.IdUser, "FK_maps_users_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Height)
                .HasColumnType("int(3)")
                .HasColumnName("height");
            entity.Property(e => e.IdUser)
                .HasColumnType("int(11)")
                .HasColumnName("id_user");
            entity.Property(e => e.Structure)
                .HasDefaultValueSql("''")
                .HasColumnType("varbinary(8000)")
                .HasColumnName("structure");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
            entity.Property(e => e.Width)
                .HasColumnType("int(3)")
                .HasColumnName("width");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Maps)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_maps_users_id");
        });

        modelBuilder.Entity<Object>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("objects");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Image)
                .HasColumnType("mediumblob")
                .HasColumnName("image");
            entity.Property(e => e.IsWall)
                .HasColumnType("tinyint(4)")
                .HasColumnName("is_wall");
            entity.Property(e => e.Key)
                .HasColumnType("int(11)")
                .HasColumnName("key");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("title");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("roles");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("title");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("users");

            entity.HasIndex(e => e.IdRole, "FK_users_roles_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.IdRole)
                .HasColumnType("int(11)")
                .HasColumnName("id_role");
            entity.Property(e => e.Login)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("login");
            entity.Property(e => e.Nickname)
                .HasMaxLength(255)
                .HasDefaultValueSql("''")
                .HasColumnName("nickname");
            entity.Property(e => e.Password)
                .HasMaxLength(256)
                .HasDefaultValueSql("''")
                .HasColumnName("password");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_users_roles_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
