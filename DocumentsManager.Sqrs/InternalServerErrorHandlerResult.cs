namespace DocumentsManager.DocumentsManager.Cqrs
{
    /// <summary>
    /// Error result.
    /// </summary>
    /// <typeparam name="T">Requested data type.</typeparam>
    public class InternalServerErrorHandlerResult : IHandlerResult
    {
        /// <summary>
        /// Initializes instance of <see cref="InternalServerErrorHandlerResult"/> with InternalServerError error.
        /// </summary>
        public InternalServerErrorHandlerResult()
        {
        }

        /// <summary>
        /// Initializes instance of <see cref="InternalServerErrorHandlerResult"/>.
        /// </summary>
        /// <param name="error">Error to return.</param>
        public InternalServerErrorHandlerResult(string errorMessage)
        {
            this.ErrorMessage = errorMessage;
        }

        /// <summary>
        /// Error to return.
        /// </summary>
        public string ErrorMessage { get; }
    }
}
