using AutoMapper;
using Porto.Core.Exceptions;
using Porto.Domain.Entities;
using Porto.Infra.Interfaces;
using Porto.Services.DTO;
using Porto.Services.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Porto.Services.Services{
    public class MovementService : IMovementService{
        private readonly IMapper _mapper;
        private readonly IMovementRepository _movementRepository;

        public MovementService(IMapper mapper, IMovementRepository movementRepository)
        {
            _mapper = mapper;
            _movementRepository = movementRepository;
        }

        public async Task<MovementDTO> Create(MovementDTO movementDTO){
            var movementExists = await _movementRepository.Get(movementDTO.IdMovement);

            if(movementExists != null){
                throw new DomainException("Já existe movimentação com esse ID");
            }

            var movement = _mapper.Map<Movement>(movementDTO);
            movement.Validate();

            var movementCreated = await _movementRepository.Create(movement);

            return _mapper.Map<MovementDTO>(movementCreated);
        }
        public async Task<MovementDTO> Update(MovementDTO movementDTO){
            var movementExists = await _movementRepository.Get(movementDTO.IdMovement);

            if (movementExists == null)
                throw new DomainException("Não existe movimentação com esse ID");

            var movement = _mapper.Map<Movement>(movementDTO);
            movement.Validate();

            var movementUpdated = await _movementRepository.Update(movement);

            return _mapper.Map<MovementDTO>(movementUpdated);
        }
        public async Task Remove(long id){
            await _movementRepository.Remove(id);
        }
        public async Task<MovementDTO> Get(long id){
            var movement = await _movementRepository.Get(id);

            return _mapper.Map<MovementDTO>(movement);
        }
        public async Task<List<MovementDTO>> Get(){var allMovements = await _movementRepository.Get();

            return _mapper.Map<List<MovementDTO>>(allMovements);
        }
        public async Task<List<MovementDTO>> SearchByType(string typeMovement){
            var movement = await _movementRepository.SearchByType(typeMovement);

            return _mapper.Map<List<MovementDTO>>(movement);
      
        }
    }
}