using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using eShelf.Domain.Models;

namespace eShelf.Domain.Context;

public partial class PdfShelfDbContext : DbContext
{
    public PdfShelfDbContext(DbContextOptions<PdfShelfDbContext> options) : base(options) {}

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Cover> Covers { get; set; }

    public virtual DbSet<CoversType> CoversTypes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<BookMeta> BooksMeta { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.Property(e => e.AuthorId)
                .ValueGeneratedNever()
                .HasColumnName("AuthorID");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasIndex(e => e.AuthorId, "IX_Books_AuthorID");

            entity.Property(e => e.BookId)
                .ValueGeneratedNever()
                .HasColumnName("BookID");
            entity.Property(e => e.AuthorId).HasColumnName("AuthorID");
            entity.Property(e => e.Isbn).HasColumnName("ISBN");

            entity.HasOne(d => d.Author).WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.BookMeta).WithMany(p => p.Books)
                .HasForeignKey(d => d.BookMetaId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Cover>(entity =>
        {
            entity.HasIndex(e => e.BookId, "IX_Covers_BookID");

            entity.HasIndex(e => e.CoverTypeId, "IX_Covers_CoverTypeID");

            entity.Property(e => e.CoverId)
                .ValueGeneratedNever()
                .HasColumnName("CoverID");
            entity.Property(e => e.BookId).HasColumnName("BookID");
            entity.Property(e => e.CoverTypeId).HasColumnName("CoverTypeID");

            entity.HasOne(d => d.Book).WithMany(p => p.Covers).HasForeignKey(d => d.BookId);

            entity.HasOne(d => d.CoverType).WithMany(p => p.Covers)
                .HasForeignKey(d => d.CoverTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<CoversType>(entity =>
        {
            entity.HasKey(e => e.CoverTypeId);

            entity.Property(e => e.CoverTypeId).HasColumnName("CoverTypeID");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("UserID");
            entity.Property(e => e.ProfilePictureId).HasColumnName("ProfilePictureID");
        });

        modelBuilder.Entity<BookMeta>(entity =>
        {
            entity.HasKey(x => x.BookMetaId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
