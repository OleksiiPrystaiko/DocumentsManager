using DocumentsManager.DocumentsManager.Cqrs;
using DocumentsManager.Queries.Documents;
using MediatR;

namespace DocumentsManager.Queries.Handlers
{
    public class GetDocumentsQuery : IRequest<IHandlerResult>
    {
        public GetDocumentsQuery(GetDocumentsParameters searchParameters)
        {
            this.SearchParameters = searchParameters;
        }

        public GetDocumentsParameters SearchParameters { get; }
    }
}
