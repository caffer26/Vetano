using Cadastro.Interfaces.IRepositories;
using CadastroVetano.Entities.Owners;

namespace CadastroVetano.UseCases.Pets
{
    public class DeletePetUseCase
    {
        private readonly IPetRepository _petRepository;

        public DeletePetUseCase(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public void Run(Guid petId)
        {
            Pet pet = _petRepository.FindById(petId);

            _petRepository.Delete(pet);
        }
    }
}
