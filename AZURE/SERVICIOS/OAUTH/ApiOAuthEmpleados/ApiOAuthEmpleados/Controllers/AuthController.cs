using ApiOAuthEmpleados.Helpers;
using ApiOAuthEmpleados.Models;
using ApiOAuthEmpleados.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace ApiOAuthEmpleados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private RepositoryEmpleados repositoryEmpleados;
        private HelperOAuthToken authToken;

        public AuthController(RepositoryEmpleados repositoryEmpleados, HelperOAuthToken authToken)
        {
            this.repositoryEmpleados = repositoryEmpleados;
            this.authToken = authToken;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> Login(LoginModel loginModel)
        {
            Empleado? emp = await this.repositoryEmpleados.ExisteEmpleadoAsync(loginModel.Username, int.Parse(loginModel.Password));
            if (emp == null)
            {
                return Unauthorized();
            }

            SigningCredentials credentials = new(this.authToken.GetKeyToken(), SecurityAlgorithms.HmacSha512);
            JwtSecurityToken token = new(issuer: this.authToken.Issuer,
                                         audience: this.authToken.Audience,
                                         signingCredentials: credentials,
                                         expires: DateTime.UtcNow.AddMinutes(30),
                                         notBefore: DateTime.UtcNow);
            return Ok(new
            {
                response = new JwtSecurityTokenHandler().WriteToken(token),
            });
        }
    }
}
