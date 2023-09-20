using Edunaliz.Domain.Entities;
using Edunaliz.Service.DTOs.Attachments;
namespace Edunaliz.Service.Interfaces;

public interface IAttachmentService
{
    ValueTask<Attachment> UploadAsync(AttachmentCreationDto dto);
    ValueTask<bool> RemoveAsync(Attachment attachment);
}
