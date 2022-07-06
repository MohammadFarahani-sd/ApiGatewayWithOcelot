using System;
using ProductsAPI.Enums;

namespace ProductsAPI.Authentication.Authorization;

public class UserContextPopulator : IUserContextPopulator
{
    private readonly IUserContext context;

    public UserContextPopulator(IUserContext userContext)
    {
        context = userContext;
    }

    public void Populate(ClaimSet claimSet, string? language)
    {
        if (context is UserContext userContext)
        {
            userContext.UserId = Guid.NewGuid();

                //var role = claimSet[ClaimType.Role];
            userContext.Role = Role.Admin;

            userContext.IsAuthorized = true;

            userContext.ClaimSet = claimSet;

            userContext.Language =  Language.English;
        }
    }
}