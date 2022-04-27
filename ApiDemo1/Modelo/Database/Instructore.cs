using System;
using System.Collections.Generic;

#nullable disable

namespace ApiDemo1.Modelo.Database
{
    public partial class Instructore
    {
        public int IdInstructor { get; set; }
        public int? IdPersona { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public string Estado { get; set; }
    }
}
