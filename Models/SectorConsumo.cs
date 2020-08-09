using System;
using System.Collections.Generic;

namespace freeEnergyResortAPI.Models
{
    public class SectorConsumo
    {
        public int IdSectorConsumo { get; set; }
        public string CodSectorConsumo { get; set; }
        public string Nombre { get; set; }
        public List<Ambiente> ListAmbientes { get; set; }
    }
}