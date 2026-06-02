using CadastroVetano.Entities.Appointments;

namespace CadastroVetano.Interfaces.IRepositories
{
    public interface IAppointmentRepository
    {
        public Appointment? FindById(Guid Id);
        public Appointment FindPetById(Guid petId);
        public Appointment FindByDate(DateTime date);
        public void Create(Appointment appointment);
        public void Update(Appointment appointment);
        public void Delete(Appointment appointment);

    }
}
