using System;
using ProductsAPI.Enums;

namespace ProductsAPI.Authentication.Authorization;

public interface IUserContext
{
    Guid UserId { get; }
    Role Role { get; }
    bool IsAuthorized { get; }
    ClaimSet? ClaimSet { get; }
    Language Language { get; }
}