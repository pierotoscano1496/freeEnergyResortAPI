using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using freeEnergyResortAPI.Models;

namespace freeEnergyResortAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AmbienteController
    {

        [HttpGet]
        public ActionResult getAllAmbientes()
        {
            List<Ambiente> listAmbientes = new List<Ambiente>();

            Ambiente a1 = new Ambiente
            {
                IdAmbiente = 1,
                CodAmbiente = "abc123",
                Nombre = "Hotel"
            };

            Ambiente a2 = new Ambiente
            {
                IdAmbiente = 2,
                CodAmbiente = "abc456",
                Nombre = "Restaurante"
            };

            Ambiente a3 = new Ambiente
            {
                IdAmbiente = 3,
                CodAmbiente = "xyz321",
                Nombre = "Bar el trufo"
            };

            listAmbientes.Add(a1);
            listAmbientes.Add(a2);
            listAmbientes.Add(a3);
            
            return new OkObjectResult(listAmbientes);
        }
    }
}