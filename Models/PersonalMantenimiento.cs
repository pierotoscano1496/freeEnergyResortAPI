using System;

namespace freeEnergyResortAPI.Models
{
    public class PersonalMantenimiento
    {
        public int IdPersonalMantenimiento { get; set; }
        public string CodPersonalMantenimiento { get; set; }
        public string Dni { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int Condicion { get; set; }
    }
}