using DocumentsManager.DocumentsManager.Cqrs;
using MediatR;

namespace DocumentsManager.Queries.Handlers
{
    public class DocumentDownloadQuery : IRequest<IHandlerResult>
    {
        public DocumentDownloadQuery(string documentName)
        {
            DocumentName = documentName;
        }

        public string DocumentName { get; }
    }
}
