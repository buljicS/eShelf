using System;
using System.Collections.Generic;

namespace eShelf.Domain.Models;

public partial class Cover
{
    public Guid CoverId { get; set; }

    public int CoverTypeId { get; set; }

    public Guid BookId { get; set; }

    public string CoverPath { get; set; } = null!;

    public int? CoverSize { get; set; }

    public string? CoverDimmnesion { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual CoversType CoverType { get; set; } = null!;
}
