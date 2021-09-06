using Microsoft.EntityFrameworkCore;
using Repository.Absract;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Concrete
{
    public class EFTopicRepository : ITopicRepository
    {
        ApplicationDbContext _context;


        public EFTopicRepository(ApplicationDbContext context)
        {
            _context = context;
        }





        public async Task<IEnumerable<Topic>> GetAllAsync()
        {
            return await _context.Topics.ToListAsync();
        }

        public async Task<IEnumerable<Topic>> GetAllWithIncludeMessagesAsync()
        {
            return await _context.Topics.Include(c=>c.TopicMessages).Include(m=>m.User).ToListAsync();
        }





        public IEnumerable<Topic> Get(Func<Topic, bool> predicate)
        {
            return _context.Topics.Where(predicate).ToList();
        }





        public async Task<Topic> FindByIdAsync(int id)
        {
            return await _context.Topics.FirstOrDefaultAsync(c => c.Id == id);        
        }

        public async Task<Topic> FindByIdWithIncludeMessagesAsync(int id)
        {
            return await _context.Topics.Include(c=>c.TopicMessages).Include(m=>m.User).FirstOrDefaultAsync(c=>c.Id==id);
        }







        public async Task CreateAsync(Topic item)
        {
            _context.Topics.Add(item);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateAsync(Topic item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }


        public async Task RemoveAsync(Topic item)
        {
            _context.Topics.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
