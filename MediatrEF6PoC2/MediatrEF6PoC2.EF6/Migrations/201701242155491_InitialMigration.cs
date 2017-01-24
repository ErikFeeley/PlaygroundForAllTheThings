namespace MediatrEF6PoC2.EF6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MyValueEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Blurb = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MyValueEntities");
        }
    }
}
