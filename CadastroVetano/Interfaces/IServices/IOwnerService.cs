using CadastroVetano.DTO.Owners;
using CadastroVetano.Entities.Owners;

namespace Cadastro.Interfaces.IServices
{
    public interface IOwnerService
    {
        public Owner FindById(Guid id);
        public void CreateOwner(CreateOwnerDTO owner);
        public void UpdateOwner(Guid Id, UpdateOwnerDTO owner);
        public void DeleteOwner(Guid Id);

    }
}
