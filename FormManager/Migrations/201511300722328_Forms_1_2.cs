namespace FormManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Forms_1_2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "Color", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.Questions", "Color");
        }
    }
}
