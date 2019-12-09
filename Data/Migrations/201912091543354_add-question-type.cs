namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addquestiontype : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Question", "questionType", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Question", "questionType");
        }
    }
}
