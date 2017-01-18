namespace Ef6NTierTest.Data.EF6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ValueEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Blurb = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ValueEntities");
        }
    }
}
