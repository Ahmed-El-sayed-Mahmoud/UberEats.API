namespace UberEats.API.Errors
{
    public class ConflictError
    {
        public int code { get; set; } = 409;
        public object? message { get; set; }
        public ConflictError(object msg)
        {
            message = msg;
        }
    }
}
