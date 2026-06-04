using CadastroVetano.Register.ValueObjects;

namespace CadastroVetano.Register.DTO.Pets
{
    public class CreatePetDTO
    {
        public string Species { get; set; }
        public string Race { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Rg {  get; set; }
        public Guid OwnerId { get; set; }
    }
}
