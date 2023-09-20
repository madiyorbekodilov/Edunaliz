using Edunaliz.DataAccess.IRepositories;
using Edunaliz.DataAccess.Repositories;
using Edunaliz.Service.Interfaces;
using Edunaliz.Service.Mappers;
using Edunaliz.Service.Services;

namespace Edunaliz.Api.Extensions;

public static class ServiceCollection
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfile));
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<ICategoryService, CategoryService>();
    }
}
