namespace BuberDinner.Api.Authentication;

public record AuthenticationResponse
{
    public Guid Id;
    public string FirstName { get; init; } = default!;
    public string LastName { get; init; } = default!;
    public string Email { get; init; } = default!;
    public string Token { get; init; } = default!;
}
