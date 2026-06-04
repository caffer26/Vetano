using CadastroVetano.Register.Entities.Owners;

namespace CadastroVetano.Register.Interfaces.IRepositories
{
    public interface IPetRepository
    {
        public Pet? FindById(Guid Id);
        public Pet? FindByRg(string Rg);
        public void Create(Pet pet);
        public void Update(Pet pet);
        public void Delete(Pet pet);
        
    }
}
