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
    }
}
