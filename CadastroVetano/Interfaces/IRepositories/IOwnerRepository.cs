using CadastroVetano.Entities.Owners;

namespace Cadastro.Interfaces.IRepositories
{
    public interface IOwnerRepository
    {
        public Owner? FindById(Guid Id);
        public void Create(Owner owner);
        public void Update(Owner owner);
        public void Delete(Owner owner);

    }
}
