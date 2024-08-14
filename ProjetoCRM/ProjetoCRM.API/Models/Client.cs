
using System.ComponentModel.DataAnnotations;

namespace ProjetoCRM.API.Models
{
    public class Client
    {
        //Client Entity of the clinic      
        public int Id { get; set; }
        public string Name { get; set; }
        [MaxLength(14)]
        public string Cpf { get; set; }
        [MaxLength(100)]
        public string Address { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
    }
}
