using Dari.Data.Infrastructure;
using Dari.Domain.Entities;
using Dari.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dari.service
{
    public class MeubleService : Service<Meuble>, IMeubleService
    {
        static IDataBaseFactory factory = new DataBaseFactory();
        static IUnitOfWork UTK = new UnitOfWork(factory);
        public MeubleService():base(UTK)
        { }
        public IEnumerable<Meuble> GetMeublesByClient(int IdClient)
        {
            return GetMany(m => m.IdClient == IdClient);
        }

        public IEnumerable<Meuble> GetByCategory(int categoryId)
        {
            return GetMany(p => p.CategoryMeubId == categoryId);
        }
    }
}
