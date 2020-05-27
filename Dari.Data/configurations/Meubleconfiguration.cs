using Dari.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dari.Data.configurations
{
    class Meubleconfiguration:EntityTypeConfiguration<Meuble>
    {

        public Meubleconfiguration()
        {
            HasOptional(c => c.Client).
                WithMany(m => m.Meubles).
                HasForeignKey(m => m.IdClient).WillCascadeOnDelete(false);

            HasOptional(p => p.MyCategory)
               .WithMany(c => c.Meubles)
               .HasForeignKey(p => p.CategoryMeubId)
               .WillCascadeOnDelete(false);

        }
    }
}
