using System;

namespace freeEnergyResortAPI.Models
{
    public class PlanEnergia
    {
        public int IdPlanEnergia { get; set; }
        public int IdAmbiente { get; set; }
        public Ambiente Ambiente { get; set; }
        public int IdTableroDistribucion { get; set; }
        public TableroDistribucion TableroDistribucion { get; set; }
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public int NumDia { get; set; }
        public DateTime Hora { get; set; }
    }
}