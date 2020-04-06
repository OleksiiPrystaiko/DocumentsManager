using DocumentsManager.DocumentsManager.Cqrs;
using MediatR;

namespace DocumentsManager.Queries
{
    public class DocumentsDownloadQuery : IRequest<IHandlerResult>
    {

        public DocumentsDownloadQuery(string documentType)
        {
            DocumentType = documentType;
        }

        public string DocumentType { get; }
    }
}
