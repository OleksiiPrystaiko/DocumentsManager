using System.Collections.Generic;

namespace DocumentsManager.Queries.Documents
{
    public class GetDocumentsParameters
    {
        public IList<string> OrderBy { get; set; }

        public int? Skip { get; set; }

        public int? Top { get; set; }
    }
}
