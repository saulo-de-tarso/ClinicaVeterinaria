using System.ComponentModel.DataAnnotations;

namespace ProjetoCRM.API.Dtos.Cliente
{
    public class UpdateClienteDto
    {
        //DTO para o PUT de clientes do CRM, com suas propriedades Id, nome, cpf, endereço e e-mail

        [Required(ErrorMessage = "Por favor, insira um valor para o Id")]
        public int? Id { get; set; }

        [Required(ErrorMessage = "Por favor, insira um valor para o nome")]
        public string? Nome { get; set; }
        
        [Required(ErrorMessage = "Por favor, insira um valor para o CPF")]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "O CPF deve estar no formato xxx.xxx.xxx-xx")]
        public string? Cpf { get; set; }

        [Required(ErrorMessage = "Por favor, insira um valor para o endereço")]
        public string? Endereco { get; set; }

        [Required(ErrorMessage = "Por favor, insira um valor para o e-mail")]
        [EmailAddress(ErrorMessage = "Por favor, insira um endereço de e-mail válido")]
        public string? Email { get; set; }
    }
}
