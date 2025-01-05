using AppAngular.Server.Servicio;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AppAngular.Server.ServicioImp
{
    public class ServicioGenerarTokenImp : IServicioGenerarToken
    {
        private readonly IConfiguration _config;

        public ServicioGenerarTokenImp(IConfiguration configuration)
        {
            _config = configuration; 
        }

        //Creación de token
        public string GenerateJwtToken(string username)
        {
            var jwtSettings = _config.GetSection("JwtSettings");
            var secretKey = jwtSettings.GetValue<string>("SecretKey");
            var issuer = jwtSettings.GetValue<string>("Issuer");
            var audience = jwtSettings.GetValue<string>("Audience");

            //creación de claims
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username), //Identifica al usuario.
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), //Identificador único del token.
                new Claim(ClaimTypes.Name, username), //Contiene el nombre del usuario. 
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)); // Especifica la llave secreta.
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256); // Especifica el algoritmo de encriptación.

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(jwtSettings.GetValue<int>("ExpirationMinutes")),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token); 
        }
    }
}
