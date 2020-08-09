using System;
using System.Collections.Generic;
using freeEnergyResortAPI.Context;
using freeEnergyResortAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace freeEnergyResortAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [EnableCors("AllowOrigin")]
    public class SectorConsumoController
    {
        private SectorConsumoContext context;
        private readonly IConfiguration _configuration;

        public SectorConsumoController(IConfiguration configuration)
        {
            _configuration = configuration;
            context = new SectorConsumoContext(configuration.GetConnectionString("DefaultConnection"));
        }

        [HttpGet]
        public ActionResult GetAllSectoresConsumoDetails()
        {
            try
            {
                List<SectorConsumo> listSectoresConsumo = context.GetAllSectoresConsumoDetails();
                return new OkObjectResult(listSectoresConsumo);
            }
            catch
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{fechaInicio}/{fechaFin}")]
        public ActionResult GetConsumosEnergiaOfSectoresConsumoInPeriod(DateTime fechaInicio, DateTime fechaFin)
        {
            if (fechaInicio < fechaFin)
            {
                try
                {
                    List<SectorConsumo> listSectoresConsumo = context.GetConsumosEnergiaOfSectoresConsumoInPeriod(fechaInicio, fechaFin);
                    return new OkObjectResult(listSectoresConsumo);
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