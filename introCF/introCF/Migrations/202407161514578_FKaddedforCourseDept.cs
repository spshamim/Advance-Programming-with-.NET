namespace introCF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FKaddedforCourseDept : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "DeptID", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "DeptID", c => c.Int(nullable: false));
            CreateIndex("dbo.Courses", "DeptID");
            AddForeignKey("dbo.Courses", "DeptID", "dbo.Departments", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "DeptID", "dbo.Departments");
            DropIndex("dbo.Courses", new[] { "DeptID" });
            DropColumn("dbo.Students", "DeptID");
            DropColumn("dbo.Courses", "DeptID");
        }
    }
}
