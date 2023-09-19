using Edunaliz.Domain.Commons;

namespace Edunaliz.Domain.Entities;

public class Result : Auditable
{
    public string Text { get; set; } = string.Empty;
    public bool IsTrue { get; set; }

    public long? AttachmentId { get; set; }
    public Attachment Attachment { get; set; } = default!;

    public long QuestionId { get; set; }
    public Question Question { get; set; } = default!;

    public long AnswerId { get; set; }
    public Answer Answer { get; set; } = default!;
}

