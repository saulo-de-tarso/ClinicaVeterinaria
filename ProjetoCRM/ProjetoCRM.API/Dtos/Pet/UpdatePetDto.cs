﻿using System.ComponentModel.DataAnnotations;

namespace ProjetoCRM.API.Dtos.Pet
{
    public class UpdatePetDto
    {
        //DTO to POST pet to the clinic. Id not necessary, it will be generated by SQL Server.

        [MaxLength(100, ErrorMessage = "O nome pode ter no máximo 100 caracteres")]
        [Required(ErrorMessage = "Por favor, insira um valor para o nome")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Por favor, insira um valor para o CPF")]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "O CPF deve estar no formato xxx.xxx.xxx-xx")]
        public DateTime BirthDate { get; set; }

        [MaxLength(100, ErrorMessage = "A espécie pode ter no máximo 100 caracteres")]
        [Required(ErrorMessage = "Por favor, insira um valor para a espécie")]
        public string? Specie { get; set; }

        [MaxLength(100, ErrorMessage = "A raça pode ter no máximo 100 caracteres")]
        [Required(ErrorMessage = "Por favor, insira um valor para a raça")]
        public string? Race { get; set; }

        [Required(ErrorMessage = "Por favor, insira o id do dono.")]
        public int OwnerId { get; set; }
    }
}
