using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoCRM.API.Dtos.Appointment
{
    public class GetAppointmentDto
    {
        //Appointment Entity of the clinic  
        public int Id { get; set; }
        public decimal Value { get; set; }
        public string Description { get; set; }
        [ForeignKey("Pet")]
        public int PetId { get; set; }
    }
}
