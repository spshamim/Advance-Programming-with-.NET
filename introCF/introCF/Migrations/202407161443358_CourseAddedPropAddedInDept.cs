namespace introCF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CourseAddedPropAddedInDept : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreditHr = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Departments", "DeptHeadName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Departments", "DeptHeadName");
            DropTable("dbo.Courses");
        }
    }
}
