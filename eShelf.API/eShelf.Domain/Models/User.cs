using System;
using System.Collections.Generic;

namespace eShelf.Domain.Models;

public partial class User
{
    public Guid UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Nickname { get; set; }

    public string Email { get; set; } = null!;

    public Guid? ProfilePictureId { get; set; }

    public string Password { get; set; } = null!;

    public bool EmailConfirmed { get; set; }

    public DateTime RegisteredSince { get; set; }

    public int BooksOwned { get; set; }
}
