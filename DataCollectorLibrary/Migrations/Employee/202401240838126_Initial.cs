namespace DataCollectorLibrary.Migrations.Employee
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 2147483647),
                        LastName = c.String(maxLength: 2147483647),
                        Gender = c.Int(nullable: false),
                        DOB = c.DateTime(nullable: false),
                        Email = c.String(nullable: false, maxLength: 2147483647),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 2147483647),
                        CreatedDate = c.DateTime(nullable: false),
                        LastModifiedBy = c.String(maxLength: 2147483647),
                        LastModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employee");
        }
    }
}
