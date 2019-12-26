using System;

namespace freeEnergyResortAPI.Models
{
    public class FuenteEnergia
    {
        public int IdFuenteEnergia { get; set; }
        public string Tipo { get; set; }
        public decimal EnergiaMin { get; set; }
        public decimal EnergiaMax { get; set; }
    }
}