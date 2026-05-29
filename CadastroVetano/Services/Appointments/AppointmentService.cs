using CadastroVetano.DTO.Appointments;
using CadastroVetano.Entities.Appointments;
using CadastroVetano.Interfaces.IRepositories;
using CadastroVetano.Interfaces.IServices;

namespace CadastroVetano.Services.Appointments
{
    public class AppointmentService :IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public Appointment FindById(Guid id)
        {
            return _appointmentRepository.FindById(id);
        }
        public void CreateAppointment(CreateAppointmentDTO dto)
        {
            var appointment = new Appointment(dto.Date, dto.PetId);
            _appointmentRepository.Create(appointment);
        }

        public void UpdateAppointment(Guid appointmentId, UpdateAppointmentDTO dto)
        {
            var existing = _appointmentRepository.FindById(appointmentId);
            existing.ChangeAppointment(dto.Date);
            _appointmentRepository.Update(existing);
        }

        public void DeleteAppointment(Guid Id)
        {
            var existing = _appointmentRepository.FindById(Id);
            _appointmentRepository.Delete(existing);
        }
    }
}
