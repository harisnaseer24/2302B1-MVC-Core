using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace _2302b1TempEmbedding.Models;

public partial class _2302b1dotnetContext : DbContext
{
    public _2302b1dotnetContext()
    {
    }

    public _2302b1dotnetContext(DbContextOptions<_2302b1dotnetContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer("data source=.;initial catalog=2302b1dotnet;user id=sa;password=aptech; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CatId).HasName("PK__Categori__6A1C8AFAC8F7DDC4");

            entity.Property(e => e.CatName).HasMaxLength(50);
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Items__3214EC0716ABC314");

            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .HasColumnName("image");
            entity.Property(e => e.Pname)
                .HasMaxLength(50)
                .HasColumnName("pname");
            entity.Property(e => e.Price).HasColumnName("price");

            entity.HasOne(d => d.Cat).WithMany(p => p.Items)
                .HasForeignKey(d => d.CatId)
                .HasConstraintName("FK_Items_ToTable");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__products__3214EC073FBE4BAC");

            entity.ToTable("products");

            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Pname)
                .HasMaxLength(50)
                .HasColumnName("pname");
            entity.Property(e => e.Price).HasColumnName("price");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
