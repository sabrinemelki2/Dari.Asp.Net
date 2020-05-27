namespace Dari.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prod11 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Meubles", "Titre", c => c.String(nullable: false));
            AlterColumn("dbo.Meubles", "Image", c => c.String(nullable: false));
            AlterColumn("dbo.Meubles", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Meubles", "Description", c => c.String());
            AlterColumn("dbo.Meubles", "Image", c => c.String());
            AlterColumn("dbo.Meubles", "Titre", c => c.String());
        }
    }
}
