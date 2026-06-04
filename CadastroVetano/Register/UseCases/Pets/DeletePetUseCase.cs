using CadastroVetano.Appointments.Interfaces.IRepositories;
using CadastroVetano.Appointments.Entities.Appointments;
using CadastroVetano.Register.Entities.Owners;
using CadastroVetano.Register.Interfaces.IRepositories;

namespace CadastroVetano.Register.UseCases.Pets
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

            if (pet == null)
            {
                throw new Exception("Pet não encontrado.");
            }

            var appointment = _appointmentRepository.FindPetById(petId);

            if (appointment != null && appointment.Date > DateTime.Now) 
            {
                throw new Exception("Nao e possivel deletar um pet com consulta marcada.");
            }

            _petRepository.Delete(pet);
        }
    }
}
