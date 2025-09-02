// <copyright file="LoginQuery.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Authentication.Queries.Login;

/// <summary>
/// Query for logging in a user.
/// </summary>
/// <param name="Email">The email of the user.</param>
/// <param name="Password">The password of the user.</param>
/// <returns>The authentication result.</returns>
public record LoginQuery(string Email, string Password) : IRequest<ErrorOr<AuthenticationResult>>;