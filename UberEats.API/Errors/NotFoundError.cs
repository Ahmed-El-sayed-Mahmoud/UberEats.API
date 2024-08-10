namespace UberEats.API.Errors
{
    public class NotFoundError
    {
        public int code { get; set; } = 404;
        public object? message { get; set; }
        public NotFoundError(object msg)
        {
            message = msg;
        }
    }
}
