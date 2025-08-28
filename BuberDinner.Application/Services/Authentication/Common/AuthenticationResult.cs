using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.Authentication.Common;

public record AuthenticationResult
{
    public User User { get; init; } = default!;
    public string Token { get; init; } = default!;
}
