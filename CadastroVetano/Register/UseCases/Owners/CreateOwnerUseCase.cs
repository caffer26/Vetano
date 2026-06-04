using CadastroVetano.Register.ValueObjects;
using CadastroVetano.Register.DTO.Owners;
using CadastroVetano.Register.Interfaces.IRepositories;
using CadastroVetano.Register.Entities.Owners;

namespace CadastroVetano.Register.UseCases.Owners
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
            var existing = _ownerRepository.FindByCpf(dto.Cpf);

            if (existing != null)
            {
                throw new Exception("CPF ja cadastrado.");
            }

            var owner = new Owner(new Name(dto.Name), new Cpf(dto.Cpf), new PhoneNumber(dto.PhoneNumber), dto.BirthDate, new Email(dto.Email));

            _ownerRepository.Create(owner);
        }
    }
}
