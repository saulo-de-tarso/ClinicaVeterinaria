namespace ProjetoCRM.API.Dtos.Client
{
    public class GetClientDto
    {
        //DTO to GET clinic client
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Cpf { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
    }
}
