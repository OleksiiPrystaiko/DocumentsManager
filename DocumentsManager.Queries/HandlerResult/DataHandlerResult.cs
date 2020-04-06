using DocumentsManager.DocumentsManager.Cqrs;

namespace DocumentsManager.Queries.HandlerResult
{
    public class DataHandlerResult<TResponse> : IDataHandlerResult<TResponse>
    {
        public DataHandlerResult()
        {
        }

        public DataHandlerResult(TResponse data)
        {
            this.Data = data;
        }

        public TResponse Data { get; }
    }
}
