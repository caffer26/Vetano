using CadastroVetano.Register.ValueObjects;
using CadastroVetano.Register.Entities.Owners;
using CadastroVetano.Register.DTO.Owners;
using CadastroVetano.Register.Interfaces.IRepositories;

namespace CadastroVetano.Register.UseCases.Owners
{
    public class UpdateOwnerUseCase
    {

        private readonly IOwnerRepository _ownerRepository;

        public UpdateOwnerUseCase(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        public void Run(Guid ownerId, UpdateOwnerDTO dto)
        {
            Owner owner = _ownerRepository.FindById(ownerId);

            owner.ChangeOwner(dto.Name, dto.Email, dto.PhoneNumber);

            _ownerRepository.Update(owner);
        }
    }
}
