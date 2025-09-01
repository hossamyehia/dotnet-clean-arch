using BuberDinner.Domain.User;

namespace BuberDinner.Application.Authentication.Common;

public record AuthenticationResult
{
    public User User { get; init; } = default!;
    public string Token { get; init; } = default!;
}
