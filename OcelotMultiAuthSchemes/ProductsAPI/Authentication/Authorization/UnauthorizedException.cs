using System;
using System.Security;

namespace ProductsAPI.Authentication.Authorization;

public class UnauthorizedException : SecurityException
{
    public UnauthorizedException(string message) : base(message)
    {
    }

    public UnauthorizedException(string message, Exception innException) : base(message, innException)
    {
    }
}