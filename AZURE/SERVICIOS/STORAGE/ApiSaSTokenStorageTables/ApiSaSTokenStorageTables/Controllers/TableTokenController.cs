﻿using ApiSaSTokenStorageTables.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiSaSTokenStorageTables.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableTokenController : Controller
    {
        private ServiceSaSToken service;

        public TableTokenController(ServiceSaSToken service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("[action]/{curso}")]
        public ActionResult<string> GenerateToken(string curso)
        {
            string token = this.service.GenerateSaSToken(curso);
            return Json(new
            {
                token
            });
        }
    }
}
