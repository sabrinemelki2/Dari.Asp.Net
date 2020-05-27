namespace Dari.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prod3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategorieMeubs",
                c => new
                    {
                        CategoryMeubId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CategoryMeubId);
            
            AddColumn("dbo.Meubles", "CategorieMeub_CategoryMeubId", c => c.Int());
            CreateIndex("dbo.Meubles", "CategorieMeub_CategoryMeubId");
            AddForeignKey("dbo.Meubles", "CategorieMeub_CategoryMeubId", "dbo.CategorieMeubs", "CategoryMeubId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Meubles", "CategorieMeub_CategoryMeubId", "dbo.CategorieMeubs");
            DropIndex("dbo.Meubles", new[] { "CategorieMeub_CategoryMeubId" });
            DropColumn("dbo.Meubles", "CategorieMeub_CategoryMeubId");
            DropTable("dbo.CategorieMeubs");
        }
    }
}
