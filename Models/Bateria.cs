using System;

namespace freeEnergyResortAPI.Models
{
    public class Bateria
    {
        public int IdBateria { get; set; }
        public decimal Voltaje { get; set; }
        public decimal VoltajeMin { get; set; }
        public decimal VoltajeMax { get; set; }
        public decimal Capacidad { get; set; }
        public int TasaDescarga { get; set; }
    }
}