using System;

namespace freeEnergyResortAPI.Models
{
    public class PersonalMantenimiento : Usuario
    {
        public string CodPersonalMantenimiento { get; set; }
        public int Condicion { get; set; }
    }
}