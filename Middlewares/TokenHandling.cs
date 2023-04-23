using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Catalog.Middlewares;

public static class TokenHandling
{
    public static JwtBearerEvents CheckIfValid()
    {
        var token = new JwtBearerEvents()
        {
            OnAuthenticationFailed = context =>
            {
                //add other message
                const string message = "Someone is messing with the token";
                Console.WriteLine(message);
                return Task.CompletedTask;
            }
        };

        return token;
    }
}