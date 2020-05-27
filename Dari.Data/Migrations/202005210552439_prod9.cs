namespace Dari.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prod9 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Meubles", name: "CategoryId", newName: "CategoryMeubId");
            RenameIndex(table: "dbo.Meubles", name: "IX_CategoryId", newName: "IX_CategoryMeubId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Meubles", name: "IX_CategoryMeubId", newName: "IX_CategoryId");
            RenameColumn(table: "dbo.Meubles", name: "CategoryMeubId", newName: "CategoryId");
        }
    }
}
