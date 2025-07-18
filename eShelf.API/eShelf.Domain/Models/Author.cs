﻿using System;
using System.Collections.Generic;

namespace eShelf.Domain.Models;

public partial class Author
{
    public Guid AuthorId { get; set; }

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string LastName { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
