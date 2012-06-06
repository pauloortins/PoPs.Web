namespace PoPs.Repository.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class MigrationZero : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        IsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Pops",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        URL = c.String(),
                        publishDate = c.DateTime(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "Evaluations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EvaluationDate = c.DateTime(nullable: false),
                        PositiveEvaluation = c.Boolean(nullable: false),
                        User_Id = c.Int(),
                        Pop_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Users", t => t.User_Id)
                .ForeignKey("Pops", t => t.Pop_Id)
                .Index(t => t.User_Id)
                .Index(t => t.Pop_Id);
            
            CreateTable(
                "Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "TagPops",
                c => new
                    {
                        Tag_Id = c.Int(nullable: false),
                        Pop_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.Pop_Id })
                .ForeignKey("Tags", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("Pops", t => t.Pop_Id, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.Pop_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("TagPops", new[] { "Pop_Id" });
            DropIndex("TagPops", new[] { "Tag_Id" });
            DropIndex("Evaluations", new[] { "Pop_Id" });
            DropIndex("Evaluations", new[] { "User_Id" });
            DropIndex("Pops", new[] { "User_Id" });
            DropForeignKey("TagPops", "Pop_Id", "Pops");
            DropForeignKey("TagPops", "Tag_Id", "Tags");
            DropForeignKey("Evaluations", "Pop_Id", "Pops");
            DropForeignKey("Evaluations", "User_Id", "Users");
            DropForeignKey("Pops", "User_Id", "Users");
            DropTable("TagPops");
            DropTable("Tags");
            DropTable("Evaluations");
            DropTable("Pops");
            DropTable("Users");
        }
    }
}
