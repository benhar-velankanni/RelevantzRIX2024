using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;

using LibraryApi.Model;

using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;

using System.Security.Claims;

using System.Text;

namespace LibraryApi.Controllers

{

    [Route("api/[controller]")]

    [ApiController]

    public class AuthenticationController : ControllerBase

    {

        [HttpPost("login")]

        public IActionResult Login([FromBody] LoginModel model)

        {

            if (model.UserName == "admin" && model.Password == "admin")

            {

                var claims = new[]

                {

                    new Claim(ClaimTypes.Name, model.UserName)

                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SuperSecretKey12345555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555555"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(

                    issuer: "JwtDemoIssuer",

                    audience: "JwtDemoAudience",

                    claims: claims,

                    expires: DateTime.Now.AddMinutes(50),

                    signingCredentials: creds

                    );

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });

            }

            return Unauthorized();

        }

    }

}

