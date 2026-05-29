using Cadastro.Interfaces.IRepositories;
using CadastroVetano.DataContext;
using CadastroVetano.DataContext.Models;
using CadastroVetano.Entities.Owners;
using CadastroVetano.ValueObjects;

namespace CadastroVetano.Repositories.Pets
{
    public class PetRepository : IPetRepository
    {
        private readonly Context _database;

        public PetRepository(Context context)
        {
            _database = context;
        }

        public Pet FindById(Guid id)
        {
            PetModel pm = _database.Pets.FirstOrDefault(p => p.Id == id);
            return MapToPet(pm);
        }

        public void Create(Pet pet)
        {
            PetModel pm = PetToMap(pet);
            _database.Pets.Add(pm);
            _database.SaveChanges();
        }

        public void Update(Pet pet)
        {
            PetModel pm = PetToMap(pet);
            _database.Pets.Update(pm);
            _database.SaveChanges();
        }
        public void Delete(Pet pet)
        {
            var pm = PetToMap(pet);
            pet.DeletedAt = DateTime.Now;
            _database.Pets.Remove(pm);
            _database.SaveChanges();
        }

        private Pet MapToPet(PetModel pm)
        {
            return new Pet(pm.Id, new Species(pm.Species), new Race(pm.Race), new Rg(pm.Rg), pm.BirthDate, pm.OwnerId);
        }

        private PetModel PetToMap(Pet pet)
        {
            return new PetModel(pet.Id, pet.Species.Value, pet.Race.Value, pet.Name.Value, pet.Rg.Value, pet.BirthDate, pet.OwnerId);
        }

    }
}
