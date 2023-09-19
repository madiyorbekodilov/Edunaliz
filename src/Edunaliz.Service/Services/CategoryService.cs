using Edunaliz.Service.DTOs;
using Edunaliz.Service.Interfaces;

namespace Edunaliz.Service.Services;

public class CategoryService : ICategoryService
{
    public Task<CategoryResultDto> CreateAsync(CategoryCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CategoryResultDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<CategoryResultDto> GetAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<CategoryResultDto> UpdateAsync(CategoryUpdateDto dto)
    {
        throw new NotImplementedException();
    }
}
