using ApiHospitalPractica.Helpers;
using ApiHospitalPractica.Models;
using ApiHospitalPractica.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ApiHospitalPractica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private HelperOAuthToken authToken;
        private RepositoryHospital repository;

        public AuthController(RepositoryHospital repository, HelperOAuthToken authToken)
        {
            this.repository = repository;
            this.authToken = authToken;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> Login(LoginModel loginModel)
        {
            Hospital? emp = await this.repository.ExisteHospitalAsync(loginModel.Username, loginModel.Password);

            if (emp == null)
            {
                return Unauthorized();
            }

            SigningCredentials credentials = new(this.authToken.GetKeyToken(), SecurityAlgorithms.HmacSha512);

            string jsonEmpleado = JsonConvert.SerializeObject(emp);
            Claim[] informacion = new[]
            {
                new Claim("UserData", jsonEmpleado)
            };

            JwtSecurityToken token = new(
                            claims: informacion,
                            issuer: this.authToken.Issuer,
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
