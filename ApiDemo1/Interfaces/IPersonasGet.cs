using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ApiDemo1.Modelo.Database;
using ApiDemo1.Modelo.DTO;

namespace ApiDemo1.Interfaces
{
    public interface IPersonasGet
    {
        IEnumerable<Persona> ListPersonaAll { get; }
        IEnumerable<DTOPersona> ListPersonaAll2 { get; }
        IEnumerable<Persona> ListPersonas(string Estado);
        IEnumerable<Persona> ListPersonaByIdentificacion(string Identificacion);
        IEnumerable<Persona> ListPersonaById(int Id, string Estado);
        void InsertPersona(Persona NewItem);
        void UpdatePersona(Persona Item);
        void UpdatePersona2(int IdPersona, string Identificacion,
                string Nombres, string Apellidos, string Estado);
    }

}
