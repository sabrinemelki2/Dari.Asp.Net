namespace Dari.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prod7 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Meubles", "Category");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Meubles", "Category", c => c.String());
        }
    }
}
