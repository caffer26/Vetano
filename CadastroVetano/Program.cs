using Cadastro.Interfaces.IRepositories;
using Cadastro.Interfaces.IServices;
using CadastroVetano.DataContext;
using CadastroVetano.Repositories.Owners;
using CadastroVetano.Repositories.Pets;
using CadastroVetano.Services.Owners;
using CadastroVetano.Services.Pets;
using CadastroVetano.UseCases.Owners;
using CadastroVetano.UseCases.Pets;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//Repositorios
builder.Services.AddScoped<IPetRepository, PetRepository>();
builder.Services.AddScoped<IOwnerRepository, OwnerRepository>();

//Services
builder.Services.AddScoped<IOwnerService, OwnerService>();
builder.Services.AddScoped<IPetService, PetService>();

//UseCase - Pets
builder.Services.AddScoped<CreatePetUseCase>();
builder.Services.AddScoped<UpdatePetUseCase>();
builder.Services.AddScoped<DeletePetUseCase>();

//UseCase - Owners
builder.Services.AddScoped<CreateOwnerUseCase>();
builder.Services.AddScoped<UpdateOwnerUseCase>();
builder.Services.AddScoped<DeleteOwnerUseCase>();

//Conexao com o banco
string connectionString = builder.Configuration.GetConnectionString("Database")!;
builder.Services.AddDbContext<Context>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
