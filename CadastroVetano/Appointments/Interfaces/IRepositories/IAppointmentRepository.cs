using CadastroVetano.Appointments.Entities.Appointments;

namespace CadastroVetano.Appointments.Interfaces.IRepositories
{
    public interface IAppointmentRepository
    {
        public Appointment? FindById(Guid Id);
        public List<Appointment> FindAll();
        public Appointment FindPetById(Guid petId);
        public Appointment FindByDate(DateTime date);
        public void Create(Appointment appointment);
        public void Update(Appointment appointment);
        public void Delete(Appointment appointment);

    }
}
