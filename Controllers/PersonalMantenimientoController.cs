using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using freeEnergyResortAPI.Models;
using freeEnergyResortAPI.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;

namespace freeEnergyResortAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [EnableCors("AllowOrigin")]
    public class PersonalMantenimientoController
    {
        private PersonalMantenimientoContext context;
        private readonly IConfiguration _configuration;

        public PersonalMantenimientoController(IConfiguration configuration)
        {
            _configuration = configuration;
            string mysqlConnStr = configuration.GetConnectionString("DefaultConnection");
            context = new PersonalMantenimientoContext(mysqlConnStr);
        }

        [HttpGet]
        public ActionResult GetPersonalesMantenimientoDisponibles()
        {
            try
            {
                List<PersonalMantenimiento> listPersonalesMantenimiento = context.GetPersonalesMantenimientoDisponibles();
                return new OkObjectResult(listPersonalesMantenimiento);
            }
            catch
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{idPersonalMantenimiento}")]
        public ActionResult SetPersonalMantenimientoCondicion(int idPersonalMantenimiento, PersonalMantenimiento personalMantenimiento)
        {
            try
            {
                int records = context.SetPersonalMantenimientoCondicion(idPersonalMantenimiento, personalMantenimiento);
                return new OkResult();
            }
            catch
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}