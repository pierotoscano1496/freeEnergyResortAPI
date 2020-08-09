using System;
using System.Collections.Generic;

namespace freeEnergyResortAPI.Models
{
    public class Ambiente
    {
        public int IdAmbiente { get; set; }
        public string CodAmbiente { get; set; }
        public string Nombre { get; set; }
        public int IdSectorConsumo { get; set; }
        public SectorConsumo SectorConsumo { get; set; }
        public List<Circuito> ListCircuitos { get; set; }
        public List<ConsumoEnergia> ListConsumosEnergia { get; set; }
    }
}