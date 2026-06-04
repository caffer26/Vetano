using CadastroVetano.Appointments.Entities.Appointments;
using CadastroVetano.Appointments.Interfaces.IRepositories;

namespace CadastroVetano.Appointments.UseCases.Appointments
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
