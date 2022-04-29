using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ApiDemo1.Interfaces;
using ApiDemo1.DataRepository;
using ApiDemo1.Modelo.Database;
using ApiDemo1.Modelo.DTO;

namespace ApiDemo1.Services
{
    public class PersonaServicesGet: IPersonasGet
    {
        public PersonaDataRepositoryGet data = new PersonaDataRepositoryGet();

        public IEnumerable<Persona> ListPersonaAll 
        { 
            get { return data.GetPersonasAll(); } 
        }

        public IEnumerable<DTOPersona> ListPersonaAll2 
        {
            get { return data.GetPersonasAll2(); }
        }

        public IEnumerable<Persona> ListPersonas(string Estado)
        {
            return data.GetPersonas(Estado);
        }

        public IEnumerable<Persona> ListPersonaByIdentificacion(string Identificacion)
        {
            return data.GetPersonaByIdentificacion(Identificacion);
        }

        public IEnumerable<Persona> ListPersonaById(int Id, string Estado)
        {
            return data.GetPersonaById(Id, Estado);
        }

    }
}
