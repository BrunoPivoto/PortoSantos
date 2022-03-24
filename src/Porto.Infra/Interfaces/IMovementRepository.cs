using System.Threading.Tasks;
using Porto.Domain.Entities;
using System.Collections.Generic;

namespace Porto.Infra.Interfaces{
    public interface IMovementRepository : IBaseRepository<Movement>{
        Task<List<Movement>> SearchByType(string typeContainer);
    }
}