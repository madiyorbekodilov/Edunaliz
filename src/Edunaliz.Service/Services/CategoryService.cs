using AutoMapper;
using Edunaliz.Service.DTOs;
using Edunaliz.Domain.Entities;
using Edunaliz.Service.Exceptions;
using Edunaliz.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Edunaliz.DataAccess.IRepositories;

namespace Edunaliz.Service.Services;

public class CategoryService : ICategoryService
{
    private readonly IRepository<Category> repository;
    private readonly IMapper mapper;
    public CategoryService(IRepository<Category> repository, IMapper mapper)
    {
        this.mapper = mapper;
        this.repository = repository;
    }
    public async Task<CategoryResultDto> CreateAsync(CategoryCreationDto dto)
    {
        var existCategory = await this.repository.GetAsync(c => c.Name == dto.Name);
        if (existCategory is not null)
            throw new AlreadyExistException($"This category already exist with name: {dto.Name}");

        if (dto.ParentId != 0)
        {
            var existParent = await this.repository.GetAsync(p => p.Id == dto.ParentId)
                ?? throw new NotFoundException($"This parent Id is null with id {dto.ParentId}");
        }

        var mappedCategory = this.mapper.Map<Category>(dto);
        await this.repository.AddAsync(mappedCategory);
        await this.repository.SaveAsync();

        return this.mapper.Map<CategoryResultDto>(mappedCategory);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var existCategory = await this.repository.GetAsync(p => p.Id == id)
                ?? throw new NotFoundException($"This category Id is null with id {id}");

        this.repository.Delete(existCategory);
        await this.repository.SaveAsync();

        return true;
    }

    public async Task<IEnumerable<CategoryResultDto>> GetAllAsync()
    {
        var categories = await this.repository.GetAll().ToListAsync();
        return this.mapper.Map<IEnumerable<CategoryResultDto>>(categories);
    }

    public async Task<CategoryResultDto> GetAsync(long id)
    {
        var existCategory = await this.repository.GetAsync(p => p.Id == id)
                ?? throw new NotFoundException($"This category Id is null with id {id}");

        return this.mapper.Map<CategoryResultDto>(existCategory);
    }

    public async Task<CategoryResultDto> UpdateAsync(CategoryUpdateDto dto)
    {
        var existCategory = await this.repository.GetAsync(p => p.Id == dto.Id)
                ?? throw new NotFoundException($"This category Id is null with id {dto.Id}");

        this.mapper.Map(dto, existCategory);
        this.repository.Update(existCategory);
        await this.repository.SaveAsync();

        return this.mapper.Map<CategoryResultDto>(existCategory);
    }
}