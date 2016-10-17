namespace FormManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Form_1_4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "Script", c => c.String());
            DropColumn("dbo.Forms", "Script");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Forms", "Script", c => c.String());
            DropColumn("dbo.Questions", "Script");
        }
    }
}
