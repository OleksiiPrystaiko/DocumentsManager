namespace DocumentsManager.DocumentsManager.Cqrs
{
    /// <summary>
    /// Result that indicates that entity is created.
    /// </summary>
    /// <typeparam name="T">Type of created entity.</typeparam>
    public interface ICreatedHandlerResult<out T> : IHandlerResult
    {
        /// <summary>
        /// Created entity.
        /// </summary>
        T Data { get; }
    }
}
