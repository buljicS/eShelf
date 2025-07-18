using System;
using System.Collections.Generic;

namespace eShelf.Domain.Models;

public partial class CoversType
{
    public int CoverTypeId { get; set; }

    public string CoverName { get; set; } = null!;

    public virtual ICollection<Cover> Covers { get; set; } = new List<Cover>();
}
