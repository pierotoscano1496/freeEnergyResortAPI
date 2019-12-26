using System;
using System.Collections.Generic;

namespace freeEnergyResortAPI.Models
{
    public class Ambiente
    {
        public int IdAmbiente { get; set; }
        public string CodAmbiente { get; set; }
        public int IdUbicacion { get; set; }
        public Ubicacion Ubicacion { get; set; }
        public int IdTipoAmbiente { get; set; }
        public TipoAmbiente TipoAmbiente { get; set; }
        public int IdTableroDistribucion { get; set; }
        public TableroDistribucion TableroDistribucion { get; set; }
        public string Nombre { get; set; }
        public List<Accesorio> ListAccesorios { get; set; }
    }
}