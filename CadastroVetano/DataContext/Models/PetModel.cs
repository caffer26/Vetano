using CadastroVetano.Entities.Owners;
using CadastroVetano.ValueObjects;

namespace CadastroVetano.DataContext.Models
{
    public class PetModel
    {
        public Guid Id { get;  set; }
        public string Species { get;  set; }
        public string Race { get;  set; }
        public string Name { get;  set; }
        public string Rg { get;  set; }
        public DateTime BirthDate { get;  set; }
        public Guid OwnerId { get;  set; }
        public OwnerModel Owner { get; set; }
        public List<AppointmentModel> Appointments { get; set; }

        public PetModel(Guid Id, string species, string race, string name, string rg, DateTime birthDate, Guid ownerId)
        {
            this.Id = Id;
            this.Species = species;
            this.Race = race;
            this.Name = name;
            this.Rg = rg;
            this.BirthDate = birthDate;
            this.OwnerId = ownerId;
        }
    }
}
