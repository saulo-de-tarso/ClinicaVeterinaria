using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoCRM.API.Models
{
    public class Appointment
    {
        //Appointment Entity of the clinic       
        public int Id { get; set; }
        public decimal Value { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        [ForeignKey("Pet")]
        public int PetId { get; set; }
        public Pet Pet { get; set; }

    }

    
}
