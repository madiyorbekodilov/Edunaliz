using Edunaliz.Domain.Entities;

namespace Edunaliz.Service.DTOs.Answers;

public class AnswerResultDto
{
    public long Id { get; set; }
    public string Text { get; set; }
    public bool IsTrue { get; set; }

    public Attachment Attachment { get; set; }

    public Question Question { get; set; }
}
