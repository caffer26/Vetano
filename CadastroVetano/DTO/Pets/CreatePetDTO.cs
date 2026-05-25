using CadastroVetano.ValueObjects;

namespace CadastroVetano.DTO.Pets
{
    public class CreatePetDTO
    {
        public string Species { get; set; }
        public string Race { get; set; }
        public string Name { get; set; }
        public DateOnly BirthDate { get; set; }
        public Guid OwnerId { get; set; }
    }
}
