using System;
using System.Net;

namespace BuberDinner.Application.Common.Errors;

public interface IError_OneOf
{
    public HttpStatusCode StatusCode { get; }
    public string ErrorMessage { get; }
}
