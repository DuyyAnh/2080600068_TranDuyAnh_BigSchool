namespace _2080600068_TranDuyAnh_BigSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFollowingsTable : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Followings", name: "Follower_Id", newName: "FollowerId");
            RenameIndex(table: "dbo.Followings", name: "IX_Follower_Id", newName: "IX_FollowerId");
            DropPrimaryKey("dbo.Followings");
            AddPrimaryKey("dbo.Followings", new[] { "FollowerId", "FolloweeId" });
            DropColumn("dbo.Followings", "FollowingId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Followings", "FollowingId", c => c.String(nullable: false, maxLength: 128));
            DropPrimaryKey("dbo.Followings");
            AddPrimaryKey("dbo.Followings", new[] { "FollowingId", "FolloweeId" });
            RenameIndex(table: "dbo.Followings", name: "IX_FollowerId", newName: "IX_Follower_Id");
            RenameColumn(table: "dbo.Followings", name: "FollowerId", newName: "Follower_Id");
        }
    }
}
