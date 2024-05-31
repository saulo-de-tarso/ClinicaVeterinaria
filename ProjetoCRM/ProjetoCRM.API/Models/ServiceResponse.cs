namespace ProjetoCRM.API.Models
{
    //Classe para retornar a resposta do serviço
    public class ServiceResponse<T>
    {
        //Resposta dos dados
        public T? Data { get; set; }
        //Informar se a requisição foi feita com sucesso
        public bool Success { get; set; } = true;
        //Mensagem para informar em caso de erro
        public string Message { get; set; } = string.Empty;
    }
}
