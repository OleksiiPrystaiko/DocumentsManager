using DocumentsManager.Commands.Core;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DocumentsManager.Commands.Documents
{
    public class DocumentsUploadCommandHandler : CommandHandler<DocumentsUploadCommand>
    {
        // TODO: Add blob client to the current project communication folder. Initialize
        // private readonly IBlobClient searchClient;

        public DocumentsUploadCommandHandler(IMediator mediator)
            : base(mediator)
        {
        }

        protected override async Task HandleAsync(DocumentsUploadCommand command, CancellationToken cancellationToken)
        {
            // TODO: Use Blob client to upload documents
        }
    }
}
