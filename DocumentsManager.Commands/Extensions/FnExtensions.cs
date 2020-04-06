using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentsManager.Commands.Extensions
{
    using static Result;

    public static class FnExtensions
    {
        private static readonly Func<Exception, string> DefaultTryErrorHandler = exc => exc.Message;

        public static Result OnFailure(this Result result, Action<string> action)
        {
            if (result.IsFailure)
            {
                action(result.Error);
            }

            return result;
        }

        public static async Task<Result> OnFailureAsync(this Task<Result> resultTask, Func<string, Task> func)
        {
            Result result = await resultTask.ConfigureAwait(DefaultConfigureAwait);

            if (result.IsFailure)
            {
                await func(result.Error).ConfigureAwait(DefaultConfigureAwait);
            }

            return result;
        }

        public static async Task<Result> OnSuccessTryAsync(this Result result, Func<Task> func)
        {
            return result.IsFailure ? Failure(result.Error) : await TryAsync(func);
        }

        public static async Task<Result> OnSuccessTryAsync(
            this Result result,
            Func<Task> func,
            Func<Exception, string> errorHandler)
        {
            return result.IsFailure ? Failure(result.Error) : await TryAsync(func, errorHandler);
        }

        public static async Task<Result> OnSuccessTryAsync<T>(this Result<T> result, Func<T, Task> func)
        {
            return result.IsFailure ? Failure(result.Error) : await TryAsync(() => func(result.Value));
        }

        public static async Task<Result> OnSuccessTryAsync<T>(
            this Result<T> result,
            Func<T, Task> func,
            Func<Exception, string> errorHandler)
        {
            return result.IsFailure ? Failure(result.Error) : await TryAsync(() => func(result.Value), errorHandler);
        }

        public static Task<Result> TryAsync(Func<Task> func)
        {
            return TryAsync(func, DefaultTryErrorHandler);
        }

        public static async Task<Result> TryAsync(Func<Task> func, Func<Exception, string> errorHandler)
        {
            try
            {
                await func().ConfigureAwait(DefaultConfigureAwait);
                return Ok();
            }
            catch (Exception e)
            {
                string message = errorHandler(e);
                return Failure(message);
            }
        }

        public static Result<T> Chain<T>(params Result<T>[] results)
        {
            List<Result<T>> failedResults = results.Where(x => x.IsFailure).ToList();

            if (failedResults.Count == 0)
            {
                T value = results.First().Value;
                if (!results.All(res => ReferenceEquals(res.Value, value)))
                {
                    throw new InvalidOperationException("Cannot complete chain operation as operation results has different objects attached.");
                }

                return Ok(value);
            }

            string errorMessage = string.Join(ErrorMessagesSeparator, failedResults.Select(x => x.Error).ToArray());
            return Failure<T>(errorMessage);
        }

        public static Result<T> EnsureAndChain<T>(this Result<T> ensureResult, params Func<T, Result<T>>[] funcs)
        {
            if (ensureResult.IsFailure)
            {
                return ensureResult;
            }

            foreach (Func<T, Result<T>> func in funcs)
            {
                var result = func(ensureResult.Value);
                if (result.IsFailure)
                {
                    return Failure<T>(result.Error);
                }
            }

            return Ok(ensureResult.Value);
        }
    }
}
