using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dari.Domain.Entities
{
   public class Panier
    {
        [Key]
        public int pid { get; set; }
        public double prixtot { get; set; }
        public virtual ICollection<Meuble> Meubles { get; set; }

    }
}
