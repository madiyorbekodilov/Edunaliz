using AutoMapper;
using Edunaliz.Domain.Entities;
using Edunaliz.Service.DTOs;
using Edunaliz.Service.DTOs.Users;

namespace Edunaliz.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //User
        CreateMap<UserCreationDto, User>().ReverseMap();
        CreateMap<User, UserUpdateDto>().ReverseMap();
        CreateMap<User, UserResultDto>().ReverseMap();

        //Categories
        CreateMap<Category, CategoryCreationDto>().ReverseMap();
        CreateMap<Category, CategoryResultDto>().ReverseMap();
        CreateMap<Category, CategoryUpdateDto>().ReverseMap();
    }
}