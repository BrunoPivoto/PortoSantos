using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Porto.Domain.Entities;
using Porto.Infra.Interfaces;
using Porto.Infra.Context;

namespace Porto.Infra.Repositories{
    public class BaseRepository<T> : IBaseRepository<T> where T : Base{
        private readonly PortoContext _context;

        public BaseRepository(PortoContext context)
        {
            _context = context;
        }

        public virtual async Task<T> Create(T obj){
            _context.Add(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        public virtual async Task<T> Update(T obj){
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return obj;
        }

        public virtual async Task Remove(long id){
            var obj = await Get(id);

            if(obj != null){
                _context.Remove(obj);
                await _context.SaveChangesAsync();
            }
        }

        public virtual async Task<T> Get(long id){
            var obj = await _context.Set<T>()
                                    .AsNoTracking()
                                    .Where(x=>x.Id == id)
                                    .ToListAsync();

        return obj.FirstOrDefault();
        }

        public virtual async Task<List<T>> Get(){
            return await _context.Set<T>()
                                 .AsNoTracking()
                                 .ToListAsync();
        }
    }
}