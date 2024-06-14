namespace ProjetoCRM.API.Models
{
    //Class to return service response
    public class ServiceResponse<T>
    {
        //Data answer
        public T? Data { get; set; }
        //Inform if the request was successful
        public bool Success { get; set; } = true;
        //Message to inform the error, if not successful
        public string Message { get; set; } = string.Empty;
    }
}
