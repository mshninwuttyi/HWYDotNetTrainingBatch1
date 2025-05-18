using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HWYDotNetTrainingBatch1.Assigned.DreamDictionary.Databases.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblBlogDetail> TblBlogDetails { get; set; }

    public virtual DbSet<TblBlogHeader> TblBlogHeaders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblBlogDetail>(entity =>
        {
            entity.HasKey(e => e.BlogDetailId);

            entity.ToTable("Tbl_BlogDetail");

            entity.Property(e => e.BlogContent).HasMaxLength(50);
        });

        modelBuilder.Entity<TblBlogHeader>(entity =>
        {
            entity.HasKey(e => e.BlogId);

            entity.ToTable("Tbl_BlogHeader");

            entity.Property(e => e.BlogTitle).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
