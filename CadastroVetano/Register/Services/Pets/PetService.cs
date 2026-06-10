using CadastroVetano.Register.DTO.Pets;
using CadastroVetano.Register.Entities.Owners;
using CadastroVetano.Register.Interfaces.IRepositories;
using CadastroVetano.Register.Interfaces.IServices;
using CadastroVetano.Register.ValueObjects;

namespace CadastroVetano.Register.Services.Pets
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
        public List<Pet> FindAll()
        {
            return _petRepository.FindAll();
        }

        public void CreatePet(CreatePetDTO dto)
        {
            var pet = new Pet(new Species(dto.Species), new Name(dto.Name), new Race(dto.Race), new Rg(dto.Rg), dto.BirthDate, dto.OwnerId);
            _petRepository.Create(pet);
        }

        public void UpdatePet(Guid petId, UpdatePetDTO dto)
        {
            Pet pet = _petRepository.FindById(petId);
            pet.ChangePet(dto.Name, dto.Species, dto.Race);
            _petRepository.Update(pet);

        }

        public void DeletePet(Guid petId)
        {
            Pet pet = _petRepository.FindById(petId);
            _petRepository.Delete(pet);
        }
    }
}
