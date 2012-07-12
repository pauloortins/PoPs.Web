namespace PoPs.Repository.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class PopPublishDateRename : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Pops", "PublishDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("Pops", "publishDate", c => c.DateTime(nullable: false));
        }
    }
}
