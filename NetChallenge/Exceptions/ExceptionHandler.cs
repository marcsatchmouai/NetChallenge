using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetChallenge.Exceptions
{
    public static class ExceptionHandler
    {
        public static void HandleException(Exception ex, string customMessage = "")
        {
            if (ex is ArgumentException argumentException)
            {
                HandleArgumentException(argumentException, customMessage);
            }
            else if (ex is InvalidOperationException invalidOperationException)
            {
                HandleInvalidOperationException(invalidOperationException, customMessage);
            }
            else
            {
                HandleException(ex);
            }
        }
        private static void HandleArgumentException(ArgumentException argumentException, string customMessage)
        {
            LogError(argumentException);
            throw new ArgumentException(customMessage);
        }
        private static void HandleInvalidOperationException(InvalidOperationException invalidOperationException, string customMessage)
        {
            LogError(invalidOperationException);
            throw new InvalidOperationException(customMessage);
        }
        private static void HandleException(Exception ex)
        {
            LogError(ex);
            throw new Exception($"Exception: {ex}, {ex.Message}");
        }

        public static IEnumerable<TDto> HandleExceptionAndReturnEmpty<TDto>(Exception ex, string errorMessage)
        {
            HandleException(ex, errorMessage);
            return Enumerable.Empty<TDto>();
        }
        private static void LogError(Exception ex)
        {
            // TODO implementar una libreria de loggin
            Console.WriteLine($"Error: Exception: {ex.Message}\nStackTrace: {ex.StackTrace}");
        }
    }
}
