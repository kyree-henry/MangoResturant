namespace Mango.UI.Services
{
    public class ServiceResponse<T>
    {
        public ServiceResponse()
        {
            ErrorMessages = new List<string>();
        }

        public bool IsSuccess { get; set; }
        public T? Result { get; set; }
        public string? Message { get; set; }
        public List<string> ErrorMessages { get; set; }
    }
}
