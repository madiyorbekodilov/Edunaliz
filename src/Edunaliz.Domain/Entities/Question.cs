using Edunaliz.Domain.Commons;

namespace Edunaliz.Domain.Entities;

public class Question : Auditable
{
    public string Title { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;

    public long? AttachmentId { get; set; }
    public Attachment Attachment { get; set; } = default!;

    public long AssignmentId { get; set; }
    public Assignment Assignment { get; set; } = default!;
}

