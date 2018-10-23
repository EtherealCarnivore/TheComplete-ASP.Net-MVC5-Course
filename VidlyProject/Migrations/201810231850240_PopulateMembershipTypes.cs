namespace VidlyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "SignUp", c => c.Short(nullable: false));
            DropColumn("dbo.MembershipTypes", "SignUpFree");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MembershipTypes", "SignUpFree", c => c.Short(nullable: false));
            DropColumn("dbo.MembershipTypes", "SignUp");
        }
    }
}
