using System;
using System.Security;

namespace ProductsAPI.Authentication.Authorization;

public class ForbiddenException : SecurityException
{
    public ForbiddenException(string message) : base(message)
    {
    }

    public ForbiddenException(string message, Exception innException) : base(message, innException)
    {
    }
}