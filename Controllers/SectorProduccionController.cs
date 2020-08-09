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
    public class SectorProduccionController
    {
        private SectorProduccionContext context;
        private readonly IConfiguration _configuration;
        public SectorProduccionController(IConfiguration configuration)
        {
            _configuration = configuration;
            context = new SectorProduccionContext(configuration.GetConnectionString("DefaultConnection"));
        }

        [HttpGet]
        public ActionResult GetAllSectoresProduccion()
        {
            try
            {
                List<SectorProduccion> listSectoresProduccion = context.GetAllSectoresProduccion();
                return new OkObjectResult(listSectoresProduccion);
            }
            catch
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        public ActionResult GetAllSectoresProduccionDetails()
        {
            try
            {
                List<SectorProduccion> listSectoresProduccion = context.GetAllSectoresProduccionDetails();
                return new OkObjectResult(listSectoresProduccion);
            }
            catch
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{idSectorProduccion}")]
        public ActionResult GetSectorProduccionDetails(int idSectorProduccion)
        {
            try
            {
                SectorProduccion sectorProduccion = context.GetSectorProduccionDetails(idSectorProduccion);
                return new OkObjectResult(sectorProduccion);
            }
            catch
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{fechaInicio}/{fechaFin}")]
        public ActionResult GetProduccionesEnergiaOfSectoresProduccionInPeriod(DateTime fechaInicio, DateTime fechaFin)
        {
            if (fechaInicio < fechaFin)
            {
                try
                {
                    List<SectorProduccion> listSectoresProduccion = context.GetProduccionesEnergiaOfSectoresProduccionInPeriod(fechaInicio, fechaFin);
                    return new OkObjectResult(listSectoresProduccion);
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