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
    public class OrdenReparacionController
    {
        private OrdenReparacionContext context;
        private readonly IConfiguration _configuration;

        public OrdenReparacionController(IConfiguration configuration)
        {
            _configuration = configuration;
            string mysqlConnStr = _configuration.GetConnectionString("DefaultConnection");
            context = new OrdenReparacionContext(mysqlConnStr);
        }

        [HttpGet]
        public ActionResult GetOrdenesReparacionPendientes()
        {
            try
            {
                List<OrdenReparacion> listOrdenesReparacion = context.GetOrdenesReparacionPendientes();
                return new OkObjectResult(listOrdenesReparacion);
            }
            catch
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        public ActionResult GetOrdenesReparacionPendientesForAmbientes()
        {
            try
            {
                List<OrdenReparacion> listOrdenesReparacion = context.GetOrdenesReparacionPendientesForAmbientes();
                return new OkObjectResult(listOrdenesReparacion);
            }
            catch
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        public ActionResult GetOrdenesReparacionPendientesForFuentesEnergia()
        {
            try
            {
                List<OrdenReparacion> listOrdenesReparacion = context.GetOrdenesReparacionPendientesForFuentesEnergia();
                return new OkObjectResult(listOrdenesReparacion);
            }
            catch
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        public ActionResult GetOrdenReparacion(int idOrdenReparacion)
        {
            try
            {
                OrdenReparacion ordenReparacion = context.GetOrdenReparacion(idOrdenReparacion);
                return new OkObjectResult(ordenReparacion);
            }
            catch
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public ActionResult AddOrdenReparacion(OrdenReparacion ordenReparacion)
        {
            try
            {
                int lastIdOrdenReparacion = context.AddOrdenReparacion(ordenReparacion);
                ordenReparacion.IdOrdenReparacion = lastIdOrdenReparacion;
                return new CreatedAtActionResult("GetOrdenReparacion", "OrdenReparacion", new { idOrdenReparacion = lastIdOrdenReparacion }, ordenReparacion);
            }
            catch
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public ActionResult AddListOrdenesReparaciones(List<OrdenReparacion> listOrdenesReparacion)
        {
            try
            {
                int cantOrdenesReparacionesCreated = context.AddListOrdenesReparaciones(listOrdenesReparacion);
                // return new CreatedAtActionResult("getAmbiente", "ambiente", new { idAmbiente = 1 }, new Ambiente());
                return new OkObjectResult(new { createdItems = cantOrdenesReparacionesCreated });
            }
            catch
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}