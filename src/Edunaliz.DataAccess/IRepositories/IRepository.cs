using Edunaliz.Domain.Commons;
using System.Linq.Expressions;

namespace Edunaliz.DataAccess.IRepositories;
public interface IRepository<TEntity> where TEntity : Auditable
{
    Task AddAsync(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    void Destroy(TEntity entity);
    Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression, string[] includes = null);
    IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression = null, bool isNoTracked = true, string[] includes = null);
    Task SaveAsync();
}
