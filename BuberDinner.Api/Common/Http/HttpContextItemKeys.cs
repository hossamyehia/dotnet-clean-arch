// <copyright file="HttpContextItemKeys.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BuberDinner.Api.Common.Http;

/// <summary>
/// Keys for items stored in <see cref="HttpContext.Items"/>.
/// </summary>
public static class HttpContextItemKeys
{
    /// <summary>
    /// Key for storing errors in <see cref="HttpContext.Items"/>.
    /// </summary>
    public const string Errors = "Errors";
}