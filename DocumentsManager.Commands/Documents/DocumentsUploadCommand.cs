using MediatR;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace DocumentsManager.Commands.Documents
{
    public class DocumentsUploadCommand : IRequest
    {
        public DocumentsUploadCommand(ICollection<IFormFile> documents) => this.Documents = documents;
        public ICollection<IFormFile> Documents { get; set; }
    }
}
