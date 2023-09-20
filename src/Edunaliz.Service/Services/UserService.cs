using AutoMapper;
using Edunaliz.Domain.Entities;
using Edunaliz.Service.DTOs.Users;
using Edunaliz.Service.Exceptions;
using Edunaliz.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Edunaliz.DataAccess.IRepositories;

namespace Edunaliz.Service.Services;

public class UserService : IUserService
{
    private readonly IMapper mapper;
    private readonly IRepository<User> repository;
    public UserService(IMapper mapper, IRepository<User> repository)
    {
        this.mapper = mapper;
        this.repository = repository;
    }

    public async Task<UserResultDto> CreateAsync(UserCreationDto dto)
    {
        var mappedUser = this.mapper.Map<User>(dto);
        await this.repository.AddAsync(mappedUser);
        await this.repository.SaveAsync();

        return this.mapper.Map<UserResultDto>(mappedUser);
    }

    public async Task<UserResultDto> ModifyAsync(UserUpdateDto dto)
    {
        var user = await this.repository.GetAsync(user => user.Id.Equals(dto.Id))
                   ?? throw new NotFoundException("This user is not found");

        var mappedUser = this.mapper.Map(dto, user);
        this.repository.Update(mappedUser);
        await this.repository.SaveAsync();

        return this.mapper.Map<UserResultDto>(mappedUser);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var user = await this.repository.GetAsync(user => user.Id.Equals(id))
                   ?? throw new NotFoundException("This user is not found");

        this.repository.Delete(user);
        await this.repository.SaveAsync();
        return true;
    }

    public async Task<bool> DestroyAsync(long id)
    {
        var user = await this.repository.GetAsync(user => user.Id.Equals(id))
                   ?? throw new NotFoundException("This user is not found");

        this.repository.Destroy(user);
        await this.repository.SaveAsync();
        return true;
    }

    public async Task<UserResultDto> RetrieveByIdAsync(long id)
    {
        var user = await this.repository.GetAsync(user => user.Id.Equals(id))
                   ?? throw new NotFoundException("This user is not found");

        return this.mapper.Map<UserResultDto>(user);
    }

    public async Task<IEnumerable<UserResultDto>> RetrieveAllAsync()
    {
        var users = await this.repository.GetAll().ToListAsync();
        return this.mapper.Map<IEnumerable<UserResultDto>>(users);
    }
}