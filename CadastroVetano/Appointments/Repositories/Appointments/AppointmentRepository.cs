using CadastroVetano.Appointments.Entities.Appointments;
using CadastroVetano.Appointments.Interfaces.IRepositories;
using CadastroVetano.DataContext;
using CadastroVetano.DataContext.Models;

namespace CadastroVetano.Appointments.Repositories.Appointments
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly Context _database;

        public AppointmentRepository(Context database)
        {
            _database = database;
        }

        public void Create(Appointment appointment)
        {
            AppointmentModel apm = AppointmentToMap(appointment);
            _database.Appointments.Add(apm);
            _database.SaveChanges();
        }

        public void Update(Appointment appointment)
        {
            var apm = _database.Appointments.FirstOrDefault(a => a.Id == appointment.Id);

            apm.Date = appointment.Date;

            _database.SaveChanges();
        }

        public void Delete(Appointment appointment)
        {
            var apm = _database.Appointments.FirstOrDefault(a => a.Id == appointment.Id);
            appointment.DeletedAt = DateTime.Now;
            _database.Remove(apm);
            _database.SaveChanges();
        }

        private Appointment MapToAppointment(AppointmentModel apm)
        {
            return new Appointment(apm.Id, apm.Date, apm.PetId);
        }

        private AppointmentModel AppointmentToMap(Appointment ap)
        {
            return new AppointmentModel(ap.Id, ap.Date, ap.PetId);
        }

        public List<Appointment> FindAll()
        {
            var apm = _database.Appointments.ToList();
            return apm.Select(apm => MapToAppointment(apm)).ToList();
        }
        public Appointment FindById(Guid Id)
        {
            AppointmentModel apm = _database.Appointments.FirstOrDefault(a => a.Id == Id);
            if (apm == null) return null;
            return MapToAppointment(apm);
        } 

        public Appointment FindPetById(Guid petId)
        {
            AppointmentModel apm = _database.Appointments.FirstOrDefault(a => a.PetId == petId);
            if(apm==null) return null;
            return MapToAppointment(apm);
        }

        public Appointment FindByDate(DateTime date) 
        {
            AppointmentModel apm = _database.Appointments.FirstOrDefault(a => a.Date == date);
            if (apm == null) return null;
            return MapToAppointment(apm);
        }
    }
}
