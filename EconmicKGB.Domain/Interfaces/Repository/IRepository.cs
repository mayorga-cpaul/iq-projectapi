using System.Linq.Expressions;

namespace SmartSolution.Domain.Interfaces.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// You can create any entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<Int32> CreateAsync(TEntity entity);

        /// <summary>
        /// Update any Entity async
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<Boolean> UpdateAsync(TEntity entity);

        /// <summary>
        /// Get entity by Id (int)
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        Task<TEntity> GetAsync(Int32 guid);

        /// <summary>
        /// Remove any Entity from db
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        Task<Int32> DeleteAsync(Int32 guid);

        /// <summary>
        /// Get all the entity from db
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        /// Delegate func expression for any query this method is not recommended
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        Task<List<TEntity>> Find(Expression<Func<TEntity, bool>> where);
    }
}
