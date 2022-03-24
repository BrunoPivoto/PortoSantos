using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Porto.Infra.Repositories;
using Porto.Domain.Entities;
using Porto.Infra.Interfaces;
using Porto.Infra.Context;

namespace Porto.Infra.Repositories
{
    public class ContainerRepository : BaseRepository<Container>, IContainerRepository
    {
        private readonly PortoContext _context;

        public ContainerRepository(PortoContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Container> GetByNum(string numContainer)
        {
            var container = await _context.Containers
                                     .Where(x => x.NumContainer.ToLower() == numContainer.ToLower())
                                     .AsNoTracking()
                                     .ToListAsync();

            return container.FirstOrDefault();
        }

        public async Task<List<Container>> SearchByClient(string clientContainer)
        {
            var allContainer = await _context.Containers
                                     .Where(x => x.ClientContainer.ToLower().Contains(clientContainer.ToLower()))
                                     .AsNoTracking()
                                     .ToListAsync();

            return allContainer;
        }
    }
}
