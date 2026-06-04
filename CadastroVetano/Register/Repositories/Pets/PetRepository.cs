using CadastroVetano.DataContext;
using CadastroVetano.DataContext.Models;
using CadastroVetano.Register.Entities.Owners;
using CadastroVetano.Register.Interfaces.IRepositories;
using CadastroVetano.Register.ValueObjects;

namespace CadastroVetano.Register.Repositories.Pets
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
            if (pm == null) return null;
            return MapToPet(pm);
        }

        public Pet FindByRg(string rg)
        {
            PetModel pm = _database.Pets.FirstOrDefault(p => p.Rg == rg);
            if (pm == null) return null;
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
            var pm = _database.Pets.FirstOrDefault(p => p.Id == pet.Id);

            pm.Species = pet.Species.Value;
            pm.Race = pet.Race.Value;
            pm.Name = pet.Name.Value;

            _database.Pets.Update(pm);
            _database.SaveChanges();
        }
        public void Delete(Pet pet)
        {
            var pm = _database.Pets.FirstOrDefault(p => p.Id == pet.Id);
            pet.DeletedAt = DateTime.Now;
            _database.Pets.Remove(pm);
            _database.SaveChanges();
        }

        private Pet MapToPet(PetModel pm)
        {
            return new Pet(pm.Id, new Species(pm.Species), new Name(pm.Name), new Race(pm.Race), new Rg(pm.Rg), pm.BirthDate, pm.OwnerId);
        }

        private PetModel PetToMap(Pet pet)
        {
            return new PetModel(pet.Id, pet.Species.Value, pet.Race.Value, pet.Name.Value, pet.Rg.Value, pet.BirthDate, pet.OwnerId);
        }

    }
}
