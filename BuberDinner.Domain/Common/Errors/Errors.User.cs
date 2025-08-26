using System;
using ErrorOr;

namespace BuberDinner.Domain.Common.Errors;

public static partial class Errors
{
    public static class User
    {
        public static Error DuplicateEmail => Error.Conflict(code: "User.DuplicateEmail", description: "If you already have an account, you can reset your password.");
    }
}
