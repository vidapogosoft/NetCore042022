using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ApiDemo1.Modelo.Database;

namespace ApiDemo1.DataRepository
{
    public class PersonaDataRepositoryPost
    {
        public void InsertPersona(Persona NewItem)
        {
            using (var ctx = new DBAeroClubContext())
            {
                ctx.Personas.Add(NewItem);
                ctx.SaveChanges();
            }
        }

        public void UpdatePersona(Persona Item)
        {
            using (var ctx = new DBAeroClubContext())
            {
                var DatoRegistrado = ctx.Personas.Where(a => a.Estado == "ACTIVO"
                && a.IdPersona == Item.IdPersona).FirstOrDefault();

                if (DatoRegistrado != null)
                {
                    DatoRegistrado.IdPersona = Item.IdPersona;
                    DatoRegistrado.Identificacion = Item.Identificacion;
                    DatoRegistrado.Nombres = Item.Nombres;
                    DatoRegistrado.Apellidos = Item.Apellidos;
                    DatoRegistrado.NombresCompletos = Item.Nombres + " " + Item.Apellidos;
                    DatoRegistrado.Estado = Item.Estado;
                    DatoRegistrado.FechaIngreso = DateTime.Now;

                    ctx.SaveChanges();
                }

            }

        }

        public void UpdatePersona2(int IdPersona, string Identificacion,
                string Nombres, string Apellidos, string Estado)
        {
            using (var ctx = new DBAeroClubContext())
            {
                var DatoRegistrado = ctx.Personas.Where(a => a.Estado == "ACTIVO"
                && a.IdPersona == IdPersona).FirstOrDefault();

                if (DatoRegistrado != null)
                {
                    DatoRegistrado.IdPersona = IdPersona;
                    DatoRegistrado.Identificacion = Identificacion;
                    DatoRegistrado.Nombres = Nombres;
                    DatoRegistrado.Apellidos = Apellidos;
                    DatoRegistrado.NombresCompletos = Nombres + " " + Apellidos;
                    DatoRegistrado.Estado = Estado;
                    DatoRegistrado.FechaIngreso = DateTime.Now;

                    ctx.SaveChanges();
                }

            }

        }

        public void DeletePersona(Persona Item)
        {
            using (var ctx = new DBAeroClubContext())
            {
                var DatoRegistrado = ctx.Personas.Where(a => a.Estado == "ACTIVO"
                && a.IdPersona == Item.IdPersona).FirstOrDefault();

                if (DatoRegistrado != null)
                {
                    ctx.Personas.Remove(DatoRegistrado);

                    ctx.SaveChanges();
                }

            }

        }
    }
}
