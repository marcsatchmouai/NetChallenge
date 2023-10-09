using NetChallenge.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NetChallenge.Exceptions
{
    public static class ValidationExtensions

    {
        public static void ValidateNotNullOrEmpty(this string argument, string argumentName)
        {
            if (string.IsNullOrEmpty(argument))
            {
                ExceptionHandler.HandleException(new ArgumentException($"{argumentName} no puede ser nulo ni estar vacío.", argumentName));
            }
        }
        public static void ValidateNotLessThanOrEqualZero<T>(this T value, string errorMessage) where T : IComparable<T>
        {
            if (Comparer<T>.Default.Compare(value, default) <= 0)
            {
                ExceptionHandler.HandleException(new ArgumentException(errorMessage));
            }
        }
        public static void ValidateIsNullOrWhiteSpace<T>(this T value, string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(value?.ToString()))
            {
                ExceptionHandler.HandleException(new ArgumentException(errorMessage));
            }
        }

        public static void ValidateNotEqual<T>(this T value, T otherValue, string errorMessage)
        {
            if (!EqualityComparer<T>.Default.Equals(value, default) &&
                !string.IsNullOrEmpty(value?.ToString()) &&
                value.ToString().Trim() == otherValue?.ToString().Trim())
            {
                ExceptionHandler.HandleException(new ArgumentException(errorMessage));
            }
        }
        public static void ValidateIsInHours(this TimeSpan value, string errorMessage)
        {
            if (!(value.TotalMinutes % 60 == 0 && value.Seconds == 0 && value.Milliseconds == 0))
            {
                ExceptionHandler.HandleException(new ArgumentException(errorMessage));
            }
        }
        public static void ValidateNotInPast(this DateTime value, string errorMessage)
        {
            if (value < DateTime.Now)
            {
                ExceptionHandler.HandleException(new ArgumentException(errorMessage));
            }
        }
    }
}
