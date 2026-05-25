using Cadastro.Interfaces.IRepositories;
using CadastroVetano.DTO.Owners;
using CadastroVetano.ValueObjects;
using CadastroVetano.Entities.Owners;

namespace CadastroVetano.UseCases.Owners
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

            owner.Name = dto.Name;
            owner.Email = dto.Email;
            owner.PhoneNumber = dto.PhoneNumber;

            _ownerRepository.Update(owner);
        }
    }
}
