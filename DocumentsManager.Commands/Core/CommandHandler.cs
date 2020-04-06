using MediatR;
using CSharpFunctionalExtensions;
using System.Threading;
using System.Threading.Tasks;
using DocumentsManager.Commands.Extensions;

namespace DocumentsManager.Commands.Core
{
    public abstract class CommandHandler<TCommand> : CommandHandlerBase<TCommand>, IRequestHandler<TCommand>
        where TCommand : IRequest
    {
        protected CommandHandler(IMediator mediator)
            : base(mediator)
        {
        }

        public async Task<Unit> Handle(TCommand command, CancellationToken cancellationToken)
        {
            Result canHandle = await this.CanHandleAsync(command, cancellationToken);

            await canHandle
                  .OnSuccessTryAsync(() => this.HandleAsync(command, cancellationToken))
                  .OnFailureAsync(message => this.Notify(message, cancellationToken));

            return Unit.Value;
        }

        protected virtual Task<Result> CanHandleAsync(TCommand command, CancellationToken cancellationToken)
        {
            Result ok = Result.Ok();
            return Task.FromResult(ok);
        }

        protected abstract Task HandleAsync(TCommand command, CancellationToken cancellationToken);
    }
}
