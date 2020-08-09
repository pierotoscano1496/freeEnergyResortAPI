using System;
using System.Collections.Generic;

namespace freeEnergyResortAPI.Models
{
    public class FuenteEnergia
    {
        public int IdFuenteEnergia { get; set; }
        public string CodFuenteEnergia { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public decimal Potencia { get; set; }
        public int IdSectorProduccion { get; set; }
        public SectorProduccion SectorProduccion { get; set; }
        public List<ProduccionEnergia> ListProduccionesEnergia { get; set; }
    }
}