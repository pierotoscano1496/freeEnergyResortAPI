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
    public class FuenteEnergiaController
    {
        private FuenteEnergiaContext context;
        private readonly IConfiguration _configuration;
        public FuenteEnergiaController(IConfiguration configuration)
        {
            _configuration = configuration;
            context = new FuenteEnergiaContext(configuration.GetConnectionString("DefaultConnection"));
        }

        [HttpGet("{idSectorProduccion}")]
        public ActionResult GetFuentesEnergiaBySectorProduccion(int idSectorProduccion)
        {
            try
            {
                List<FuenteEnergia> listFuentesEnergia = context.GetFuentesEnergiaBySectorProduccion(idSectorProduccion);
                return new OkObjectResult(listFuentesEnergia);
            }
            catch
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{idFuenteEnergia}")]
        public ActionResult GetFuenteEnergia(int idFuenteEnergia)
        {
            try
            {
                FuenteEnergia fuenteEnergia = context.GetFuenteEnergia(idFuenteEnergia);
                return new OkObjectResult(fuenteEnergia);
            }
            catch
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}