using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Entities;
using ErrorOr;
// using OneOf;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService: IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;
    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    {

        if (_userRepository.GetUserByEmail(email) is not null)
        {
            // Exception approach
            // throw new Exception("User with given email already exists");

            // OneOf approach
            // return new DuplicateEmailError();

            // FluentResult approach
            // return Result.Fail<AuthenticationResult>(new DuplicateEmailError());

            // Custom Exception approach
            // throw new DuplicateEmailException();

            return Errors.User.DuplicateEmail;
        }

        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password // In a real application, ensure to hash the password
        };
        _userRepository.AddUser(user);

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult
        {
            User = user,
            Token = token
        };
    }

    public ErrorOr<AuthenticationResult> Login(string email, string password)
    {
        var user = _userRepository.GetUserByEmail(email);
        if (user is null || user.Password != password) // In a real application, verify the password hash
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
