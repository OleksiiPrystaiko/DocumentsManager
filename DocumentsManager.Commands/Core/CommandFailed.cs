using MediatR;

namespace DocumentsManager.Commands.Core
{
    public sealed class CommandFailed : INotification
    {
        public CommandFailed(string commandName, string errorMessage)
        {
            this.ErrorMessage = errorMessage;
            this.CommandName = commandName;
        }

        public string ErrorMessage { get; }

        public string CommandName { get; }
    }
}
