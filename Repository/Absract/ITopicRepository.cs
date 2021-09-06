using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Absract
{
    public interface ITopicRepository
    {
        Task<IEnumerable<Topic>> GetAllAsync();
        Task<IEnumerable<Topic>> GetAllWithIncludeMessagesAsync();


        IEnumerable<Topic> Get(Func<Topic, bool> predicate);


         Task<Topic> FindByIdAsync(int id);
        Task<Topic> FindByIdWithIncludeMessagesAsync(int id);


        Task CreateAsync(Topic item);
        Task UpdateAsync(Topic item);
        Task RemoveAsync(Topic item);
    }
}
