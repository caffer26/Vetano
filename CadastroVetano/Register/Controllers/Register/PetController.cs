using CadastroVetano.Register.DTO.Pets;
using CadastroVetano.Register.Interfaces.IServices;
using CadastroVetano.Register.UseCases.Pets;
using Microsoft.AspNetCore.Mvc;

namespace CadastroVetano.Register.Controllers.Register
{
    [ApiController]
    [Route("api/[controller]")]

    public class PetController : ControllerBase
    {
        private readonly IPetService _petService;
        private readonly CreatePetUseCase _createPetUseCase;
        private readonly UpdatePetUseCase _updatePetUseCase;
        private readonly DeletePetUseCase _deletePetUseCase;

        public PetController(IPetService petService, CreatePetUseCase createPetUseCase, UpdatePetUseCase updatePetUseCase, DeletePetUseCase deletePetUseCase)
        {
            _petService = petService;
            _createPetUseCase = createPetUseCase;
            _updatePetUseCase = updatePetUseCase;
            _deletePetUseCase = deletePetUseCase;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreatePetDTO dto)
        {
            try
            {
                _createPetUseCase.Run(dto);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult FindById(Guid id)
        {
            try
            {
                var pet = _petService.FindById(id); 

                var response = new PetResponseDTO
                {
                    Id = pet.Id,
                    Species = pet.Species.Value,
                    Race = pet.Race.Value,
                    Name = pet.Name.Value,
                    Rg = pet.Rg.Value,
                    BirthDate = pet.BirthDate,
                    OwnerId = pet.OwnerId
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] UpdatePetDTO dto)
        {
            try
            {
                _updatePetUseCase.Run(id, dto);
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
                _deletePetUseCase.Run(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
