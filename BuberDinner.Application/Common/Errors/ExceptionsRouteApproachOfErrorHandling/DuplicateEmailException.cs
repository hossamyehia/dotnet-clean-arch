using System.Net;

namespace BuberDinner.Application.Common.Errors;

public class DuplicateEmailException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;

    public string ErrorMessage => "If you already have an account, you can reset your password.";
}
