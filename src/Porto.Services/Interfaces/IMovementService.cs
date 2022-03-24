using Porto.Services.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Porto.Services.Interfaces{
    public interface IMovementService{
        
        Task<MovementDTO> Create(MovementDTO movementDTO);
        Task<MovementDTO> Update(MovementDTO movementDTO);
        Task Remove(long id);
        Task<MovementDTO> Get(long id);
        Task<List<MovementDTO>> Get();
        Task<List<MovementDTO>> SearchByType(string typeContainer);
    }
}