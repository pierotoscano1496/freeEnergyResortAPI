using System;

namespace freeEnergyResortAPI.Models
{
    public class Circuito
    {
        public int IdCircuito { get; set; }
        public string CodCircuito { get; set; }
        public string Nombre { get; set; }
        public int IdAmbiente { get; set; }
        public Ambiente Ambiente { get; set; }
    }
}