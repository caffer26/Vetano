using CadastroVetano.Appointments.Entities.Appointments;

namespace CadastroVetano.Appointments.DTO.Appointments
{
    public class CreateAppointmentDTO
    {
        public DateTime Date { get; set; }
        public Guid PetId { get; set; }
    }
}
