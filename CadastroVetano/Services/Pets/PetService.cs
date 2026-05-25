using Cadastro.Interfaces.IRepositories;
using Cadastro.Interfaces.IServices;
using CadastroVetano.DTO.Pets;
using CadastroVetano.Entities.Owners;

namespace CadastroVetano.Services.Pets
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepository;

        public PetService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public Pet FindById(Guid id)
        {
            return _petRepository.FindById(id);
        }

        public void CreatePet(CreatePetDTO dto)
        {
            var pet = new Pet
            {
                Name = dto.Name ?? throw new Exception("Nome obrigatorio."),
                Race = dto.Race ?? throw new Exception("Raca obrigatoria."),
                Species = dto.Species ?? throw new Exception("Especie obrigatoria."),                
                BirthDate = dto.BirthDate
            };
            _petRepository.Create(pet);
        }

        public void UpdatePet(Guid petId, Pet pet)
        {
            Pet existing = _petRepository.FindById(petId);
            existing.Name = pet.Name;
            existing.Species = pet.Species;
            _petRepository.Update(existing);
        }

        public void DeletePet(Guid petId)
        {
            Pet pet = _petRepository.FindById(petId);
            _petRepository.Delete(pet);
        }
    }
}
