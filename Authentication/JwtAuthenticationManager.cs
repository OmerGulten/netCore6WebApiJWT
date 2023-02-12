using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace netCore6WebApiJWT.Authentication
{
    public class JwtAuthenticationManager : IJWTAuthenticationManager
    {
        private readonly string _tokenKey;

        public JwtAuthenticationManager(string tokenKey)
        {
            _tokenKey = tokenKey;
        }

        private readonly IDictionary<string, string> _users = new Dictionary<string, string>
        {
            {"user1", "password1"},
            {"user2", "password2"}
        };

        public string Authenticate(string username, string password)
        {
            if (!_users.Any(x => x.Key == username && x.Value == password))
            {
                return null;
            }

            JwtSecurityTokenHandler tokenHandler = new();
            var tokenKey = Encoding.ASCII.GetBytes(_tokenKey);
            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
