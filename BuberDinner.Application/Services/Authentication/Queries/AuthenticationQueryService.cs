using System;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Common.Errors;
using ErrorOr;

namespace BuberDinner.Application.Services.Authentication.Queries;

public class AuthenticationQueryService : IAuthenticationQueryService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    public AuthenticationQueryService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public ErrorOr<AuthenticationResult> Login(string email, string password)
    {

        var user = _userRepository.GetUserByEmail(email);
        if (user is null) 
        {
            return Errors.Authentication.InvalidCredentials;
        }
        // Verify the password
        if (!_passwordHasher.VerifyPassword(password, user.Password))
        {
            return Errors.Authentication.InvalidCredentials;
        }
        var token = _jwtTokenGenerator.GenerateToken(user);

        // Return the JWT token
        return new AuthenticationResult
        {
            User = user,
            Token = token
        };
    }
}
