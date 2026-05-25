using Cadastro.Interfaces.IRepositories;
using CadastroVetano.DTO.Pets;
using CadastroVetano.Entities;

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
            var pet = new Pet
            {
                Name = dto.Name ?? throw new Exception("Nome obrigatorio."),
                Species = dto.Species ?? throw new Exception("Especie obrigatoria."),
                Race = dto.Race ?? throw new Exception("Raça obrigatoria."),
                BirthDate = dto.BirthDate
            };

            _petRepository.Create(pet);
        }
    }
}
