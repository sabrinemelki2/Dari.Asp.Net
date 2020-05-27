using Dari.Domain.Entities;
using Dari.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Dari.Data.Infrastructure;

namespace Dari.service
{
    public class CategorieService : Service<CategorieMeub>, ICategorieService

    {
        static IDataBaseFactory factory = new DataBaseFactory();
        static IUnitOfWork UTK = new UnitOfWork(factory);
        public CategorieService():base(UTK)
        { }
    }
}
