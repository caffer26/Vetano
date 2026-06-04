using CadastroVetano.Register.Entities.Owners;
using CadastroVetano.Register.DTO.Pets;
using CadastroVetano.Register.Interfaces.IRepositories;
using CadastroVetano.Register.ValueObjects;

namespace CadastroVetano.Register.UseCases.Pets
{
    public class CreatePetUseCase
    {
        private readonly IPetRepository _petRepository;

        public CreatePetUseCase(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public void Run(CreatePetDTO dto)
        {
            var existing = _petRepository.FindByRg(dto.Rg);

            if(existing != null)
            {
                throw new Exception("Pet com rg ja cadastrado.");
            }

            var pet = new Pet(new Species(dto.Species), new Name(dto.Name), new Race(dto.Race), new Rg(dto.Rg), dto.BirthDate, dto.OwnerId);

            _petRepository.Create(pet);
        }
    }
}
