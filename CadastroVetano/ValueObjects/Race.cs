namespace CadastroVetano.ValueObjects
{
    public class Race
    {
        public string Value { get; private set; }

        public Race(string value)
        {
            if(string.IsNullOrEmpty(value))
            {
                throw new Exception("Raca invalida.");
            }
            this.Value = value.Trim();
        }
    }
}
