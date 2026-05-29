using CadastroVetano.DataContext;
using CadastroVetano.DataContext.Models;
using CadastroVetano.Entities.Appointments;
using CadastroVetano.Interfaces.IRepositories;

namespace CadastroVetano.Repositories.Appointments
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
            AppointmentModel apm = AppointmentToMap(appointment);
            _database.Appointments.Update(apm);
            _database.SaveChanges();
        }

        public void Delete(Appointment appointment)
        {
            var apm = AppointmentToMap(appointment);
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

        public Appointment FindById(Guid Id)
        {
            AppointmentModel apm = _database.Appointments.FirstOrDefault(a => a.Id == Id);
            return MapToAppointment(apm);
        } 
    }
}
