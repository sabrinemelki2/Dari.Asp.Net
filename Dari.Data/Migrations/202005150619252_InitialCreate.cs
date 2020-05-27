namespace Dari.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abonnements",
                c => new
                    {
                        Clientfk = c.Int(nullable: false),
                        Productfk = c.Int(nullable: false),
                        DateAchat = c.DateTime(nullable: false),
                        DateFin = c.DateTime(nullable: false),
                        TyAbo_IdAbo = c.Int(),
                        Client_IdClient = c.Int(),
                    })
                .PrimaryKey(t => new { t.Clientfk, t.Productfk })
                .ForeignKey("dbo.TyAboes", t => t.TyAbo_IdAbo)
                .ForeignKey("dbo.Clients", t => t.Client_IdClient)
                .Index(t => t.TyAbo_IdAbo)
                .Index(t => t.Client_IdClient);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        IdClient = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Prenom = c.String(),
                        Tel = c.String(),
                        Mail = c.String(),
                        TyAbo_IdAbo = c.Int(),
                    })
                .PrimaryKey(t => t.IdClient)
                .ForeignKey("dbo.TyAboes", t => t.TyAbo_IdAbo)
                .Index(t => t.TyAbo_IdAbo);
            
            CreateTable(
                "dbo.Meubles",
                c => new
                    {
                        IdMeuble = c.Int(nullable: false, identity: true),
                        Titre = c.String(),
                        Category = c.String(),
                        Image = c.String(),
                        Description = c.String(),
                        Prix = c.Double(nullable: false),
                        Livraison = c.Int(nullable: false),
                        Etat = c.Int(nullable: false),
                        Disponibilite = c.Int(nullable: false),
                        dateAnn = c.DateTime(nullable: false),
                        IdClient = c.Int(),
                        Panier_pid = c.Int(),
                    })
                .PrimaryKey(t => t.IdMeuble)
                .ForeignKey("dbo.Clients", t => t.IdClient)
                .ForeignKey("dbo.Paniers", t => t.Panier_pid)
                .Index(t => t.IdClient)
                .Index(t => t.Panier_pid);
            
            CreateTable(
                "dbo.TyAboes",
                c => new
                    {
                        IdAbo = c.Int(nullable: false, identity: true),
                        Prix = c.Single(nullable: false),
                        Libelle = c.String(),
                        TypeAbo = c.String(),
                        Description = c.String(),
                        Dure = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdAbo);
            
            CreateTable(
                "dbo.Paniers",
                c => new
                    {
                        pid = c.Int(nullable: false, identity: true),
                        prixtot = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.pid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Meubles", "Panier_pid", "dbo.Paniers");
            DropForeignKey("dbo.Abonnements", "Client_IdClient", "dbo.Clients");
            DropForeignKey("dbo.Clients", "TyAbo_IdAbo", "dbo.TyAboes");
            DropForeignKey("dbo.Abonnements", "TyAbo_IdAbo", "dbo.TyAboes");
            DropForeignKey("dbo.Meubles", "IdClient", "dbo.Clients");
            DropIndex("dbo.Meubles", new[] { "Panier_pid" });
            DropIndex("dbo.Meubles", new[] { "IdClient" });
            DropIndex("dbo.Clients", new[] { "TyAbo_IdAbo" });
            DropIndex("dbo.Abonnements", new[] { "Client_IdClient" });
            DropIndex("dbo.Abonnements", new[] { "TyAbo_IdAbo" });
            DropTable("dbo.Paniers");
            DropTable("dbo.TyAboes");
            DropTable("dbo.Meubles");
            DropTable("dbo.Clients");
            DropTable("dbo.Abonnements");
        }
    }
}
