using System;
using System.Collections.Generic;

#nullable disable

namespace ApiDemo1.Modelo.Database
{
    public partial class PilotoVuelo
    {
        public int IdPilotoVuelos { get; set; }
        public int? IdVuelo { get; set; }
        public int? IdPiloto { get; set; }
        public int? AnioVuelo { get; set; }
        public int? DiaInicio { get; set; }
        public int? DiaFin { get; set; }
        public int? HoraInicio { get; set; }
        public int? HoraFin { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public string Estado { get; set; }
    }
}
