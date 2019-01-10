using System;

namespace Core.Exceptions
{
    public class CoreException : Exception
    {
        private const string DefaultErrorCode = "APP-ERROR-000";

        private string _message;
        public override string Message => _message ?? (_message = ConvertToSentence(GetType().Name, ErrorCode));

        private string _errorCode;

        /// <summary>
        /// Error code helps distringuishing same types of errors in different context.
        /// </summary>
        public string ErrorCode => _errorCode ?? (_errorCode = DefaultErrorCode);

        public CoreException(string message = null, string errorCode = null)
        {
            _message = message;
            _errorCode = errorCode;
        }

        //TODO: convert class name to sentence
        static string ConvertToSentence(string message, string errorCode)
        {
            return errorCode + ": " + message;
        }

    }
}