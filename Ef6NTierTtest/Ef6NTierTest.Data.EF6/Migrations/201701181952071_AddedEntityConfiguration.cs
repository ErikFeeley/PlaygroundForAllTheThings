namespace Ef6NTierTest.Data.EF6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEntityConfiguration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ValueEntities", "Blurb", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ValueEntities", "Blurb", c => c.String());
        }
    }
}
