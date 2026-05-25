using Cadastro.Interfaces.IRepositories;
using CadastroVetano.DTO.Pets;
using CadastroVetano.Entities.Owners;


namespace CadastroVetano.UseCases.Pets
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

            pet.Name = dto.Name;
            pet.Species = dto.Species;
            pet.Race = dto.Race;
        }
    }
}
