namespace CadastroVetano.Register.ValueObjects
{
    public class Cpf
    {
        public string Value { get; private set; }

        public Cpf(string value)
        {
            if(string.IsNullOrEmpty(value) || value.Length != 11)
            {
                throw new Exception("Cpf invalido.");
            }
            this.Value = value.Trim();
        }
    }
}
