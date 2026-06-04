using CadastroVetano.Register.Entities.Owners;
using CadastroVetano.Register.Interfaces.IRepositories;

namespace CadastroVetano.Register.UseCases.Owners
{
    public class DeleteOwnerUseCase
    {
        private readonly IOwnerRepository _ownerRepository;

        public DeleteOwnerUseCase(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        public void Run(Guid ownerId) 
        {
            Owner owner = _ownerRepository.FindById(ownerId);
            
            _ownerRepository.Delete(owner);
        }
    }
}
