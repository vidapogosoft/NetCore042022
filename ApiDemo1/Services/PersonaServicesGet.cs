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
        public PersonaDataRepositoryPost dataPost = new PersonaDataRepositoryPost();

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

        public Persona ListPersonaById2(int Id)
        {
            return data.GetPersonaById2(Id);
        }

        public void InsertPersona(Persona NewItem)
        {
            NewItem.NombresCompletos = NewItem.Nombres + ' ' + NewItem.Apellidos;
            NewItem.FechaIngreso = DateTime.Now;
            NewItem.Estado = "ACTIVO";

            dataPost.InsertPersona(NewItem);
        }

        public void UpdatePersona(Persona Item)
        {
            dataPost.UpdatePersona(Item);
        }

        public void UpdatePersona2(int IdPersona, string Identificacion,
                string Nombres, string Apellidos, string Estado)
        {
            dataPost.UpdatePersona2(IdPersona, Identificacion,
                Nombres,  Apellidos, Estado);
        }

        public void DeletePersona(Persona Item)
        {
            dataPost.DeletePersona(Item);
        }
    }
}
