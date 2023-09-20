using Microsoft.AspNetCore.Http;

namespace Edunaliz.Service.DTOs.Attachments;

public class AttachmentCreationDto 
{
    public IFormFile FormFile { get; set; }
}
