using CadastroVetano.ValueObjects;

namespace CadastroVetano.Entities.Owners
{
    public class Pet : EntityBase
    {
        public Guid Id { get; private set; }
        public Species Species {  get; private set; }
        public Race Race { get; private set; }
        public Name Name { get; private set; }
        public Rg Rg { get; private set; }
        public DateTime BirthDate { get; private set; }
        public Owner Owner { get; private set; }
        public Guid OwnerId { get; private set; }

        public Pet(Species species, Race race, Rg rg, DateTime birthDate, Guid ownerId) 
        { 
            this.Species = species;
            this.Race = race;
            this.Rg = rg;
            this.BirthDate = birthDate;
            this.OwnerId = ownerId;
        }


        public void ChangePet(string species, string race)
        {
            this.Species = new Species(species);
            this.Race = new Race(race);
        }
    }
}
