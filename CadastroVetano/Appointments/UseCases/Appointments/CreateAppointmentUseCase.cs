using CadastroVetano.Appointments.DTO.Appointments;
using CadastroVetano.Appointments.Interfaces.IRepositories;
using CadastroVetano.Appointments.Entities.Appointments;
using CadastroVetano.Register.Interfaces.IRepositories;

namespace CadastroVetano.Appointments.UseCases.Appointments
{
    public class CreateAppointmentUseCase
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IPetRepository _petRepository;

        public CreateAppointmentUseCase(IAppointmentRepository appointmentRepository, IPetRepository petRepository)
        {
            _appointmentRepository = appointmentRepository;
            _petRepository = petRepository;
        }

        public void Run(CreateAppointmentDTO dto)
        {
            var existing = _appointmentRepository.FindByDate(dto.Date);
            var pet = _petRepository.FindById(dto.PetId);

            if (pet == null)
            {
                throw new Exception("Pet não encontrado.");
            }

            if (existing != null)
            {
                throw new Exception("Ja existe uma consulta marcada neste horario.");
            }

            var appointment = new Appointment(dto.Date, dto.PetId);
            _appointmentRepository.Create(appointment);

        }

    }
}
