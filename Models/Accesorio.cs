using System;

namespace freeEnergyResortAPI.Models
{
    public class Accesorio
    {
        public int IdAccesorio { get; set; }
        public string CodAccesorio { get; set; }
        public string Tipo { get; set; }
        public decimal ConsumoElectrico { get; set; }
        public int IdAmbiente { get; set; }
        public Ambiente Ambiente { get; set; }
    }
}