using CadastroVetano.DataContext.Models;
using CadastroVetano.Entities.Owners;
using CadastroVetano.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace CadastroVetano.DataContext
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options) { }

        public DbSet<OwnerModel> Owners { get; set; }
        public DbSet<Pet> Pets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // OWNER
            modelBuilder.Entity<Owner>()
                .ToTable("Owners");

            modelBuilder.Entity<Owner>()
                .HasKey(o => o.Id);

            modelBuilder.Entity<Owner>()
                .Property(o => o.Name)
                .IsRequired()
                .HasMaxLength(100);

            // PET
            modelBuilder.Entity<Pet>()
                .ToTable("Pets");

            modelBuilder.Entity<Pet>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Pet>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            // RELACIONAMENTO
            modelBuilder.Entity<Pet>()
                .HasOne(p => p.Owner)
                .WithMany(o => o.Pets)
                .HasForeignKey(p => p.OwnerId);

            base.OnModelCreating(modelBuilder);
        }


    }
}
