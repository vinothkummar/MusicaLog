namespace Musicalog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_tablealbum : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Album",
                c => new
                    {
                        AlbumId = c.Int(nullable: false, identity: true),
                        AlbumName = c.String(),
                        Artist = c.String(),
                        Type = c.String(),
                        Stock = c.Int(nullable: false),
                        EditAlbumButton = c.Boolean(nullable: false),
                        RemoveCatalogButton = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AlbumId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Album");
        }
    }
}
