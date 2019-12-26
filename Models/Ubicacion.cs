using System;
using System.Collections.Generic;

namespace freeEnergyResortAPI.Models
{
    public class Ubicacion
    {
        public int IdUbicacion { get; set; }
        public string Pabellon { get; set; }
        public int Piso { get; set; }
        public int Campus { get; set; }
        public List<Ambiente> ListAmbientes { get; set; }
    }
}