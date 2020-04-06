using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using DocumentsManager.API.Request;
using DocumentsManager.Commands.Documents;
using DocumentsManager.DocumentsManager.Cqrs;
using DocumentsManager.Queries.Documents;
using DocumentsManager.Queries.HandlerResult;
using DocumentsManager.Queries.Handlers;
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

        private readonly IMapper mapper;

        private readonly ILogger<DocumentsController> logger;

        public DocumentsController(IMediator mediator, IMapper mapper, ILogger<DocumentsController> logger)
        {
            this.mediator = mediator;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadDocuments(ICollection<IFormFile> files)
        {
            // TODO: Add ommand handlers separate project
            var uploadCommand = new DocumentsUploadCommand(files);
            await this.mediator.Send(uploadCommand);

            return this.Ok();
        }

        [HttpGet("{documentName}")]
        public async Task<IActionResult> DownloadDocument(string fileName)
        {
            var query = new DocumentDownloadQuery(fileName);
            var result = await this.mediator.Send(query);

            return this.Send(result);
        }

        [HttpPost("getAll")]
        [ProducesResponseType(typeof(DataHandlerResult<GetDocumentsResult>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(NotFoundHandlerResult), (int)HttpStatusCode.NotFound)]
        public Task<IHandlerResult> GetDocuments([FromBody]GetDocumentsRequest request)
        {
            GetDocumentsQuery query = new GetDocumentsQuery(this.mapper.Map<GetDocumentsParameters>(request));
            return this.mediator.Send(query);
        }
    }
}
