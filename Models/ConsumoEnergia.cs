using System;

namespace freeEnergyResortAPI.Models
{
    public class ConsumoEnergia
    {
        public int IdConsumoEnergia { get; set; }
        public int IdAmbiente { get; set; }
        public Ambiente Ambiente { get; set; }
        public int IdTableroDistribucion { get; set; }
        public TableroDistribucion TableroDistribucion { get; set; }
        public DateTime Fecha { get; set; }
        public decimal TotalConsumo { get; set; }
    }
}