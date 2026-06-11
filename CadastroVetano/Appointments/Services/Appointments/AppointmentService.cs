using CadastroVetano.Appointments.DTO.Appointments;
using CadastroVetano.Appointments.Entities.Appointments;
using CadastroVetano.Appointments.Interfaces.IRepositories;
using CadastroVetano.Appointments.Interfaces.IServices;

namespace CadastroVetano.Appointments.Services.Appointments
{
    public class AppointmentService :IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public List<Appointment> FindAll()
        {
            return _appointmentRepository.FindAll();
        }
        public Appointment FindById(Guid id)
        {
            return _appointmentRepository.FindById(id);
        }
    }
}
