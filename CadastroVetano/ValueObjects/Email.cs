namespace CadastroVetano.ValueObjects
{
    public class Email
    {
        public string Value { get; private set; }

        public Email(string value)
        {
            if(string.IsNullOrEmpty(value) || !value.Contains("@"))
            {
                throw new Exception("Email invalido.");
            }
            this.Value = value.Trim();
        }
    }
}
