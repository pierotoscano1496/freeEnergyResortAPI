using System;

namespace freeEnergyResortAPI.Models
{
    public class ConsumoEnergia
    {
        public int IdConsumoEnergia { get; set; }
        public decimal Cantidad { get; set; }
        public DateTime Fecha { get; set; }
        public int IdAmbiente { get; set; }
        public Ambiente Ambiente { get; set; }
    }
}