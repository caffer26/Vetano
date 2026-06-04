namespace CadastroVetano.Appointments.DTO.Appointments
{
    public class AppointmentResponseDTO
    {
        public Guid Id { get; set; }
        public DateTime Date { get;  set; }
        public Guid PetId { get;  set; }
    }
}
