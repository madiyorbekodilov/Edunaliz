using Edunaliz.Service.DTOs;

namespace Edunaliz.Service.Interfaces;

public interface ICategoryService
{
    Task<CategoryResultDto> CreateAsync(CategoryCreationDto dto);
    Task<CategoryResultDto> UpdateAsync(CategoryUpdateDto dto);
    Task<bool> DeleteAsync(long id);
    Task<CategoryResultDto> GetAsync(long id);
    Task<IEnumerable<CategoryResultDto>> GetAllAsync();
}
