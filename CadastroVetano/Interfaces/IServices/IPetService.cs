using CadastroVetano.DTO.Pets;
using CadastroVetano.Entities.Owners;

namespace Cadastro.Interfaces.IServices
{
    public interface IPetService
    {
        public Pet FindById(Guid Id);
        public void CreatePet(CreatePetDTO pet);
        public void UpdatePet(Guid Id, UpdatePetDTO dto);
        public void DeletePet(Guid Id);

    }
}
