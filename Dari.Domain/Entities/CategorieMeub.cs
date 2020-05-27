using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dari.Domain.Entities
{
    public class CategorieMeub
    {
        [Key]
        public int CategoryMeubId { get; set; }
        public string Name { get; set; }
   
        public virtual ICollection<Meuble> Meubles { get; set; }
    }
}
