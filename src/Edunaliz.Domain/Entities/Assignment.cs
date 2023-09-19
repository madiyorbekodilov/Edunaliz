using Edunaliz.Domain.Commons;

namespace Edunaliz.Domain.Entities;

public class Assignment : Auditable
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime DueDate { get; set; }

    public long? AttachmentId { get; set; }
    public Attachment Attachment { get; set; } = default!;

    public long UserId { get; set; }
    public User User { get; set; } = default!;

    public long CategoryId { get; set; }
    public Category Category { get; set; } = default!;
}

