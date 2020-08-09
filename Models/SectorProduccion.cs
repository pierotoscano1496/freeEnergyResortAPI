using System;
using System.Collections.Generic;

namespace freeEnergyResortAPI.Models
{
    public class SectorProduccion
    {
        public int IdSectorProduccion { get; set; }
        public string CodSectorProduccion { get; set; }
        public string Nombre { get; set; }
        public List<FuenteEnergia> ListFuentesEnergia { get; set; }
    }
}