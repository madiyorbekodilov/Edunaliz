using Edunaliz.DataAccess.IRepositories;
using Edunaliz.Domain.Entities;
using Edunaliz.Service.DTOs.Attachments;
using Edunaliz.Service.Exstentions;
using Edunaliz.Service.Helpers;
using Edunaliz.Service.Interfaces;

namespace Edunaliz.Service.Services;

public class AttachmentService : IAttachmentService
{
    private readonly IRepository<Attachment> repository;
    public AttachmentService(IRepository<Attachment> repository)
    {
        this.repository = repository;
    }

    public async ValueTask<Attachment> UploadAsync(AttachmentCreationDto dto)
    {
        var webrootPath = Path.Combine(PathHelper.WebRootPath, "Files");

        if (!Directory.Exists(webrootPath))
            Directory.CreateDirectory(webrootPath);

        var fileExtension = Path.GetExtension(dto.FormFile.FileName);
        var fileName = $"{Guid.NewGuid().ToString("N")}{fileExtension}";
        var fullPath = Path.Combine(webrootPath, fileName);

        var fileStream = new FileStream(fullPath, FileMode.OpenOrCreate);
        await fileStream.WriteAsync(dto.FormFile.ToByte());

        var createdAttachment = new Attachment
        {
            FileName = fileName,
            FilePath = fullPath
        };
        await this.repository.AddAsync(createdAttachment);
        await this.repository.SaveAsync();
        
        return createdAttachment;
    }

    public async ValueTask<bool> RemoveAsync(Attachment attachment)
    {
        this.repository.Delete(attachment);
        await this.repository.SaveAsync();
        return true;
    }
}
