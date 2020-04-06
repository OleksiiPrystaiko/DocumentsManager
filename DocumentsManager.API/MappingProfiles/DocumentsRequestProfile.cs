using AutoMapper;
using DocumentsManager.API.Request;
using DocumentsManager.Queries.Documents;

namespace DocumentsManager.API.MappingProfiles
{
    public class DocumentsRequestProfile : Profile
    {
        public DocumentsRequestProfile()
        {
            this.CreateMap<GetDocumentsRequest, GetDocumentsParameters>();
        }
    }
}
