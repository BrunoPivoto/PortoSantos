using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Porto.Infra.Context;
using Porto.Infra.Interfaces;
using Porto.Infra.Repositories;
using Porto.Domain.Entities;

namespace Porto.Infra.Repositories
{
    public class MovementRepository : BaseRepository<Movement>, IMovementRepository{
        private readonly PortoContext _context;

        public MovementRepository(PortoContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<Movement>> SearchByType(string typeMovement){
            var allMovements = await _context.Movements
                                     .Where(x => x.TypeMovement.ToLower().Contains(typeMovement.ToLower()))
                                     .AsNoTracking()
                                     .ToListAsync();

            return allMovements;
        }
    }
}