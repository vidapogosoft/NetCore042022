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
   
    public class PilotoServices : IPiloto
    {
        public PilotoDataRepositoryPost data = new PilotoDataRepositoryPost();

        public IEnumerable<DTOResultSet> TranPiloto(Piloto NewItem)
        {
           return data.InsertPiloto(NewItem);
        }
    }
}
