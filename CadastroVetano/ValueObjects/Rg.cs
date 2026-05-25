namespace CadastroVetano.ValueObjects
{
    public class Rg
    {
        public string Value { get; private set; }
        public Rg(string value)
        {
            if(string.IsNullOrEmpty(value))
            {
                throw new Exception("Rg invalido.");
            }
            this.Value = value.Trim();
        }
    }
}
