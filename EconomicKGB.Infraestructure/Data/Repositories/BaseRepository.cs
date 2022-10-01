using SmartSolution.Domain.EconomicContext;
using SmartSolution.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace SmartSolution.Infraestructure.Data.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly EconomicKGBContext _repository;

        protected BaseRepository(EconomicKGBContext repository)
        {
            _repository = repository;
        }

        public virtual async Task<Int32> CreateAsync(TEntity entity)
        {
            try
            {
                await _repository.Set<TEntity>().AddAsync(entity);
                return await _repository.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Int32> DeleteAsync(Int32 guid)
        {
            try
            {
                var data = GetAsync(guid);
                _repository.Set<TEntity>().Remove(data.Result);
                return await _repository.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            try
            {
                return await Task.FromResult(_repository.Set<TEntity>());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TEntity> GetAsync(int guid)
        {
            try
            {
                var data = await _repository.Set<TEntity>().FindAsync(guid);

                if (data == null)
                {
                    throw new Exception("Couldn't find the object");
                }

                return await Task.FromResult(data);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            try
            {
                _repository.Entry(entity).State = EntityState.Modified;
                _repository.Set<TEntity>().Update(entity);
                await Task.CompletedTask;
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<TEntity>> Find(Expression<Func<TEntity, bool>> where)
        {
            List<TEntity> entities = new List<TEntity>();
            Func<TEntity, bool> comparator = where.Compile();

            foreach (var item in (await Task.FromResult(_repository.Set<TEntity>())))
            {
                if (comparator(item))
                {
                    entities.Add(item);
                }
            }
            return entities;
        }
    }
}
