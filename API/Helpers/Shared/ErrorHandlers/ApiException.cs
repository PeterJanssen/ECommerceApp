namespace API.Helpers.Shared.ErrorHandlers
{
    public class ApiException : ApiResponse
    {
        public ApiException(int status, string message = null, string details = null) : base(status, message)
        {
            Details = details;
        }

        public string Details { get; set; }
    }
}