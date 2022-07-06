using System;
using ProductsAPI.Enums;

namespace ProductsAPI.Authentication.Authorization;

public class UserContext : IUserContext
{
    public Guid UserId { get; set; }

    public Role Role { get; set; }

    public bool IsAuthorized { get; set; }

    public ClaimSet? ClaimSet { get; set; }

    public Language Language { get; set; }
}