using System.Collections.Generic;

namespace DocumentsManager.Queries.Documents
{
    public class GetDocumentsResult
    {
        public GetDocumentsResult(long? count, IList<Document> list)
        {
            Count = count;
            Results = list;
        }

        public long? Count { get; }

        public IList<Document> Results { get; }
    }
}
