namespace ITI.WebApiTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        dept_Id = c.Int(nullable: false, identity: true),
                        dept_Name = c.String(nullable: false),
                        country = c.String(),
                        city = c.String(),
                        emp_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.dept_Id)
                .ForeignKey("dbo.Employees", t => t.emp_Id, cascadeDelete: true)
                .Index(t => t.emp_Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        emp_Id = c.Int(nullable: false, identity: true),
                        emp_Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.emp_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Departments", "emp_Id", "dbo.Employees");
            DropIndex("dbo.Departments", new[] { "emp_Id" });
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
        }
    }
}
