using System.Collections.Generic;
using System.Threading.Tasks;
using DocumentsManager.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DocumentsManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentsController : BaseController
    {
        private readonly IMediator mediator;

        private readonly ILogger<DocumentsController> logger;

        public DocumentsController(IMediator mediator, ILogger<DocumentsController> logger)
        {
            this.mediator = mediator;
            this.logger = logger;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadDocuments(ICollection<IFormFile> files)
        {
            // TODO: Add ommand handlers separate project
            var query = new DocumentsDownloadQuery($"{files.Count}");
            var result = await this.mediator.Send(query);

            return this.Send(result);
        }

        [HttpPost("download")]
        public async Task<IActionResult> DownloadDocuments(IFormFile file)
        {
            var query = new DocumentsDownloadQuery(file.ContentType);
            var result = await this.mediator.Send(query);

            return this.Send(result);
        }
    }
}
