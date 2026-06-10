using CadastroVetano.Register.Entities.Owners;
using CadastroVetano.Register.DTO.Owners;
using CadastroVetano.Register.Interfaces.IServices;
using CadastroVetano.Register.UseCases.Owners;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CadastroVetano.Register.Controllers.Register
{
    [ApiController]
    [Route("api/[controller]")]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _service;
        private readonly CreateOwnerUseCase _createOwnerUseCase;
        private readonly UpdateOwnerUseCase _updateOwnerUseCase;
        private readonly DeleteOwnerUseCase _deleteOwnerUseCase;

        public OwnerController(IOwnerService service, CreateOwnerUseCase createOwnerUseCase, UpdateOwnerUseCase updateOwnerUseCase, DeleteOwnerUseCase deleteOwnerUseCase)
        {
            _service = service;
            _createOwnerUseCase = createOwnerUseCase;
            _updateOwnerUseCase = updateOwnerUseCase;
            _deleteOwnerUseCase = deleteOwnerUseCase;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateOwnerDTO dto)
        {
            try
            {
                _createOwnerUseCase.Run(dto);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult FindAll()
        {
            try
            {
                var owners = _service.FindAll();

                var response = owners.Select(owners => new OwnerResponseDTO
                {
                    Id = owners.Id,
                    Name = owners.Name.Value,
                    Email = owners.EmailValue,
                    Cpf = owners.Cpf.Value,
                    PhoneNumber = owners.PhoneNumber.Value,
                    BirthDate = owners.BirthDate
                }).ToList();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public IActionResult FindById(Guid id)
        {
            try
            {
                var owner = _service.FindById(id);

                var response = new OwnerResponseDTO
                {
                    Id = owner.Id,
                    Name = owner.Name.Value,
                    Email = owner.EmailValue,
                    Cpf = owner.Cpf.Value,
                    PhoneNumber = owner.PhoneNumber.Value,
                    BirthDate = owner.BirthDate
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPatch("{id}")]
        public IActionResult Update(Guid id, [FromBody] UpdateOwnerDTO dto)
        {
            try
            {
                _updateOwnerUseCase.Run(id, dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _deleteOwnerUseCase.Run(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
