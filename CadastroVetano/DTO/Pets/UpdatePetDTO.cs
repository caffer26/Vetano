using CadastroVetano.ValueObjects;

namespace CadastroVetano.DTO.Pets
{
    public class UpdatePetDTO
    {
        public Name Name { get; set; }
        public Species Species { get; set; }
        public Race Race { get; set; }
    }
}
