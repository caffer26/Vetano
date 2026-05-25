using Cadastro.Interfaces.IRepositories;
using CadastroVetano.DTO.Owners;
using CadastroVetano.ValueObjects;
using CadastroVetano.Entities;
using CadastroVetano.Entities.Owners;

namespace CadastroVetano.UseCases.Owners
{
    public class CreateOwnerUseCase
    {
        private readonly IOwnerRepository _ownerRepository;

        public CreateOwnerUseCase(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        public void Run(CreateOwnerDTO dto)
        {
            var owner = new Owner(new Name(dto.Name), new Cpf(dto.Cpf), new PhoneNumber(dto.PhoneNumber), dto.BirthDate, new Email(dto.Email));

            _ownerRepository.Create(owner);
        }
    }
}
