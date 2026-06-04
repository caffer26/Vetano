namespace CadastroVetano.Register.ValueObjects
{
    public class Species
    {
        public string Value { get; private set; }

        public Species(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception("Especie invalida.");
            }
            this.Value = value.Trim();
        }
    }
}
