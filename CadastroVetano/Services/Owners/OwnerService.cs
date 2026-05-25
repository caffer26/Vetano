using Cadastro.Interfaces.IRepositories;
using Cadastro.Interfaces.IServices;
using CadastroVetano.DTO.Owners;
using CadastroVetano.Entities.Owners;
using CadastroVetano.UseCases.Owners;

namespace CadastroVetano.Services.Owners
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;

        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }
        
        public Owner FindById(Guid id)
        {
            return _ownerRepository.FindById(id);
        }

        public void CreateOwner(CreateOwnerDTO dto)
        {
            var owner = new Owner
            {
                Name = dto.Name ?? throw new Exception("Nome obrigatorio."),
                Email = dto.Email ?? throw new Exception("Email obrigatorio."),
                PhoneNumber = dto.PhoneNumber ?? throw new Exception("Telefone obrigatorio."),
                BirthDate = dto.BirthDate
            };
            _ownerRepository.Create(owner);
        }

        public void UpdateOwner(Guid ownerId, Owner owner)
        {
            Owner existing = _ownerRepository.FindById(ownerId);
            existing.Name = owner.Name;
            existing.Email = owner.Email;
            existing.PhoneNumber = owner.PhoneNumber;
            _ownerRepository.Update(existing);
        }

        public void DeleteOwner(Guid ownerId) {
            Owner owner = _ownerRepository.FindById(ownerId);
            _ownerRepository.Delete(owner);
        }
    }
}
