using AutoMapper;
using Porto.Core.Exceptions;
using Porto.Domain.Entities;
using Porto.Infra.Interfaces;
using Porto.Services.DTO;
using Porto.Services.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Porto.Services.Services{
    public class ContainerService : IContainerService{
        private readonly IMapper _mapper;
        private readonly IContainerRepository _containerRepository;

        public ContainerService(IMapper mapper, IContainerRepository containerRepository)
        {
            _mapper = mapper;
            _containerRepository = containerRepository;
        }

        public async Task<ContainerDTO> Create(ContainerDTO containerDTO){
            var containerExists = await _containerRepository.GetByNum(containerDTO.NumContainer);

            if(containerExists != null){
                throw new DomainException("Já existe container com esse número");
            }

            var container = _mapper.Map<Container>(containerDTO);
            container.Validate();

            var containerCreated = await _containerRepository.Create(container);

            return _mapper.Map<ContainerDTO>(containerCreated);
        }
        public async Task<ContainerDTO> Update(ContainerDTO containerDTO){
            var ContainerExists = await _containerRepository.Get(containerDTO.Id);

            if (ContainerExists == null)
                throw new DomainException("Não existe container com esse ID");

            var container = _mapper.Map<Container>(containerDTO);
            container.Validate();

            var containerUpdated = await _containerRepository.Update(container);

            return _mapper.Map<ContainerDTO>(containerUpdated);
        }
        public async Task Remove(long id){
            await _containerRepository.Remove(id);
        }
        public async Task<ContainerDTO> Get(long id){
            var container = await _containerRepository.Get(id);

            return _mapper.Map<ContainerDTO>(container);
        }
        public async Task<List<ContainerDTO>> Get(){var allContainers = await _containerRepository.Get();

            return _mapper.Map<List<ContainerDTO>>(allContainers);
        }
        public async Task<ContainerDTO> GetByNum(string numContainer){
            var container = await _containerRepository.GetByNum(numContainer);

            return _mapper.Map<ContainerDTO>(container);
        }
        public async Task<List<ContainerDTO>> SearchByClient(string clientContainer){
            var container = await _containerRepository.SearchByClient(clientContainer);

            return _mapper.Map<List<ContainerDTO>>(container);
      
        }
    }
}