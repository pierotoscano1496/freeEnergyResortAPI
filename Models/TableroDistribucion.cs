using System;
using System.Collections.Generic;

namespace freeEnergyResortAPI.Models
{
    public class TableroDistribucion
    {
        public int IdTableroDistribucion { get; set; }
        public string NumTableroDistribucion { get; set; }
        public decimal Capacidad { get; set; }
        public string Marca { get; set; }
        public decimal VoltajeOperacion { get; set; }
        public List<Ambiente> ListAmbiente { get; set; }
    }
}