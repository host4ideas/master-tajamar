using ApiSegundaPractica.Models;
using ApiSegundaPractica.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace ApiSegundaPractica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CubosController : ControllerBase
    {
        private RepositoryCubos repositoryCubos;

        public CubosController(RepositoryCubos repositoryCubos)
        {
            this.repositoryCubos = repositoryCubos;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cubo>>> GetCubos()
        {
            return await this.repositoryCubos.GetCubosAsync();
        }

        [HttpGet("{marca}")]
        public async Task<ActionResult<List<Cubo>>> GetCubosMarca(string marca)
        {
            return await this.repositoryCubos.GetCubosMarca(marca);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> RegisterUser(InsertUserModel newUser)
        {
            await this.repositoryCubos.InsertUserAsync(newUser.Nombre, newUser.Email, newUser.Password, newUser.Imagen);

            return CreatedAtAction(null, null);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> InsertarCubo(InsertCuboModel newCubo)
        {
            await this.repositoryCubos.InsertCuboAsync(newCubo.Nombre, newCubo.Marca, newCubo.Imagen, newCubo.Precio);

            return CreatedAtAction(null, null);
        }

        [HttpGet("[action]")]
        [Authorize]
        public async Task<ActionResult<Usuario?>> Profile()
        {
            Claim claim = HttpContext.User.Claims
                .SingleOrDefault(x => x.Type == "UserData");
            string jsonEmpleado =
                claim.Value;
            Usuario empleado = JsonConvert.DeserializeObject<Usuario>
                (jsonEmpleado);
            return empleado;
        }

        [HttpGet("[action]")]
        [Authorize]
        public async Task<ActionResult<List<CompraCubo>>> GetUserPedidos()
        {
            Claim claim = HttpContext.User.Claims
                .SingleOrDefault(x => x.Type == "UserData");
            string jsonEmpleado =
                claim.Value;
            Usuario empleado = JsonConvert.DeserializeObject<Usuario>
                (jsonEmpleado);

            return await this.repositoryCubos.GetComprasUsuarioAsync(empleado.IdUsuario);
        }

        [HttpPost("[action]")]
        [Authorize]
        public async Task<ActionResult> RealizarPedido(InsertCompraModel newCompra)
        {
            Claim claim = HttpContext.User.Claims
    .SingleOrDefault(x => x.Type == "UserData");
            string jsonEmpleado =
                claim.Value;
            Usuario empleado = JsonConvert.DeserializeObject<Usuario>
                (jsonEmpleado);

            await this.repositoryCubos.RealizarPedidoAsync(newCompra.IdCubo, empleado.IdUsuario);

            return CreatedAtAction(null, null);
        }
    }
}
