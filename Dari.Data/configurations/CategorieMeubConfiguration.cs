using Dari.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dari.Data.configurations
{
    class CategorieMeubConfiguration: EntityTypeConfiguration<CategorieMeub>
    {
        public CategorieMeubConfiguration()
        {
            ToTable("MyCategories")
            .HasKey(c => c.CategoryMeubId)
            .Property(c => c.Name).IsRequired().HasMaxLength(50);
        }
    }
}
