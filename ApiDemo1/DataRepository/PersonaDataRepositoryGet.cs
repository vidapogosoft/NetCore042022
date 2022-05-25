using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ApiDemo1.Modelo.Database;
using ApiDemo1.Modelo.DTO;

namespace ApiDemo1.DataRepository
{
    public class PersonaDataRepositoryGet
    {

        public List<Persona> GetPersonasAll()
        {
            using (var context = new DBAeroClubContext())
            {
                return context.Personas.ToList();
            }
        }

        public List<DTOPersona> GetPersonasAll2()
        {
            using (var context = new DBAeroClubContext())
            {

                var x = (

                    from a in context.Personas

                    select new DTOPersona()
                    {
                        IdPersonaResponse = a.IdPersona,
                        IdentificacionResponse = a.Identificacion,
                        NombresCompletosResponse = a.NombresCompletos
                    }

                    ).ToList();

                return x;
            }
        }


        public List<Persona> GetPersonas(string Estado)
        {
            using (var context = new DBAeroClubContext())
            {
                return context.Personas.Where(a => a.Estado == Estado).ToList();
            }
        }

        public List<Persona> GetPersonaByIdentificacion(string Identificacion)
        {
            using (var context = new DBAeroClubContext())
            {
                return context.Personas.Where(a => a.Identificacion == Identificacion).ToList();
            }
        }

        public Persona GetPersonaByIdentificacion2(string Identificacion)
        {
            using (var context = new DBAeroClubContext())
            {
                return context.Personas.Where(a => a.Identificacion == Identificacion).FirstOrDefault();
            }
        }


        public List<Persona> GetPersonaById(int Id, string Estado)
        {
            using (var context = new DBAeroClubContext())
            {
                return context.Personas.Where(a => a.IdPersona == Id && a.Estado == Estado).ToList();
            }
        }


        public Persona GetPersonaById2(int Id)
        {
            using (var context = new DBAeroClubContext())
            {
                return context.Personas.Where(a => a.IdPersona == Id).FirstOrDefault();
            }
        }

    }
}
