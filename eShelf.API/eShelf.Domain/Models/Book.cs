using System;
using System.Collections.Generic;

namespace eShelf.Domain.Models;

public partial class Book
{
    public Guid BookId { get; set; }

    public string Title { get; set; } = null!;

    public string Isbn { get; set; } = null!;

    public int NumberOfPages { get; set; }

    public Guid AuthorId { get; set; }

    public string? Publisher { get; set; }

    public DateOnly DatePublished { get; set; }

    public Guid BookMetaId { get; set; }

    public virtual Author Author { get; set; } = null!;

    public virtual BookMeta BookMeta { get; set; } = null!;

    public virtual ICollection<Cover> Covers { get; set; } = new List<Cover>();
}
