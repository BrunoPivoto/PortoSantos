using AutoMapper;
using Porto.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Porto.API.Utilities;
using Porto.API.ViewModels;
using Porto.Services.DTO;
using Porto.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Porto.API.Controllers
{
    [ApiController]
    public class ContainerController : ControllerBase
    {

        private readonly IContainerService _containerService;
        private readonly IMapper _mapper;

        public ContainerController(IContainerService containerService, IMapper mapper)
        {
            _containerService = containerService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("/api/v1.4/container/create")]
        public async Task<IActionResult> Create([FromBody] CreateContainerViewModel containerViewModel)
        {
            try
            {
                var containerDTO = _mapper.Map<ContainerDTO>(containerViewModel);
                var containerCreated = await _containerService.Create(containerDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Container criado com sucesso",
                    Success = true,
                    Data = containerCreated
                });
            }
            catch (DomainException ex)
            {

                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpPut]
        [Route("/api/v1.4/container/update")]
        public async Task<IActionResult> Update([FromBody] UpdateContainerViewModel containerViewModel)
        {
            try
            {
                var containerDTO = _mapper.Map<ContainerDTO>(containerViewModel);
                var containerUpdated = await _containerService.Update(containerDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Container atualizado com sucesso",
                    Success = true,
                    Data = containerUpdated
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpDelete]
        [Route("/api/v1.4/container/remove/{id}")]
        public async Task<IActionResult> Remove(long id)
        {
            try
            {
                await _containerService.Remove(id);
                return Ok(new ResultViewModel
                {
                    Message = "Container removido com sucesso",
                    Success = true,
                    Data = null
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Route("/api/v1.4/container/get/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                var container = await _containerService.Get(id);
                if (container == null)
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum container encontrado com esse ID",
                        Success = true,
                        Data = container
                    });

                return Ok(new ResultViewModel
                    {
                        Message = "Container encontrado com sucesso",
                        Success = true,
                        Data = container
                    });    
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Route("/api/v1.4/container/get-all")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var allContainers = await _containerService.Get();
                return Ok(new ResultViewModel
                    {
                        Message = "Containers encontrados com sucesso",
                        Success = true,
                        Data = allContainers
                    });    
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Route("/api/v1.4/container/get-by-num/{numContainer}")]
        public async Task<IActionResult> GetByNum(string numContainer)
        {
            try
            {
                var container = await _containerService.GetByNum(numContainer);
                if (container == null)
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum container encontrado com esse número",
                        Success = true,
                        Data = container
                    });

                return Ok(new ResultViewModel
                    {
                        Message = "Container encontrado com sucesso",
                        Success = true,
                        Data = container
                    });    
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Route("/api/v1.4/container/search-by-client/")]
        public async Task<IActionResult> SearchByClient([FromQuery] string clientContainer)
        {
            try
            {
                var allContainers = await _containerService.SearchByClient(clientContainer);
                if (allContainers.Count == 0)
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum container encontrado desse cliente",
                        Success = true,
                        Data = null
                    });

                return Ok(new ResultViewModel
                    {
                        Message = "Container(s) encontrado(s) com sucesso",
                        Success = true,
                        Data = allContainers
                    });    
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }
    }
}