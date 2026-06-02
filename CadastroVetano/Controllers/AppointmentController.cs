using CadastroVetano.DTO.Appointments;
using CadastroVetano.Interfaces.IServices;
using CadastroVetano.UseCases.Appointments;
using Microsoft.AspNetCore.Mvc;

namespace CadastroVetano.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly CreateAppointmentUseCase _createAppointmentUseCase;
        private readonly UpdateAppointmentUseCase _updateAppointmentUseCase;
        private readonly DeleteAppointmentUseCase _deleteAppointmentUseCase;

        public AppointmentController(IAppointmentService appointmentService, CreateAppointmentUseCase createAppointmentUseCase, UpdateAppointmentUseCase updateAppointmentUseCase, DeleteAppointmentUseCase deleteAppointmentUseCase)
        {
            _appointmentService = appointmentService;
            _createAppointmentUseCase = createAppointmentUseCase;
            _updateAppointmentUseCase = updateAppointmentUseCase;
            _deleteAppointmentUseCase = deleteAppointmentUseCase;
        }


        [HttpPost]
        public IActionResult Create([FromBody] CreateAppointmentDTO dto)
        {
            try
            {
                _createAppointmentUseCase.Run(dto);
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
                var appointment = _appointmentService.FindById(id);
                return Ok(appointment);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] UpdateAppointmentDTO dto)
        {
            try
            {
                _updateAppointmentUseCase.Run(id, dto);
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
                _deleteAppointmentUseCase.Run(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
