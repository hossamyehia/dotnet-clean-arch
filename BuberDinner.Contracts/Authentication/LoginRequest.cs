using System;

namespace BuberDinner.Api.Authentication;

public record LoginRequest
{
    public string Email { get; init; } = default!;
    public string Password { get; init; } = default!;
}
