using CadastroVetano.Register.DTO.Pets;
using CadastroVetano.Register.Entities.Owners;
using CadastroVetano.Register.Interfaces.IRepositories;

namespace CadastroVetano.Register.UseCases.Pets
{
    public class UpdatePetUseCase
    {
        private readonly IPetRepository _petRepository;

        public UpdatePetUseCase(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public void Run(Guid petId, UpdatePetDTO dto)
        {
            Pet pet = _petRepository.FindById(petId);

            if (pet == null) 
            {
                throw new Exception("Pet nao encontrado");            
            }

            pet.ChangePet(dto.Species, dto.Race);

            _petRepository.Update(pet);
        }
    }
}
