using CadastroVetano.Register.DTO.Owners;
using CadastroVetano.Register.Entities.Owners;
using CadastroVetano.Register.Interfaces.IRepositories;
using CadastroVetano.Register.Interfaces.IServices;
using CadastroVetano.Register.UseCases.Owners;
using CadastroVetano.Register.ValueObjects;
using Microsoft.AspNetCore.DataProtection.XmlEncryption;

namespace CadastroVetano.Register.Services.Owners
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

        public Owner FindByCpf(string cpf)
        {
            return _ownerRepository.FindByCpf(cpf);
        }

        public List<Owner> FindAll()
        {
            return _ownerRepository.FindAll();
        }

        public void CreateOwner(CreateOwnerDTO dto)
        {
            var owner = new Owner
                (
                    new Name(dto.Name),
                    new Cpf(dto.Cpf), 
                    new PhoneNumber(dto.PhoneNumber), 
                    dto.BirthDate, 
                    new Email(dto.Email)
                 );
            
            _ownerRepository.Create(owner);
        }

        public void UpdateOwner(Guid ownerId, UpdateOwnerDTO dto)
        {
            var owner = _ownerRepository.FindById(ownerId);
            owner.ChangeOwner(dto.Name, dto.Email, dto.PhoneNumber);
            _ownerRepository.Update(owner);
        }

        public void DeleteOwner(Guid ownerId) {
            Owner owner = _ownerRepository.FindById(ownerId);
            _ownerRepository.Delete(owner);
        }
    }
}
