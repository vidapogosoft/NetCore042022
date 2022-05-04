using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ApiDemo1.Modelo.Database;
using ApiDemo1.Modelo.DTO;

using Microsoft.EntityFrameworkCore;

namespace ApiDemo1.DataRepository
{
    public class PilotoDataRepositoryPost
    {
        public List<DTOResultSet> InsertPiloto(Piloto NewItem)
        {
            using (var ctx = new DBAeroClubContext())
            {
                return ctx.Resultado.FromSqlRaw("TranPiloto {0},{1}", NewItem.IdPersona, NewItem.IdPiloto).ToList();
            }
        }

    }
}
