using DocumentsManager.DocumentsManager.Cqrs;
using DocumentsManager.Queries.HandlerResult;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DocumentsManager.Queries
{
    public abstract class QueryHandler<TRequest> : IRequestHandler<TRequest, IHandlerResult>
       where TRequest : IRequest<IHandlerResult>
    {
        protected virtual Task<IHandlerResult> CanHandleAsync(TRequest query, CancellationToken cancellationToken)
        {
            return Task.FromResult<IHandlerResult>(null);
        }

        public async Task<IHandlerResult> Handle(TRequest query, CancellationToken cancellationToken)
        {
            IHandlerResult canHandle = await this.CanHandleAsync(query, cancellationToken);
            if (canHandle == null)
            {
                return await this.HandleAsync(query, cancellationToken);
            }

            return canHandle;
        }

        public abstract Task<IHandlerResult> HandleAsync(TRequest request, CancellationToken cancellationToken);

        protected static IHandlerResult Data()
        {
            return new DataHandlerResult<object>();
        }

        protected static IHandlerResult Data<TResponse>(TResponse response)
        {
            return new DataHandlerResult<TResponse>(response);
        }
    }
}
