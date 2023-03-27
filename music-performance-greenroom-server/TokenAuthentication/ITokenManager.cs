using Microsoft.AspNetCore.Mvc;

namespace GreenroomServer.TokenAuthentication
{
    public interface ITokenManager
    {
        Task<ActionResult<bool>> Authenticate(string email, string password);
        Token NewToken();
        bool VerifyToken(string token);
    }
}