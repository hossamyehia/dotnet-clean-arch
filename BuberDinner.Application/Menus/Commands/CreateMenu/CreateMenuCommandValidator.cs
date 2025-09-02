// <copyright file="CreateMenuCommandValidator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using FluentValidation;

namespace BuberDinner.Application.Menus.Commands.CreateMenu;

/// <summary>
/// Validator for CreateMenuCommand.
/// </summary>
public class CreateMenuCommandValidator : AbstractValidator<CreateMenuCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CreateMenuCommandValidator"/> class.
    /// </summary>
    public CreateMenuCommandValidator()
    {
        this.RuleFor(m => m.Name).NotEmpty();
        this.RuleFor(m => m.Description).NotEmpty();
        this.RuleFor(m => m.HostId).NotEmpty().Custom((id, context) => Guid.TryParse(id, out _));
    }
}