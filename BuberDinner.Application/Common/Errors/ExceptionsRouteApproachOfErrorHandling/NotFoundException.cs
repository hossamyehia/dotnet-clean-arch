using System.Net;

namespace BuberDinner.Application.Common.Errors;

public class NotFoundException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.NotFound;

    public string ErrorMessage => "The specified resource was not found.";
}
