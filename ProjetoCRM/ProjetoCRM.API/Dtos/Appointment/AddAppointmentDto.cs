using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoCRM.API.Dtos.Appointment
{
    public class AddAppointmentDto
    {
        [Required(ErrorMessage = "Por favor, insira o valor da consulta")]
        public decimal Value { get; set; }
        [Required(ErrorMessage = "Por favor, insira a descrição da consulta")]
        [MaxLength(500)]
        public string Description { get; set; }
        [Required(ErrorMessage = "Por favor, insira o id do Pet")]
        public int PetId { get; set; }
    }
}
