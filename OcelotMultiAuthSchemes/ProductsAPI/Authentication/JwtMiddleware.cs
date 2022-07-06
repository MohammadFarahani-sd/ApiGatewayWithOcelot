using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProductsAPI.Authentication.Authorization;
using ProductsAPI.Authentication.Constants;

namespace ProductsAPI.Authentication;

public class JwtMiddleware
{
    private readonly IConfiguration _configuration;
    private readonly RequestDelegate _next;

    public JwtMiddleware(RequestDelegate next, IConfiguration configuration)
    {
        _next = next;
        _configuration = configuration;
    }

    public async Task Invoke(HttpContext context, IUserContextPopulator userContextPopulator)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        var language = context.Request.Headers["Accept-language"].FirstOrDefault();

        if (token != null)
        {
            AttachUserToContext(userContextPopulator, token, language);
        }
        
            await _next(context);
       
    }

    private void AttachUserToContext(IUserContextPopulator userContextPopulator, string token, string language)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("my_products_api_secret");
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            }, out var validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;

            var claimSet = GetClaimSet(jwtToken.Claims);
            userContextPopulator.Populate(claimSet, language);
        }
        catch (Exception ex)
        {
        }
    }

    private static ClaimSet GetClaimSet(IEnumerable<Claim> claims)
    {
        var claimSet = new ClaimSet();
        foreach (var claim in claims)
        {
            claimSet.Add(claim.Type, claim.Value);
        }

        return claimSet;
    }
}