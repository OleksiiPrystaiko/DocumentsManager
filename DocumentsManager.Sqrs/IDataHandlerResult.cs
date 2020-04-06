namespace DocumentsManager.DocumentsManager.Cqrs
{
    public interface IDataHandlerResult<out TResponse> : IHandlerResult
    {
        TResponse Data { get; }
    }
}
