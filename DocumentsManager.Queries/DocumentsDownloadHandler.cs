using DocumentsManager.DocumentsManager.Cqrs;
using DocumentsManager.Queries.HandlerResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DocumentsManager.Queries
{
    public sealed class DocumentsDownloadHandler: QueryHandler<DocumentsDownloadQuery>
    {
        public override async Task<IHandlerResult> HandleAsync(DocumentsDownloadQuery request, CancellationToken cancellationToken)
        {
            return new DataHandlerResult<DownloadDocumentsResult>();
        }

        // TODO: Use service to вщцтдщфв file and  
        private DownloadDocumentsResult GetDocuments()
        {
            return new DownloadDocumentsResult(new[] { "1" });
        }
    }
}
