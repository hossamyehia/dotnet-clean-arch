// <copyright file="LoginQueryValidator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using FluentValidation;

namespace BuberDinner.Application.Authentication.Queries.Login;

/// <summary>
/// Validator for <see cref="LoginQuery"/>.
/// </summary>
public class LoginQueryValidator : AbstractValidator<LoginQuery>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LoginQueryValidator"/> class.
    /// </summary>
    public LoginQueryValidator()
    {
        this.RuleFor(x => x.Email).NotEmpty().EmailAddress();
        this.RuleFor(x => x.Password).NotEmpty();
    }
}