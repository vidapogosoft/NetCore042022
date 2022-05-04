using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ApiDemo1.Modelo.DTO;
using ApiDemo1.Modelo.Database;

namespace ApiDemo1.Interfaces
{
    public interface IPiloto
    {
        IEnumerable<DTOResultSet> TranPiloto(Piloto NewItem);
    }
}
