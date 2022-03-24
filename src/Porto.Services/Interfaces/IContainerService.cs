using Porto.Services.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Porto.Services.Interfaces{
    public interface IContainerService{
        
        Task<ContainerDTO> Create(ContainerDTO containerDTO);
        Task<ContainerDTO> Update(ContainerDTO containerDTO);
        Task Remove(long id);
        Task<ContainerDTO> Get(long id);
        Task<List<ContainerDTO>> Get();
        Task<ContainerDTO> GetByNum(string numContainer);
        Task<List<ContainerDTO>> SearchByClient(string clientContainer);
    }
}