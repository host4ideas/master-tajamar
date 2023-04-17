using ApiCoreCrudDoctores.Models;
using ApiCoreCrudDoctores.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApiCoreCrudDoctores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctoresController : ControllerBase
    {
        private RepositoryHospital repositoryHospital;

        public DoctoresController(RepositoryHospital repositoryHospital)
        {
            this.repositoryHospital = repositoryHospital;
        }

        [HttpGet]
        public async Task<ActionResult<List<Doctor>>> GetDoctores()
        {
            return Ok(await this.repositoryHospital.GetDoctorsAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Doctor>> FindDoctor(int id)
        {
            return Ok(await this.repositoryHospital.FindDoctorAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> CreateDoctor(Doctor doctor)
        {
            await this.repositoryHospital.CreateDoctorAsync(doctor.IdHospital, doctor.Apellido, doctor.Especialidad, doctor.Salario);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteDoctor(int id)
        {
            await this.repositoryHospital.DeleteDoctorAsync(id);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateDoctor(Doctor doctor)
        {
            await this.repositoryHospital.UpdateDoctorAsync(doctor.Id, doctor.IdHospital, doctor.Apellido, doctor.Especialidad, doctor.Salario);
            return Ok();
        }

        [HttpPut]
        [Route("incremento-salario/{id}/{incremento}")]
        public async Task<ActionResult> IncrementarSalario(int id, int incremento)
        {
            await this.repositoryHospital.IncrementarSalarioAsync(id, incremento);
            return Ok();
        }
    }
}
