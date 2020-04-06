using System;
using System.Collections.Generic;
using CSharpFunctionalExtensions;
using DocumentsManager.API.ActionResults;
using DocumentsManager.DocumentsManager.Cqrs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocumentsManager.API.Controllers
{
    /// <summary>
    /// Base controller that contains code common for all the services controllers.
    /// </summary>
    [ApiController]
    public class BaseController : ControllerBase
    {
        /// <summary>
        /// Converts <see cref="IHandlerResult"/> to <see cref="IActionResult"/>.
        /// </summary>
        /// <param name="result">Service response.</param>
        /// <returns>Returns data wrapped into <see cref="IActionResult"/>.</returns>
        protected IActionResult Send(IHandlerResult result)
        {
            return this.Remap(result);
        }

        /// <summary>
        /// Converts <see cref="IHandlerResult"/> to <see cref="IActionResult"/>.
        /// </summary>
        /// <param name="result">Service response.</param>
        /// <returns>Returns data wrapped into <see cref="IActionResult"/>.</returns>
        protected IActionResult Send(Result<IHandlerResult> result)
        {
            return result.IsFailure
                ? this.StatusCode(StatusCodes.Status500InternalServerError, result.Error)
                : this.Send(result.Value);
        }

        private IActionResult Remap(IHandlerResult result)
        {
            switch (result)
            {
                case IDataHandlerResult<object> dhr:
                    return this.Ok(dhr.Data);
                case IDataHandlerResult<int> dhr:
                    return this.Ok(dhr.Data);
                case IDataHandlerResult<bool> dhr:
                    return this.Ok(dhr.Data);
                case IPagedDataHandlerResult<object> pdhr:
                    return new OkPagedResult<IReadOnlyCollection<object>>(pdhr.Items, pdhr.Count);
                case ICreatedHandlerResult<int> chr:
                    return this.StatusCode(StatusCodes.Status201Created, chr.Data);
                case ICreatedHandlerResult<object> chr:
                    return this.StatusCode(StatusCodes.Status201Created, chr.Data);
                case InternalServerErrorHandlerResult isehr:
                    return ErrorResult(isehr.ErrorMessage, () => this.StatusCode(500), sr => this.StatusCode(412, sr));
                default:
                    throw new KeyNotFoundException($"Unknown handler result '{result.GetType()}' encountered.");
            }
        }

        private static IActionResult ErrorResult(
            string error,
            Func<StatusCodeResult> statusCodeResult,
            Func<string, ObjectResult> objectResult)
        {
            return error == null ? (ActionResult)statusCodeResult() : objectResult(error);
        }
    }
}