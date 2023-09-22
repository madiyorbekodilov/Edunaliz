namespace Edunaliz.Service.DTOs.Answers;

public class AnswerCreationDto
{
    public string Text { get; set; }
    public bool IsTrue { get; set; }

    public long? AttachmentId { get; set; }

    public long QuestionId { get; set; }
}
