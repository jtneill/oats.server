namespace oats.server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Deals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DealTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DueDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        ResponsiblePerson_Id = c.Int(),
                        Deal_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.ResponsiblePerson_Id)
                .ForeignKey("dbo.Deals", t => t.Deal_Id)
                .Index(t => t.ResponsiblePerson_Id)
                .Index(t => t.Deal_Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Role = c.Int(nullable: false),
                        Agency = c.Int(nullable: false),
                        Deal_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Deals", t => t.Deal_Id)
                .Index(t => t.Deal_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "Deal_Id", "dbo.Deals");
            DropForeignKey("dbo.DealTasks", "Deal_Id", "dbo.Deals");
            DropForeignKey("dbo.DealTasks", "ResponsiblePerson_Id", "dbo.People");
            DropIndex("dbo.People", new[] { "Deal_Id" });
            DropIndex("dbo.DealTasks", new[] { "Deal_Id" });
            DropIndex("dbo.DealTasks", new[] { "ResponsiblePerson_Id" });
            DropTable("dbo.People");
            DropTable("dbo.DealTasks");
            DropTable("dbo.Deals");
        }
    }
}
