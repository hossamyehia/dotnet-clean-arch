// <copyright file="AuthenticationMappingConfig.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Api.Authentication;
using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Authentication.Queries.Login;
using Mapster;

namespace BuberDinner.Api.Common.Mapping;

/// <summary>
/// Mapping configuration for authentication-related types.
/// </summary>
/// <remarks>
/// This class implements the <see cref="IRegister"/> interface to define the mapping configuration for authentication-related types.
/// </remarks>
public class AuthenticationMappingConfig : IRegister
{
    /// <inheritdoc/>
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest, src => src.User);

        config.NewConfig<RegisterRequest, RegisterCommand>();
        config.NewConfig<LoginRequest, LoginQuery>();
    }
}