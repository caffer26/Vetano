using CadastroVetano.Entities.Appointments;

namespace CadastroVetano.DTO.Appointments
{
    public class CreateAppointmentDTO
    {
        public DateTime Date { get; set; }
        public PetAppointment PetId { get; set; }
    }
}
