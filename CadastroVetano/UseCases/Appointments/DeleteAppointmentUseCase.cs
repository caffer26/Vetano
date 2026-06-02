using CadastroVetano.Entities.Appointments;
using CadastroVetano.Interfaces.IRepositories;

namespace CadastroVetano.UseCases.Appointments
{
    public class DeleteAppointmentUseCase
    {

        private readonly IAppointmentRepository _appointmentRepository;

        public DeleteAppointmentUseCase(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public void Run(Guid appointmentId)
        {
            Appointment appointment = _appointmentRepository.FindById(appointmentId);

            _appointmentRepository.Delete(appointment);
        }

    }
}
