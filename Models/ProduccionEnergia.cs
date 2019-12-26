using System;

namespace freeEnergyResortAPI.Models
{
    public class ProduccionEnergia
    {
        public int IdProduccionEnergia { get; set; }
        public int IdFuenteEnergia { get; set; }
        public FuenteEnergia FuenteEnergia { get; set; }
        public int IdBateria { get; set; }
        public Bateria Bateria { get; set; }
        public int IdTableroDistribucion { get; set; }
        public TableroDistribucion TableroDistribucion { get; set; }
        public DateTime Fecha { get; set; }
        public decimal TotalEnergia { get; set; }
        public decimal EnergiaGanada { get; set; }
    }
}