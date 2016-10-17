namespace FormManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Form_1_5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Forms", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Forms", "IsActive");
        }
    }
}
