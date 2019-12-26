using System;
using System.Collections.Generic;

namespace freeEnergyResortAPI.Models
{
    public class TipoAmbiente
    {
        public int IdTipoAmbiente { get; set; }
        public string Nombre { get; set; }
        public DateTime TiempoOperacionInicio { get; set; }
        public DateTime TiempoOperacionFin { get; set; }
        public List<Ambiente> ListAmbientes { get; set; }
    }
}