using System;
using freeEnergyResortAPI.Context;
using freeEnergyResortAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace freeEnergyResortAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UsuarioController
    {
        private IConfiguration _configuration;
        private UsuarioContext context;

        public UsuarioController(IConfiguration configuration)
        {
            _configuration = configuration;
            context = new UsuarioContext(configuration.GetConnectionString("DefaultConnection"));
        }

        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {
            try
            {
                Usuario usuarioLogged = context.Login(usuario);
                if (usuarioLogged != null)
                {
                    return new OkObjectResult(usuarioLogged);
                }
                else
                {
                    return new NoContentResult();
                }
            }
            catch
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}