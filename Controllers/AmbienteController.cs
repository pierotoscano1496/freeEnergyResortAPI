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

namespace freeEnergyResortAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AmbienteController
    {
        private AmbienteContext context;
        private readonly IConfiguration _configuration;

        public AmbienteController(IConfiguration configuration)
        {
            this._configuration = configuration;
            context = new AmbienteContext(configuration.GetConnectionString("DefaultConnection"));
        }

        [HttpGet]
        public ActionResult GetAllAmbientes()
        {
            try
            {
                List<Ambiente> listAmbientes = context.GetAllAmbientes();
                return new OkObjectResult(listAmbientes);
            }
            catch
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        public ActionResult GetAllAmbientesDetails()
        {
            try
            {
                List<Ambiente> listAmbientes = context.GetAllAmbientesDetails();
                return new OkObjectResult(listAmbientes);
            }
            catch
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{idAmbiente}")]
        public ActionResult GetAmbiente(int idAmbiente)
        {
            try
            {
                Ambiente ambiente = context.GetAmbiente(idAmbiente);
                return new OkObjectResult(ambiente);
            }
            catch
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}