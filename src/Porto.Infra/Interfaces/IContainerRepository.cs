using Porto.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Porto.Infra.Interfaces{
    public interface IContainerRepository : IBaseRepository<Container>{
        Task<Container> GetByNum(string numContainer);
        Task<List<Container>> SearchByClient(string clientContainer);
    }
}