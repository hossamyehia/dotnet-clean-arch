// <copyright file="RegisterCommandValidator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using FluentValidation;

namespace BuberDinner.Application.Authentication.Commands.Register;

/// <summary>
/// Validator for <see cref="RegisterCommand"/>.
/// </summary>
/// <remarks>Ensures that the registration command contains valid data.</remarks>
public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RegisterCommandValidator"/> class.
    /// </summary>
    public RegisterCommandValidator()
    {
        this.RuleFor(x => x.FirstName).NotEmpty();
        this.RuleFor(x => x.LastName).NotEmpty();
        this.RuleFor(x => x.Email).NotEmpty().EmailAddress();
        this.RuleFor(x => x.Password).NotEmpty();
    }
}