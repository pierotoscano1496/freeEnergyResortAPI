using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using freeEnergyResortAPI.Context;
using freeEnergyResortAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

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
                    string tokenString = GenerateJWTToken(usuarioLogged);
                    return new OkObjectResult(new { token = tokenString, usuario = usuarioLogged });
                }
                else
                {
                    return new NoContentResult();
                }
            }
            catch (Exception ex)
            {
                string mess = ex.Message;
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        protected string GenerateJWTToken(Usuario usuario)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new Claim[] {
                new Claim(JwtRegisteredClaimNames.Sub, usuario.Correo),
                new Claim("fullName", usuario.Nombres + usuario.Apellidos),
                new Claim("role", usuario.RolUsuario.Tipo.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}