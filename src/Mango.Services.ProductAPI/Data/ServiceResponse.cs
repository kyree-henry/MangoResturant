namespace Mango.Services.ProductAPI.Data
{
	public class ServiceResponse
	{
        public ServiceResponse()
        {
            ErrorMessages = new List<string>();
        }

        public bool IsSuccess { get; set; }
        public object? Result { get; set; }
        public string? Message { get; set; }
        public List<string> ErrorMessages { get; set; }
    }
}
