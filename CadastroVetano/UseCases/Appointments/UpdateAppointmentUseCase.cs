using CadastroVetano.DTO.Appointments;
using CadastroVetano.Entities.Appointments;
using CadastroVetano.Interfaces.IRepositories;

namespace CadastroVetano.UseCases.Appointments
{
    public class UpdateAppointmentUseCase
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public UpdateAppointmentUseCase(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public void Run(Guid appointmentId, UpdateAppointmentDTO dto)
        {

            var existing = _appointmentRepository.FindByDate(dto.Date);

            if (existing != null && existing.Id != appointmentId)
            {
                throw new Exception("Ja existe uma consulta marcada neste horario.");
            }

            Appointment appointment = _appointmentRepository.FindById(appointmentId);

            appointment.ChangeAppointment(dto.Date);
        }
    }
}
