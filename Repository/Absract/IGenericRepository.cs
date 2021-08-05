using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Absract
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void CreateAsync(TEntity item);

         Task<TEntity> FindByIdAsync(int id);

        Task<IEnumerable<TEntity>> GetAllAsync();

        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);

        void RemoveAsync(TEntity item);

        void UpdateAsync(TEntity item);
    }
}
