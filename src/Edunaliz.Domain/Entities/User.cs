using Edunaliz.Domain.Commons;
using Edunaliz.Domain.Enums;

namespace Edunaliz.Domain.Entities;

public class User : Auditable
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public UserRole Role { get; set; }
}