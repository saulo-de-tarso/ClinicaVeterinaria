using System.ComponentModel.DataAnnotations;

namespace ProjetoCRM.API.Dtos.Appointment
{
    public class UpdateAppointmentDto
    {
        [Required(ErrorMessage = "Por favor, insira um valor para o Id")]
        public int? Id { get; set; }
        [Required(ErrorMessage = "Por favor, insira o valor da consulta")]
        public decimal Value { get; set; }
        [Required(ErrorMessage = "Por favor, insira a descrição da consulta")]
        [MaxLength(500)]
        public string Description { get; set; }
        [Required(ErrorMessage = "Por favor, insira o id do Pet")]
        public int PetId { get; set; }
    }
}
