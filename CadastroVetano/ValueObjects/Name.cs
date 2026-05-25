namespace CadastroVetano.ValueObjects
{
    public class Name
    {
        public string Value { get; private set; }

        public Name(string value)
        {
            if(string.IsNullOrEmpty(value))
            {
                throw new Exception("Nome nao pode ser nulo.");
            }

            this.Value = value.Trim();
        }
    }
}
