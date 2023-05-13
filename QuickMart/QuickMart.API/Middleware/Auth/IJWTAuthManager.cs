


using QuickMart.API.Models;

namespace WebApi.Middleware.Auth
{
    public interface IJWTAuthManager
    {
        string GenerateJWT(Customer user);
    }
}
