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

namespace Porto.API.Controllers{
    [ApiController]
    public class MovementController : ControllerBase{

        private readonly IMovementService _movementService;
        private readonly IMapper _mapper;

        public MovementController(IMovementService movementService, IMapper mapper)
        {
            _movementService = movementService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("/api/v1.4/movement/create")]
        public async Task<IActionResult> Create([FromBody] CreateMovementViewModel movementViewModel){
            try
            {
                var movementDTO = _mapper.Map<MovementDTO>(movementViewModel);
                var movementCreated = await _movementService.Create(movementDTO);

                return Ok(new ResultViewModel{
                    Message = "Movimentação criado com sucesso",
                    Success = true,
                    Data = movementCreated
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
        [Route("/api/v1.4/movement/update")]
        public async Task<IActionResult> Update([FromBody] UpdateMovementViewModel movementViewModel)
        {
            try
            {
                var movementDTO = _mapper.Map<MovementDTO>(movementViewModel);
                var movementUpdated = await _movementService.Update(movementDTO);

                return Ok(new ResultViewModel
                {
                    Message = "Movimentação atualizada com sucesso",
                    Success = true,
                    Data = movementUpdated
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
        [Route("/api/v1.4/movement/remove/{id}")]
        public async Task<IActionResult> Remove(long id)
        {
            try
            {
                await _movementService.Remove(id);
                return Ok(new ResultViewModel
                {
                    Message = "Movimentação removida com sucesso",
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
        [Route("/api/v1.4/movement/get/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                var movement = await _movementService.Get(id);
                if (movement == null)
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhuma movimentação encontrada com esse ID",
                        Success = true,
                        Data = movement
                    });

                return Ok(new ResultViewModel
                    {
                        Message = "Movimentação encontrado com sucesso",
                        Success = true,
                        Data = movement
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
        [Route("/api/v1.4/movement/get-all")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var allmovements = await _movementService.Get();
                return Ok(new ResultViewModel
                    {
                        Message = "movements encontrados com sucesso",
                        Success = true,
                        Data = allmovements
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
        [Route("/api/v1.4/movement/search-by-type/")]
        public async Task<IActionResult> SearchByType([FromQuery] string typeMovement)
        {
            try
            {
                var allMovements = await _movementService.SearchByType(typeMovement);
                if (allMovements.Count == 0)
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhuma movimentação encontrada desse tipo",
                        Success = true,
                        Data = null
                    });

                return Ok(new ResultViewModel
                    {
                        Message = "Movimentação(ões) encontrada(s) com sucesso",
                        Success = true,
                        Data = allMovements
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