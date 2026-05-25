using Cadastro.Interfaces.IRepositories;
using CadastroVetano.DataContext;
using CadastroVetano.Entities.Owners;

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
            return _database.Pets.FirstOrDefault(p => p.Id == id);
        }

        public void Create(Pet pet)
        {
            _database.Pets.Add(pet);
            _database.SaveChanges();
        }

        public void Update(Pet pet)
        {
            _database.Pets.Update(pet);
            _database.SaveChanges();
        }
        public void Delete(Pet pet)
        {
            pet.DeletedAt = DateTime.Now;
            _database.Pets.Remove(pet);
            _database.SaveChanges();
        }
    }
}
