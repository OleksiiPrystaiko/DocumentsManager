namespace DocumentsManager.Queries.HandlerResult
{
    public class NotFoundHandlerResult : INotFoundHandlerResult
    {
        public NotFoundHandlerResult()
            : this(string.Empty)
        {
        }

        public NotFoundHandlerResult(string message)
        {
            this.Message = message;
        }

        public string Message { get; }
    }
}
