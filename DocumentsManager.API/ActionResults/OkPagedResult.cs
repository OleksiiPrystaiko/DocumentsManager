using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Globalization;
using System.Threading.Tasks;

namespace DocumentsManager.API.ActionResults
{
    [DefaultStatusCode(StatusCodes.Status200OK)]
    public sealed class OkPagedResult<TResult> : ObjectResult
    {
        private const string CountHeaderName = "Documents";
        private readonly int count;

        public OkPagedResult(TResult value, int count)
            : base(value)
        {
            this.count = count;
        }

        public override Task ExecuteResultAsync(ActionContext context)
        {
            context.HttpContext.Response.Headers[CountHeaderName] = this.count.ToString(CultureInfo.InvariantCulture);

            return base.ExecuteResultAsync(context);
        }
    }
}
