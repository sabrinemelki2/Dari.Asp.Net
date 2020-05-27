namespace Dari.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prod4 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Meubles", name: "CategorieMeub_CategoryMeubId", newName: "CategoryId");
            RenameIndex(table: "dbo.Meubles", name: "IX_CategorieMeub_CategoryMeubId", newName: "IX_CategoryId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Meubles", name: "IX_CategoryId", newName: "IX_CategorieMeub_CategoryMeubId");
            RenameColumn(table: "dbo.Meubles", name: "CategoryId", newName: "CategorieMeub_CategoryMeubId");
        }
    }
}
