using SmartSolution.Domain.Interfaces.Repository;
using SmartSolution.Domain.Services.Interface.IRepositoriesServices;
using System.Linq.Expressions;

namespace SmartSolution.Domain.Services.Services.RepositoriesServices
{
    public abstract class BaseServices<TEntity> : IRepositoryServices<TEntity>
    where TEntity : class
    {
        private readonly IRepository<TEntity> repository;

        protected BaseServices(IRepository<TEntity> repository)
        {
            this.repository = repository;
        }

        public async Task<Int32> CreateAsync(TEntity entity)
        {
            return await repository.CreateAsync(entity);
        }

        public async Task<Int32> DeleteAsync(Int32 guid)
        {
            return await repository.DeleteAsync(guid);
        }

        public async Task<List<TEntity>> Find(Expression<Func<TEntity, bool>> where)
        {
            return await repository.Find(where);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }

        public async Task<TEntity> GetAsync(Int32 guid)
        {
            return await repository.GetAsync(guid);
        }

        public async Task<Boolean> UpdateAsync(TEntity entity)
        {
            return await repository.UpdateAsync(entity);
        }
    }
}
