namespace TestJobSRMD.Exceptions
{
    public class ServerException : Exception
    {
        public int Code { get; set; }

        public ServerException() : base("")
        {
            Code = 400;
        }

        public ServerException(string message, int code) : base(message)
        {
            Code = code;
        }
    }
}
