using System;

namespace freeEnergyResortAPI.Models
{
    public class OrdenReparacion
    {
        public int IdOrdenReparacion { get; set; }
        public int? IdAmbiente { get; set; }
        public Ambiente Ambiente { get; set; }
        public int IdPersonalMantenimiento { get; set; }
        public PersonalMantenimiento PersonalMantenimiento { get; set; }
        public int? IdCircuito { get; set; }
        public Circuito Circuito { get; set; }
        public int? IdFuenteEnergia { get; set; }
        public FuenteEnergia FuenteEnergia { get; set; }
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime Fecha { get; set; }
        public int Estado { get; set; }
        public string InformeTecnico { get; set; }
        public DateTime? FechaReparacion { get; set; }
    }
}