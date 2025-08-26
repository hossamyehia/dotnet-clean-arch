namespace BuberDinner.Application.Common.Errors;

public record struct DuplicateEmailError_OneOf() : IError_OneOf
{
    public readonly System.Net.HttpStatusCode StatusCode => System.Net.HttpStatusCode.Conflict;
    public readonly string ErrorMessage => "Email already exists";
}
