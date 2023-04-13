using ApiCoreHospitales.Data;
using ApiCoreHospitales.Models;
using ApiCoreHospitales.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCoreHospitales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalesController : ControllerBase
    {
        private RepositoryHospital repositoryHospital;

        public HospitalesController(RepositoryHospital repositoryHospital)
        {
            this.repositoryHospital = repositoryHospital;
        }

        [HttpGet]
        public async Task<ActionResult<List<Hospital>>> GetHospitales()
        {
            return await this.repositoryHospital.GetHospitalesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Hospital>> FindHospital(int id)
        {
            Hospital? hosp = await this.repositoryHospital.FindHospitalAsync(id);

            if (hosp == null)
            {
                return NotFound();
            }

            return Ok(hosp);
        }
    }
}
