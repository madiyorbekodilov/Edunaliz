using Edunaliz.Domain.Enums;

namespace Edunaliz.Service.DTOs.Users;

public class UserUpdateDto
{
    public long Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public UserRole Role { get; set; }
}