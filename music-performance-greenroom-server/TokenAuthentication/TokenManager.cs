using Microsoft.AspNetCore.Mvc;
using music_performance_greenroom_server.Controllers;
using music_performance_greenroom_server.Models;
using NuGet.Common;

namespace GreenroomServer.TokenAuthentication
{
    public class TokenManager : ITokenManager
    {
        private readonly GreenroomDbContext _context;
        private List<Token> _tokens;
        public async Task<ActionResult<bool>> Authenticate(string email, string password)
        {
            if (!string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(password))
            {
                var userController = new UsersController(_context);
                var user = await userController.GetUserByEmail(email);


                if (user.Value != null && user.Value.Password == password)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }

        public Token NewToken()
        {
            var token = new Token
            {
                Value = Guid.NewGuid().ToString(),
                ExpirationDate = DateTime.UtcNow.AddHours(1)
            };

            _tokens.Add(token);
            return token;
        }

        public bool VerifyToken(string token)
        {
            if (_tokens.Any(t => t.Value == token && t.ExpirationDate > DateTime.UtcNow)) 
            {
                return true;
            }

            return false;
        }
    }
}
