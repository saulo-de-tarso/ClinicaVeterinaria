namespace ProjetoCRM.API.Dtos.Cliente
{
    public class GetClienteDto
    {
        //DTO para o GET de clientes do CRM, com suas propriedades Id, nome, cpf, endereço e e-mail
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
        public string? Endereco { get; set; }
        public string? Email { get; set; }
    }
}
