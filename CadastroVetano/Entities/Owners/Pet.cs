using CadastroVetano.ValueObjects;

namespace CadastroVetano.Entities.Owners
{
    public class Pet : EntityBase
    {
        public Guid Id { get; private set; }
        public Species Species {  get; set; }
        public Race Race { get; set; }
        public Name Name { get; set; }
        public Rg Rg { get; private set; }
        public DateOnly BirthDate { get; set; }
        public Owner Owner { get; private set; }
        public Guid OwnerId { get; private set; }

        public void UpdatePet(Species species, Race race)
        {
            this.Species = species;
            this.Race = race;
        }
    }
}
