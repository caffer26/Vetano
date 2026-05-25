using Cadastro.Interfaces.IRepositories;
using CadastroVetano.DataContext;
using CadastroVetano.DataContext.Models;
using CadastroVetano.Entities.Owners;
using CadastroVetano.ValueObjects;

namespace CadastroVetano.Repositories.Owners
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly Context _database;

        public OwnerRepository(Context context)
        {
            _database = context;
        }

        public void Create(Owner owner)
        {
            _database.Owners.Add(owner);
            _database.SaveChanges();
        }

        public void Update(Owner owner)
        {
            _database.Owners.Update(owner);
            _database.SaveChanges();
        }

        public Owner FindById(Guid Id)
        {
            OwnerModel om = _database.Owners.FirstOrDefault(o => o.Id == Id);
            return MapToOwner(om);
        }

        private Owner MapToOwner(OwnerModel om)
        {
            return new Owner(om.Id, new Name(om.Name), new Cpf(om.Cpf), new PhoneNumber(om.PhoneNumber), om.BirthDate, new Email(om.Email));
        }

        public void Delete(Owner owner)
        {
            owner.DeletedAt = DateTime.Now;
            _database.Owners.Update(owner);
            _database.SaveChanges();
        }
    }
}
