using CadastroVetano.DTO.Appointments;
using CadastroVetano.Entities.Appointments;

namespace CadastroVetano.Interfaces.IServices
{
    public interface IAppointmentService
    {
        public Appointment FindById(Guid id);
        public void CreateAppointment(CreateAppointmentDTO appointment);
        public void UpdateAppointment(Guid appointmentId, UpdateAppointmentDTO appointment);
        public void DeleteAppointment(Guid Id);

    }
}
