using System;
using System.Collections.Generic;
using freeEnergyResortAPI.Context;
using freeEnergyResortAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace freeEnergyResortAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProduccionEnergiaController
    {
        private IConfiguration _configuration;
        private ProduccionEnergiaContext context;
        public ProduccionEnergiaController(IConfiguration configuration)
        {
            _configuration = configuration;
            context = new ProduccionEnergiaContext(configuration.GetConnectionString("DefaultConnection"));
        }

        [HttpGet("{fechaInicio}/{fechaFin}")]
        [Authorize(Policy = "Gerente")]
        public ActionResult GetTotalesProduccionEnergiaInPeriod(DateTime fechaInicio, DateTime fechaFin)
        {
            if (fechaInicio < fechaFin)
            {
                try
                {
                    List<ProduccionEnergia> listProduccionesEnergia = context.GetTotalesProduccionEnergiaInPeriod(fechaInicio, fechaFin);
                    return new OkObjectResult(listProduccionesEnergia);
                }
                catch
                {
                    return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                }
            }
            else
            {
                return new BadRequestObjectResult(new
                {
                    mensaje = "Invalid date range"
                });
            }
        }
    }
}