using Cadastro.Interfaces.IRepositories;
using CadastroVetano.DataContext;
using CadastroVetano.DataContext.Models;
using CadastroVetano.Entities.Owners;
using CadastroVetano.ValueObjects;
using Microsoft.EntityFrameworkCore;

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
            var om = OwnerToMap(owner);
            _database.Owners.Add(om);
            _database.SaveChanges();
        }

        public void Update(Owner owner)
        {
            var om = _database.Owners.FirstOrDefault(o => o.Id == owner.Id); ;
            om.Name = owner.Name.Value;
            om.Cpf = owner.Cpf.Value;
            om.PhoneNumber = owner.PhoneNumber.Value;
            _database.SaveChanges();
        }

        public Owner FindById(Guid Id)
        {
            OwnerModel om = _database.Owners.FirstOrDefault(o => o.Id == Id);

            if (om == null) return null;

            return MapToOwner(om);
        }

        public List<Owner> FindAll()
        {
            var om = _database.Owners.ToList();
            return om.Select(om => MapToOwner(om)).ToList();
        }

        public Owner FindByCpf(string cpf)
        {
            OwnerModel om = _database.Owners.FirstOrDefault(o => o.Cpf == cpf);

            if (om == null) return null;

            return MapToOwner(om);
        }

        private Owner MapToOwner(OwnerModel om)
        {
            return new Owner(om.Id, new Name(om.Name), new Cpf(om.Cpf), new PhoneNumber(om.PhoneNumber), om.BirthDate, new Email(om.Email));
        }

        private OwnerModel OwnerToMap(Owner om)
        {
            return new OwnerModel(om.Id,om.Name.Value,om.Cpf.Value,om.PhoneNumber.Value,om.BirthDate,om.Email.Value);
        }

        public void Delete(Owner owner)
        {
            var om = _database.Owners.FirstOrDefault(o => o.Id == owner.Id);
            owner.DeletedAt = DateTime.Now;
            _database.Owners.Remove(om);
            _database.SaveChanges();
        }
    }
}
