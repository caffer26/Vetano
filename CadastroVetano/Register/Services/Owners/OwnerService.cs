using CadastroVetano.Register.DTO.Owners;
using CadastroVetano.Register.Entities.Owners;
using CadastroVetano.Register.Interfaces.IRepositories;
using CadastroVetano.Register.Interfaces.IServices;
using CadastroVetano.Register.UseCases.Owners;
using CadastroVetano.Register.ValueObjects;

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

        
        public List<Owner> FindAll()
        {
            return _ownerRepository.FindAll();
        }

    }
}
