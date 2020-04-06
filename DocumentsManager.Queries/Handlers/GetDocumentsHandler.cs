﻿using DocumentsManager.DocumentsManager.Cqrs;
using DocumentsManager.Queries.HandlerResult;
using System.Threading;
using System.Threading.Tasks;

namespace DocumentsManager.Queries.Handlers
{
    public sealed class GetDocumentsHandler: QueryHandler<GetDocumentsQuery>
    {
        public override async Task<IHandlerResult> HandleAsync(GetDocumentsQuery request, CancellationToken cancellationToken)
        {
            return new DataHandlerResult<DownloadDocumentsResult>();
        }

        // TODO: Use service to download file to some blob storage. Also send message to save in cosmos db file name and blob file location  
        private DownloadDocumentsResult GetDocuments()
        {
            return new DownloadDocumentsResult(new[] { "1" });
        }
    }
}
