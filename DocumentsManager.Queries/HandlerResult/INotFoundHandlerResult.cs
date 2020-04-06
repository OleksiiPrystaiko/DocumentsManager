using DocumentsManager.DocumentsManager.Cqrs;

namespace DocumentsManager.Queries.HandlerResult
{
    public interface INotFoundHandlerResult : IHandlerResult
    {
        string Message { get; }
    }
}
