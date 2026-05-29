using CadastroVetano.Entities.Appointments;

namespace CadastroVetano.Interfaces.IRepositories
{
    public interface IAppointmentRepository
    {
        public Appointment? FindById(Guid Id);
        public void Create(Appointment appointment);
        public void Update(Appointment appointment);
        public void Delete(Appointment appointment);

    }
}
