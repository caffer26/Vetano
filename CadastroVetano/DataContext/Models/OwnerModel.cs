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


        public OwnerModel(Guid Id, string Name, string Cpf, string PhoneNumber, DateTime BirthDate, string Email)
        {
            this.Id = Id;
            this.Name = Name;
            this.PhoneNumber = PhoneNumber;
            this.BirthDate = BirthDate;
            this.Email = Email;
            this.Cpf = Cpf;
        }

    }
}
