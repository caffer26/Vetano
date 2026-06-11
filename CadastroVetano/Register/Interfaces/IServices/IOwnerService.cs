using CadastroVetano.Register.DTO.Owners;
using CadastroVetano.Register.Entities.Owners;

namespace CadastroVetano.Register.Interfaces.IServices
{
    public interface IOwnerService
    {
        public Owner FindById(Guid id);
        public List<Owner> FindAll();

    }
}
