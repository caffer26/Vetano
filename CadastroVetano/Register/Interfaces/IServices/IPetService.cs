using CadastroVetano.Register.DTO.Pets;
using CadastroVetano.Register.Entities.Owners;

namespace CadastroVetano.Register.Interfaces.IServices
{
    public interface IPetService
    {
        public Pet FindById(Guid Id);
        public void CreatePet(CreatePetDTO pet);
        public void UpdatePet(Guid Id, UpdatePetDTO dto);
        public void DeletePet(Guid Id);

    }
}
