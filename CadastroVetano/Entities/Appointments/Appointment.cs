namespace CadastroVetano.Entities.Appointments

{
    public class Appointment : EntityBase
    {
        public Guid Id {  get; private set; }
        public DateTime Date { get; private set; }
        public Guid PetId { get; private set; }

        public Appointment(DateTime date, Guid petId)
        {
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
