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
        public bool Lun { get; set; }
        public bool Mar { get; set; }
        public bool Mie { get; set; }

        public bool Jue { get; set; }
        public bool Vie { get; set; }
        public bool Sab { get; set; }
        public bool Dom { get; set; }
        public DateTime Hora { get; set; }
        public DateTime Fecha { get; set; }
    }
}