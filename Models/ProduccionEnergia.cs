using System;

namespace freeEnergyResortAPI.Models
{
    public class ProduccionEnergia
    {
        public int IdProduccionEnergia { get; set; }
        public int IdFuenteEnergia { get; set; }
        public FuenteEnergia FuenteEnergia { get; set; }
        public decimal Cantidad { get; set; }
        public DateTime Fecha { get; set; }
    }
}