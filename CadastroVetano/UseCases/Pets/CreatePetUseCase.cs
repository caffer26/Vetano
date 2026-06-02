using Cadastro.Interfaces.IRepositories;
using CadastroVetano.DTO.Pets;
using CadastroVetano.Entities;
using CadastroVetano.Entities.Owners;
using CadastroVetano.ValueObjects;

namespace CadastroVetano.UseCases.Pets
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
            var pet = new Pet(new Species(dto.Species), new Name(dto.Name), new Race(dto.Race), new Rg(dto.Rg), dto.BirthDate, dto.OwnerId);

            _petRepository.Create(pet);
        }
    }
}
