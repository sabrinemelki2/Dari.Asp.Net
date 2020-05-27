using Dari.Data.configurations;
using Dari.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dari.Data
{
   public class DariContext:DbContext
    {
       

        public DariContext():base("name=MaChaine")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<DariContext>());
           // Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DariContext>());
        }
        
        public DbSet<Meuble> Meubles { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Panier> Paniers { get; set; }
        public DbSet<Abonnement> Abonnements { get; set; }
        public DbSet<TyAbo> TyAbos { get; set; }
        public DbSet<Annonce> Annonces { get; set; }
        public DbSet<CategorieMeub> CategorieMeubs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new Meubleconfiguration());

        }

       

    }
}
