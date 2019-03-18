namespace JXDevPlanner.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Why : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlanItem",
                c => new
                    {
                        PlanItemID = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Details = c.String(nullable: false),
                        ProjectID = c.Guid(nullable: false),
                        CreatorID = c.Guid(nullable: false),
                        LastModifiedBy = c.Guid(nullable: false),
                        CreatedUTC = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUTC = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.PlanItemID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PlanItem");
        }
    }
}
