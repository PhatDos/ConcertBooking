using ConcertBooking.Api.Modules.User.Domain.Enums;
using ConcertBooking.Api.Shared.Domain;

namespace ConcertBooking.Api.Modules.User.Domain.Entities;

public class User : BaseEntity
{
    private User()
    {
    }

    public User(string email, string fullName, UserRole role)
    {
        Email = email.Trim();
        FullName = fullName.Trim();
        Role = role;
    }

    public string Email { get; private set; } = default!;

    public string FullName { get; private set; } = default!;

    public UserRole Role { get; private set; }
}