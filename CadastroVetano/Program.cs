using CadastroVetano.Appointments.Interfaces.IRepositories;
using CadastroVetano.Appointments.Interfaces.IServices;
using CadastroVetano.Appointments.Repositories.Appointments;
using CadastroVetano.Appointments.Services.Appointments;
using CadastroVetano.Appointments.UseCases.Appointments;
using CadastroVetano.DataContext;
using CadastroVetano.Register.Interfaces.IRepositories;
using CadastroVetano.Register.Interfaces.IServices;
using CadastroVetano.Register.Repositories.Owners;
using CadastroVetano.Register.Repositories.Pets;
using CadastroVetano.Register.Services.Owners;
using CadastroVetano.Register.Services.Pets;
using CadastroVetano.Register.UseCases.Owners;
using CadastroVetano.Register.UseCases.Pets;
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
