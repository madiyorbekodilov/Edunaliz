using Edunaliz.Domain.Commons;

namespace Edunaliz.Domain.Entities;

public class Attachment : Auditable
{
    public string FilePath { get; set; } = string.Empty;
    public string FileName { get; set; } = string.Empty;
}

