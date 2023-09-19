namespace Edunaliz.Service.DTOs;

public class CategoryCreationDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public long? ParentId { get; set; }
}