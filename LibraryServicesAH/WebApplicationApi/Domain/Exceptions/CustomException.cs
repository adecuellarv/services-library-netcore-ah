namespace WebApplicationApi.Domain.Exceptions
{
    public class CustomException : Exception
    {
        public int ErrorCode { get; }

        public CustomException(int errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }

        public CustomException(int errorCode, string message, Exception innerException)
            : base(message, innerException)
        {
            ErrorCode = errorCode;
        }
    }
}
