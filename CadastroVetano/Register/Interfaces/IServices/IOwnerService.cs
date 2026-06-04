using CadastroVetano.Register.DTO.Owners;
using CadastroVetano.Register.Entities.Owners;

namespace CadastroVetano.Register.Interfaces.IServices
{
    public interface IOwnerService
    {
        public Owner FindById(Guid id);
        public Owner FindByCpf(string cpf);
        public List<Owner> FindAll();
        public void CreateOwner(CreateOwnerDTO owner);
        public void UpdateOwner(Guid Id, UpdateOwnerDTO owner);
        public void DeleteOwner(Guid Id);

    }
}
