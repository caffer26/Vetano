using Cadastro.Interfaces.IRepositories;
using CadastroVetano.Entities.Appointments;
using CadastroVetano.Entities.Owners;
using CadastroVetano.Interfaces.IRepositories;

namespace CadastroVetano.UseCases.Pets
{
    public class DeletePetUseCase
    {
        private readonly IPetRepository _petRepository;
        private readonly IAppointmentRepository _appointmentRepository;

        public DeletePetUseCase(IPetRepository petRepository, IAppointmentRepository appointmentRepository)
        {
            _petRepository = petRepository;
            _appointmentRepository = appointmentRepository;
        }
        public void Run(Guid petId)
        {
            Pet pet = _petRepository.FindById(petId);

            var appointment = _appointmentRepository.FindPetById(petId);

            if (appointment != null && appointment.Date > DateTime.Now) 
            {
                throw new Exception("Nao e possivel deletar um pet com consulta marcada.");
            }

            _petRepository.Delete(pet);
        }
    }
}
