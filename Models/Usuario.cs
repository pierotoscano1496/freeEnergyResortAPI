using System;

namespace freeEnergyResortAPI.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Dni { get; set; }
        public string Rol { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}