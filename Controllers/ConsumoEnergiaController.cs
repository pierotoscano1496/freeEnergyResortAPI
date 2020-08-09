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
    public class ConsumoEnergiaController
    {
        private ConsumoEnergiaContext context;
        private readonly IConfiguration _configuration;
        public ConsumoEnergiaController(IConfiguration configuration)
        {
            _configuration = configuration;
            context = new ConsumoEnergiaContext(_configuration.GetConnectionString("DefaultConnection"));
        }

        [HttpGet("{fechaInicio}/{fechaFin}")]
        public ActionResult GetTotalesConsumoEnergiaInPeriod(DateTime fechaInicio, DateTime fechaFin)
        {
            if (fechaInicio < fechaFin)
            {
                try
                {
                    List<ConsumoEnergia> listConsumosEnergia = context.GetTotalesConsumoEnergiaInPeriod(fechaInicio, fechaFin);
                    return new OkObjectResult(listConsumosEnergia);
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