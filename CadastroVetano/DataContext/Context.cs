using CadastroVetano.DataContext.Models;
using CadastroVetano.Entities.Appointments;
using CadastroVetano.Entities.Owners;
using CadastroVetano.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace CadastroVetano.DataContext
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options) { }

        public DbSet<OwnerModel> Owners { get; set; }
        public DbSet<PetModel> Pets { get; set; }
        public DbSet<AppointmentModel> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OwnerModel>()
                .OwnsOne(o => o.Name, n =>
                {
                    n.Property(p => p.Value).HasColumnName("Name");
                })
                .OwnsOne(o => o.Cpf, c =>
                {
                    c.Property(p => p.Value).HasColumnName("Cpf");
                })
                .OwnsOne(o => o.Email, e =>
                {
                    e.Property(p => p.Value).HasColumnName("Email");
                })
                .OwnsOne(o => o.PhoneNumber, p =>
                {
                    p.Property(p => p.Value).HasColumnName("PhoneNumber");
                });

            modelBuilder.Entity<PetModel>()
                .OwnsOne(p => p.Species, s =>
                {
                    s.Property(p => p.Value).HasColumnName("Species");
                })
                .OwnsOne(p => p.Race, b =>
                {
                    b.Property(p => p.Value).HasColumnName("Race");
                });

            modelBuilder.Entity<AppointmentModel>(a =>
            {
                a.Property(x => x.Date).HasColumnName("AppointmentDate");
            });
        }
    }
}
