using CadastroVetano.Register.DTO.Pets;
using CadastroVetano.Register.Entities.Owners;

namespace CadastroVetano.Register.Interfaces.IServices
{
    public interface IPetService
    {
        public Pet FindById(Guid Id);
        public List<Pet> FindAll();

    }
}
