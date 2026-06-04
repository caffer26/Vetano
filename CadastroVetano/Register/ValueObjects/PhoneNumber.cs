namespace CadastroVetano.Register.ValueObjects
{
    public class PhoneNumber
    {
        public string Value { get; set; }
        public PhoneNumber(string value)
        {
            if(string.IsNullOrEmpty(value) || value.Length < 9)
            {
                throw new Exception("Telefone invalido.");
            }
            this.Value = value;
        }
    }
}
