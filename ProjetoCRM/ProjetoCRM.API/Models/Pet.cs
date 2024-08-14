
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoCRM.API.Models
{
    public class Pet
    {
        //Pet Entity of the clinic       
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Specie { get; set; }
        public string Race { get; set; }
        [ForeignKey("Owner")]
        public int OwnerId { get; set; }
        public Client Owner { get; set; }
    }
}
