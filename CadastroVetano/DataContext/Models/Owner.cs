using CadastroVetano.ValueObjects;

namespace CadastroVetano.DataContext.Models
{
    public class OwnerModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string EmailValue { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
    }
}
