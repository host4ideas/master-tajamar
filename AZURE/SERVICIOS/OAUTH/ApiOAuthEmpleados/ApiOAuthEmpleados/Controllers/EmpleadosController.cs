using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiOAuthEmpleados.Data;
using ApiOAuthEmpleados.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Newtonsoft.Json;
using ApiOAuthEmpleados.Repositories;
using NSwag.Annotations;

namespace ApiOAuthEmpleados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [OpenApiTag("EMPLEADOS")]
    public class EmpleadosController : ControllerBase
    {
        private readonly EmpleadosContext _context;
        private readonly RepositoryEmpleados repositoryEmpleados;

        public EmpleadosController(EmpleadosContext context, RepositoryEmpleados repositoryEmpleados)
        {
            _context = context;
            this.repositoryEmpleados = repositoryEmpleados;
        }

        // GET: api/Empleados
        /// <summary>
        /// Obtiene el conjunto de Empleados, tabla EMP
        /// </summary>
        /// <remarks>
        /// Método para devoler todos los empleados de la BBDD.
        /// Dicho método está protegido por Token.
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>
        /// <response code="401">Unauthorized. No autorizado.</response>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<Empleado>>> GetEmpleados()
        {
            HttpContext.User.FindFirstValue("UserData");

            if (_context.Empleados == null)
            {
                return NotFound();
            }
            return await _context.Empleados.ToListAsync();
        }

        // GET: api/Empleados/5
        /// <summary>
        /// Obtiene una Empresa por su Id, tabla EMPRESAS.
        /// </summary>
        /// <remarks>
        /// Permite buscar una Empresa por el ID de empresa
        /// </remarks>
        /// <param name="id">Id (GUID) del objeto.</param>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>    
        [HttpGet("{id}")]
        public async Task<ActionResult<Empleado>> FindEmpleado(int id)
        {
            if (_context.Empleados == null)
            {
                return NotFound();
            }
            var empleado = await _context.Empleados.FindAsync(id);

            if (empleado == null)
            {
                return NotFound();
            }

            return empleado;
        }

        // PUT: api/Empleados/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpleado(int id, Empleado empleado)
        {
            if (id != empleado.IdEmpleado)
            {
                return BadRequest();
            }

            _context.Entry(empleado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Empleados
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Empleado>> PostEmpleado(Empleado empleado)
        {
            if (_context.Empleados == null)
            {
                return Problem("Entity set 'EmpleadosContext.Empleados'  is null.");
            }
            _context.Empleados.Add(empleado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmpleado", new { id = empleado.IdEmpleado }, empleado);
        }

        // DELETE: api/Empleados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleado(int id)
        {
            if (_context.Empleados == null)
            {
                return NotFound();
            }
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }

            _context.Empleados.Remove(empleado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmpleadoExists(int id)
        {
            return (_context.Empleados?.Any(e => e.IdEmpleado == id)).GetValueOrDefault();
        }

        [Authorize]
        [HttpGet("[action]")]
        public async Task<ActionResult<Empleado>> PerfilEmpleado()
        {
            Claim claim = HttpContext.User.Claims.SingleOrDefault(x => x.Type == "UserData")!;
            string jsonEmpleado = claim.Value;
            return JsonConvert.DeserializeObject<Empleado>(jsonEmpleado)!;
        }

        [Authorize]
        [HttpGet("[action]")]
        public async Task<ActionResult<List<Empleado>>> CompisCurro()
        {
            string jsonEmpleado = HttpContext.User.Claims.SingleOrDefault(x => x.Type == "UserData")!.Value;
             Empleado empleado = JsonConvert.DeserializeObject<Empleado>(jsonEmpleado)!;
            return await this.repositoryEmpleados.GetCompisCurroAsync(empleado.IdDepartamento);
        }
    }
}
