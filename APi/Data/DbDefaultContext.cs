using System;
using System.Collections.Generic;
using System.Configuration;
using APi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace APi.Data;

public partial class DbDefaultContext : DbContext
{
    private readonly IConfiguration configuration;
    public DbDefaultContext()
    {
    }

    public DbDefaultContext(DbContextOptions<DbDefaultContext> options, IConfiguration configuration)
        : base(options)
    {
        this.configuration = configuration;
    }

    public virtual DbSet<TbMenu> TbMenus { get; set; }

    public virtual DbSet<TbMenuPerfil> TbMenuPerfils { get; set; }

    public virtual DbSet<TbPerfil> TbPerfils { get; set; }

    public virtual DbSet<TbUsuario> TbUsuarios { get; set; }

    public virtual DbSet<TbUsuarioPerfil> TbUsuarioPerfils { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=SDBSQL2016D1\\SQLSERVER2019D1; Initial Catalog=dbExtracaoDadosSN; User Id=usextracaosn; Password=F5g5K#@3ws#Kor9Fq@6etRTN;TrustServerCertificate=yes");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbMenu>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__tbMenu__06370DADADB7FF24");

            entity.ToTable("tbMenu");

            entity.Property(e => e.DataCriacao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Descricao)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TbMenuPerfil>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__tbMenuPe__06370DADFD7D2338");

            entity.ToTable("tbMenuPerfil");

            entity.Property(e => e.DataCriacao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.CodigoMenuNavigation).WithMany(p => p.TbMenuPerfils)
                .HasForeignKey(d => d.CodigoMenu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbMenuPer__Codig__3F466844");

            entity.HasOne(d => d.CodigoPerfilNavigation).WithMany(p => p.TbMenuPerfils)
                .HasForeignKey(d => d.CodigoPerfil)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbMenuPer__Codig__403A8C7D");
        });

        modelBuilder.Entity<TbPerfil>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__tbPerfil__06370DAD6012AB7D");

            entity.ToTable("tbPerfil");

            entity.Property(e => e.DataCriacao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Descricao)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TbUsuario>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK__tbUsuari__06370DADAC77F389");

            entity.ToTable("tbUsuario");

            entity.Property(e => e.Cpf)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CPF");
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TbUsuarioPerfil>(entity =>
        {
            entity.HasKey(e => new { e.CodigoUsuario, e.CodigoPerfil }).HasName("PK__tbUsuari__339AC635D09D9716");

            entity.ToTable("tbUsuarioPerfil");

            entity.Property(e => e.DataLimite).HasColumnType("date");

            entity.HasOne(d => d.CodigoPerfilNavigation).WithMany(p => p.TbUsuarioPerfils)
                .HasForeignKey(d => d.CodigoPerfil)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbUsuario__Codig__2B3F6F97");

            entity.HasOne(d => d.CodigoUsuarioNavigation).WithMany(p => p.TbUsuarioPerfils)
                .HasForeignKey(d => d.CodigoUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbUsuario__Codig__2A4B4B5E");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
