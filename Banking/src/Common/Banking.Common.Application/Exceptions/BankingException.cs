using Banking.Common.Domain;

namespace Banking.Common.Application.Exceptions;
public sealed class BankingException : Exception
{
    public BankingException(string requestName, Error? error = default, Exception? innerException = default)
        : base("Application Exception", innerException)
    {
        RequestName = requestName;
        Error = error;
    }
    public string RequestName { get; }
    public Error? Error { get; }
}
