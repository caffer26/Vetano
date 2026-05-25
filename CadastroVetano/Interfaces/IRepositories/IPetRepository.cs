using CadastroVetano.Entities.Owners;

namespace Cadastro.Interfaces.IRepositories
{
    public interface IPetRepository
    {
        public Pet? FindById(Guid Id);
        public void Create(Pet pet);
        public void Update(Pet pet);
        public void Delete(Pet pet);
        
    }
}
