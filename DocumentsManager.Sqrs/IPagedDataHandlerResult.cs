using System.Collections.Generic;

namespace DocumentsManager.DocumentsManager.Cqrs
{
    public interface IPagedDataHandlerResult<out TResponse> : IHandlerResult
    {
        IReadOnlyCollection<TResponse> Items { get; }

        int Count { get; }
    }
}
