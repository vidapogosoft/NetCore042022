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

    }
}
