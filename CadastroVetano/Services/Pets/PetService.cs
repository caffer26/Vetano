using Cadastro.Interfaces.IRepositories;
using Cadastro.Interfaces.IServices;
using CadastroVetano.DTO.Pets;
using CadastroVetano.Entities.Owners;
using CadastroVetano.ValueObjects;

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
            var pet = new Pet(new Species(dto.Species), new Name(dto.Name), new Race(dto.Race), new Rg(dto.Rg), dto.BirthDate, dto.OwnerId);
            _petRepository.Create(pet);
        }

        public void UpdatePet(Guid petId, UpdatePetDTO dto)
        {
            Pet pet = _petRepository.FindById(petId);
            pet.ChangePet(dto.Species, dto.Race);
            _petRepository.Update(pet);

        }

        public void DeletePet(Guid petId)
        {
            Pet pet = _petRepository.FindById(petId);
            _petRepository.Delete(pet);
        }
    }
}
