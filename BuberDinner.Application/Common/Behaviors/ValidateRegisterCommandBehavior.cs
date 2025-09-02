// <copyright file="ValidateRegisterCommandBehavior.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Common;

using ErrorOr;

using FluentValidation;

using MediatR;

namespace BuberDinner.Application.Common.Behaviors;

/// <summary>
/// Validate Register Command Behavior.
/// </summary>
/// <seealso cref="IPipelineBehavior{RegisterCommand, ErrorOr{AuthenticationResult}}"/>
public class ValidateRegisterCommandBehavior : IPipelineBehavior<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IValidator<RegisterCommand> _validator;

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidateRegisterCommandBehavior"/> class.
    /// </summary>
    /// <param name="validator">The validator.</param>
    public ValidateRegisterCommandBehavior(IValidator<RegisterCommand> validator)
    {
        this._validator = validator;
    }

    /// <inheritdoc/>
    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand request, RequestHandlerDelegate<ErrorOr<AuthenticationResult>> next, CancellationToken cancellationToken)
    {
        var validationResult = await this._validator.ValidateAsync(request, cancellationToken);

        if (validationResult.IsValid)
        {
            return await next();
        }

        var errors = validationResult.Errors.ConvertAll(failure => Error.Validation(failure.PropertyName, failure.ErrorMessage));
        return errors;
    }
}