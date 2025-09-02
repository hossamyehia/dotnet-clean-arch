// <copyright file="DependencyInjection.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Api.Common.Errors;
using BuberDinner.Api.Common.Mapping;

using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BuberDinner.Api;

/// <summary>
/// Provides extension methods for dependency injection in the presentation layer.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Adds presentation layer services to the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The service collection to add services to.</param>
    /// <returns>The updated <see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        // it overrides the default ProblemDetailsFactory with our custom implementation
        services.AddSingleton<ProblemDetailsFactory, BuberDinnerProblemDetailsFactory>();
        services.AddControllers();
        services.AddMappings();
        return services;
    }
}