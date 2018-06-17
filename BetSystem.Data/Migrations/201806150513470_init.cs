namespace BetSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventName = c.String(),
                        OddsForFirstTeam = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OddsForDraw = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OddsForSecondTeam = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EventStartDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Events");
        }
    }
}
