﻿using System.Collections.ObjectModel;

namespace IdentityMicroService.Constants;

public static class AuthorizationConfigs
{
    public enum Roles
    {
        Administrator,
        Moderator,
        User
    }

    const string Administrator = "Administrator";
    public const string Moderator = "Moderator";
    const string User = "User";

    public static readonly IReadOnlyDictionary<Roles, string> roleDict = new Dictionary<Roles, string>()
    {
        [Roles.Administrator] = Administrator,
        [Roles.Moderator] = Moderator,
        [Roles.User] = User,
    };  
}
