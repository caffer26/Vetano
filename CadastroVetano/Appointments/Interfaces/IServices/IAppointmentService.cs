using CadastroVetano.Appointments.DTO.Appointments;
using CadastroVetano.Appointments.Entities.Appointments;

namespace CadastroVetano.Appointments.Interfaces.IServices
{
    public interface IAppointmentService
    {
        public Appointment FindById(Guid id);
        public void CreateAppointment(CreateAppointmentDTO appointment);
        public void UpdateAppointment(Guid appointmentId, UpdateAppointmentDTO appointment);
        public void DeleteAppointment(Guid Id);

    }
}
