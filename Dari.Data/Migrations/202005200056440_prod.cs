namespace Dari.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prod : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Annonces",
                c => new
                    {
                        AnnonceId = c.Int(nullable: false, identity: true),
                        TypeAn = c.Int(nullable: false),
                        Description = c.String(),
                        address = c.String(),
                        surface = c.Single(nullable: false),
                        chambres = c.Int(nullable: false),
                        images = c.String(),
                    })
                .PrimaryKey(t => t.AnnonceId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Annonces");
        }
    }
}
