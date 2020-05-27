using Dari.Domain.Entities;
using Dari.Service;
using System.Collections;
using System.Collections.Generic;

namespace Dari.service
{
    public interface IMeubleService:IService<Meuble>

    {
        IEnumerable<Meuble> GetMeublesByClient(int IdClient);
        IEnumerable<Meuble> GetByCategory(int categoryMeubId);
        
    }
}
