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
        private AmbienteContext objContext;
        private readonly IConfigurationRoot _configuration;

        public AmbienteController(IConfigurationRoot configuration)
        {
            this._configuration = configuration;
            string mysqlConnStr = _configuration.GetConnectionString("DefaultConnection");
            objContext = new AmbienteContext(mysqlConnStr);
        }

        [HttpGet]
        public ActionResult GetAllAmbientes()
        {

            try
            {
                List<Ambiente> listAmbientes = objContext.GetAllAmbientes();
                return new OkObjectResult(listAmbientes);
            }
            catch
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}