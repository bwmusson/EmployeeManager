namespace EmployeeManager.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Week13Update : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Errors");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Errors",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ErrorDateTime = c.DateTime(nullable: false),
                        ErrorMessage = c.String(),
                        StackTrace = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
