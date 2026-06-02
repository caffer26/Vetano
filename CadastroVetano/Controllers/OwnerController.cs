using Cadastro.Interfaces.IServices;
using CadastroVetano.DTO.Owners;
using CadastroVetano.UseCases.Owners;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CadastroVetano.Controllers
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
                return Ok(owners);
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
                return Ok(owner);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
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
