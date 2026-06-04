using CadastroVetano.DataContext.Models;
using CadastroVetano.Appointments.Entities.Appointments;
using CadastroVetano.Register.Entities.Owners;
using CadastroVetano.Register.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CadastroVetano.DataContext
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<OwnerModel> Owners { get; set; }
        public DbSet<PetModel> Pets { get; set; }
        public DbSet<AppointmentModel> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<OwnerModel>(entity =>
            {
                entity.ToTable("Owners");
                entity.HasKey(o => o.Id);
                entity.Property(o => o.Name).IsRequired();
                entity.Property(o => o.Cpf).IsRequired();
                entity.Property(o => o.Email).IsRequired();
                entity.Property(o => o.PhoneNumber).IsRequired();
                entity.Property(o => o.BirthDate).IsRequired();

                //Relacionamento
                entity.HasMany(o => o.Pets)
                      .WithOne(p => p.Owner)
                      .HasForeignKey(p => p.OwnerId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<PetModel>(entity =>
            {
                entity.ToTable("Pets");
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Name).IsRequired();
                entity.Property(p => p.Species).IsRequired();
                entity.Property(p => p.Race).IsRequired();
                entity.Property(p => p.Rg).IsRequired();
                entity.Property(p => p.BirthDate).IsRequired();

                //Relacionamento
                entity.HasMany(p => p.Appointments)
                      .WithOne(a => a.Pet)
                      .HasForeignKey(a => a.PetId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<AppointmentModel>(entity =>
            {
                entity.ToTable("Appointments");
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Date).IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
