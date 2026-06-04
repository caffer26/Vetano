namespace CadastroVetano.Appointments.Entities.Appointments

{
    public class Appointment : EntityBase
    {
        public DateTime Date { get; private set; }
        public Guid PetId { get; private set; }

        public Appointment(DateTime date, Guid petId)
        {

            if (date < DateTime.Now)
                throw new Exception("Data não pode ser no passado.");

            this.Date = date;
            this.PetId = petId;
        }

        public Appointment(Guid id, DateTime date, Guid petId)
        {
            this.Id = id;
            this.Date = date;
            this.PetId = petId;
        }

        public void ChangeAppointment(DateTime date)
        {
            this.Date = date;
        }
    }
}
