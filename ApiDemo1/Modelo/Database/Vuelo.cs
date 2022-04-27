using System;
using System.Collections.Generic;

#nullable disable

namespace ApiDemo1.Modelo.Database
{
    public partial class Vuelo
    {
        public int IdVuelo { get; set; }
        public int? IdInstructor { get; set; }
        public int? IdHorario { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public string Estado { get; set; }
    }
}
