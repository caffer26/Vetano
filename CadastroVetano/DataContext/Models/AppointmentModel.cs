namespace CadastroVetano.DataContext.Models
{
    public class AppointmentModel
    {
        public Guid Id { get;  set; }
        public DateTime Date { get;  set; }
        public Guid PetId { get;  set; }


        public AppointmentModel(Guid id, DateTime date, Guid petId)
        {
            this.Id = id;
            this.Date = date;
            this.PetId = petId;
        }
    }
}
