namespace CadastroVetano.Entities
{
    public class EntityBase
    {
        public Guid Id {  get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DeletedAt { get; set; }

        public EntityBase()
        {
            this.Id = Guid.NewGuid();
            this.CreatedAt = DateTime.UtcNow;
        }
    }
}
