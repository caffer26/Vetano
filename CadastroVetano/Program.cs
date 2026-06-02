using Cadastro.Interfaces.IRepositories;
using Cadastro.Interfaces.IServices;
using CadastroVetano.DataContext;
using CadastroVetano.Interfaces.IRepositories;
using CadastroVetano.Interfaces.IServices;
using CadastroVetano.Repositories.Appointments;
using CadastroVetano.Repositories.Owners;
using CadastroVetano.Repositories.Pets;
using CadastroVetano.Services.Appointments;
using CadastroVetano.Services.Owners;
using CadastroVetano.Services.Pets;
using CadastroVetano.UseCases.Appointments;
using CadastroVetano.UseCases.Owners;
using CadastroVetano.UseCases.Pets;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Context
builder.Services.AddDbContext<Context>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    ));

//Repositorios
builder.Services.AddScoped<IPetRepository, PetRepository>();
builder.Services.AddScoped<IOwnerRepository, OwnerRepository>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();

//Services
builder.Services.AddScoped<IOwnerService, OwnerService>();
builder.Services.AddScoped<IPetService, PetService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();

//UseCase - Pets
builder.Services.AddScoped<CreatePetUseCase>();
builder.Services.AddScoped<UpdatePetUseCase>();
builder.Services.AddScoped<DeletePetUseCase>();

//UseCase - Owners
builder.Services.AddScoped<CreateOwnerUseCase>();
builder.Services.AddScoped<UpdateOwnerUseCase>();
builder.Services.AddScoped<DeleteOwnerUseCase>();

//UseCase - Appointments
builder.Services.AddScoped<CreateAppointmentUseCase>();
builder.Services.AddScoped<UpdateAppointmentUseCase>();
builder.Services.AddScoped<DeleteAppointmentUseCase>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
