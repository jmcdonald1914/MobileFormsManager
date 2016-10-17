namespace FormManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Form_1_3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Forms", "Script", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Forms", "Script");
        }
    }
}
