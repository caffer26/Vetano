using CadastroVetano.ValueObjects;

namespace CadastroVetano.Entities.Owners
{
    public class Owner : EntityBase
    {
        public Guid Id { get; private set; }
        public Name Name {  get; private set; }
        public Cpf Cpf { get; private set; }
        public string EmailValue { get; private set; }
        public Email Email
        {
            get => new Email(EmailValue);
            set => EmailValue = value.Value;
                    
        }
        public PhoneNumber PhoneNumber { get; private set; }
        public DateTime BirthDate { get; set; }
        public List<Pet> Pets { get; set; } = new List<Pet>();
        
        public Owner(Name name, Cpf cpf, PhoneNumber phoneNumber, DateTime birthDate, Email email)
        {
            this.Name = name;
            this.Cpf = cpf;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.BirthDate = birthDate;
        }

        public Owner(Guid Id, Name name, Cpf cpf, PhoneNumber phoneNumber, DateTime birthDate, Email email)
        {
            this.Id = Id;
            this.Name = name;
            this.Cpf = cpf;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.BirthDate = birthDate;
        }

        public void ChangeOwner(string name, string email, string phoneNumber)
        {
            this.Name = new Name(name);
            this.Email = new Email(email);
            this.PhoneNumber = new PhoneNumber(phoneNumber);
        }
    }
}
