using System;

namespace freeEnergyResortAPI.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string UserName { get; set; }
        public string Contrasena { get; set; }
        public string Dni { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public int IdRolUsuario { get; set; }
        public RolUsuario RolUsuario { get; set; }
    }
}