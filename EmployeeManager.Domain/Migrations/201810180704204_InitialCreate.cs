namespace EmployeeManager.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        RecordGuid = c.Guid(nullable: false),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        HireDate = c.DateTime(nullable: false),
                        Department = c.String(),
                        JobTitle = c.String(),
                        PayRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SalaryType = c.String(name: "Salary Type"),
                        EmployeeId = c.String(),
                        AvailableHours = c.String(),
                    })
                .PrimaryKey(t => t.RecordGuid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employees");
        }
    }
}
