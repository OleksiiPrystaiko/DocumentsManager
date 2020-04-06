using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DocumentsManager.Commands.Core
{
    public class CommandHandlerBase<TCommand>
    {
        protected CommandHandlerBase(IMediator mediator)
        {
            this.Mediator = mediator;
        }

        protected IMediator Mediator { get; }

        protected virtual async Task Notify(string errorMessage, CancellationToken cancellationToken)
        {
            var commandFailed = new CommandFailed(typeof(TCommand).Name, errorMessage);
            await this.Mediator.Publish(commandFailed, cancellationToken);
        }
    }
}
