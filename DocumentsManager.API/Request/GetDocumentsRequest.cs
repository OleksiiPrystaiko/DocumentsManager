using System.Collections.Generic;

namespace DocumentsManager.API.Request
{
    public class GetDocumentsRequest
    {
        public IList<string> OrderBy { get; set; }

        public int? Skip { get; set; }

        public int? Top { get; set; }
    }
}
