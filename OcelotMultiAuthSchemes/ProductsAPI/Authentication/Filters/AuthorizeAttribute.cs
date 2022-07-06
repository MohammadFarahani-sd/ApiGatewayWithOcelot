using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Filters;
using ProductsAPI.Authentication.Authorization;

namespace ProductsAPI.Authentication.Filters;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    private readonly Role[] _allowedRoles;
    private readonly IUserContext _userContext;

    public AuthorizeAttribute(IUserContext userContext, params Role[] allowedRoles)
    {
        _userContext = userContext;
        _allowedRoles = allowedRoles;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        if (_userContext == null)
        {
            throw new UnauthorizedException("Unauthorized");
        }

        if (_allowedRoles.Any() && !_allowedRoles.Contains(_userContext.Role))
        {
            throw new ForbiddenException("Forbidden");
        }
    }
}