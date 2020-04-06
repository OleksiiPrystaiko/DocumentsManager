using DocumentsManager.DocumentsManager.Cqrs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentsManager.Queries.HandlerResult
{
    public class DownloadDocumentsResult
    {
        // TODO: Return more complicated object. Create document model which might contains fileIdentifier, Blob storage path...
        public DownloadDocumentsResult(IList<string> documents)
        {
            Documents = documents;
        }

        public IList<string> Documents { get; }
    }
}
