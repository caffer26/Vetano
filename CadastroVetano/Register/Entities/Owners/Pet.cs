using CadastroVetano.Appointments.Entities;
using CadastroVetano.Register.Entities;
using CadastroVetano.Register.ValueObjects;

namespace CadastroVetano.Register.Entities.Owners
{
    public class Pet : EntityBase
    {
        public Species Species {  get; private set; }
        public Race Race { get; private set; }
        public Name Name { get; private set; }
        public Rg Rg { get; private set; }
        public DateTime BirthDate { get; private set; }
        public Owner Owner { get; private set; }
        public Guid OwnerId { get; private set; }

        public Pet(Species species, Name name, Race race, Rg rg, DateTime birthDate, Guid ownerId) 
        { 
            this.Species = species;
            this.Name = name;
            this.Race = race;
            this.Rg = rg;
            this.BirthDate = birthDate;
            this.OwnerId = ownerId;
        }

        public Pet(Guid Id, Species species, Name name, Race race, Rg rg, DateTime birthDate, Guid ownerId)
        {
            this.Id = Id;
            this.Name = name;
            this.Species = species;
            this.Race = race;
            this.Rg = rg;
            this.BirthDate = birthDate;
            this.OwnerId = ownerId;
        }

        public void ChangePet(string name, string species, string race)
        {
            this.Name = new Name(name);
            this.Species = new Species(species);
            this.Race = new Race(race);
        }
    }
}
