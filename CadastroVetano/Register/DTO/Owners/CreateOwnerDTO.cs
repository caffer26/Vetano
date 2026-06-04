using CadastroVetano.Register.ValueObjects;

namespace CadastroVetano.Register.DTO.Owners
{
    public class CreateOwnerDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }

    }
}
