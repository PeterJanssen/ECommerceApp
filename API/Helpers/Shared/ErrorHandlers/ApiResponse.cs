namespace API.Helpers.Shared.ErrorHandlers
{
    public class ApiResponse
    {
        public ApiResponse(int status, string message = null)
        {
            Status = status;
            Message = message ?? GetDefaultMessageForStatusCode(status);
        }
        public int Status { get; set; }
        public string Message { get; set; }
        private string GetDefaultMessageForStatusCode(int status)
        {
            return status switch
            {
                400 => "Bad Request",
                401 => "Not Authorized for this action",
                403 => "Forbidden Request",
                404 => "Resource not found",
                500 => "Server Error",
                _ => null
            };
        }
    }
}