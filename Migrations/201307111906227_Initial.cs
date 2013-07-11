namespace GeoCodeClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AddressComponents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LongName = c.String(),
                        ShortName = c.String(),
                        GeoCode_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GeoCodes", t => t.GeoCode_Id)
                .Index(t => t.GeoCode_Id);
            
            CreateTable(
                "dbo.GeoCodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FormatedAddress = c.String(),
                        PartialMatch = c.Boolean(nullable: false),
                        Geometry_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Geometries", t => t.Geometry_Id)
                .Index(t => t.Geometry_Id);
            
            CreateTable(
                "dbo.Geometries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LocationType = c.String(),
                        Location_Id = c.Int(),
                        ViewPort_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.Location_Id)
                .ForeignKey("dbo.ViewPorts", t => t.ViewPort_Id)
                .Index(t => t.Location_Id)
                .Index(t => t.ViewPort_Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ViewPorts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NorthEast_Id = c.Int(),
                        SouthWest_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.NorthEast_Id)
                .ForeignKey("dbo.Locations", t => t.SouthWest_Id)
                .Index(t => t.NorthEast_Id)
                .Index(t => t.SouthWest_Id);
            
            CreateTable(
                "dbo.GeoCodeLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.ViewPorts", new[] { "SouthWest_Id" });
            DropIndex("dbo.ViewPorts", new[] { "NorthEast_Id" });
            DropIndex("dbo.Geometries", new[] { "ViewPort_Id" });
            DropIndex("dbo.Geometries", new[] { "Location_Id" });
            DropIndex("dbo.GeoCodes", new[] { "Geometry_Id" });
            DropIndex("dbo.AddressComponents", new[] { "GeoCode_Id" });
            DropForeignKey("dbo.ViewPorts", "SouthWest_Id", "dbo.Locations");
            DropForeignKey("dbo.ViewPorts", "NorthEast_Id", "dbo.Locations");
            DropForeignKey("dbo.Geometries", "ViewPort_Id", "dbo.ViewPorts");
            DropForeignKey("dbo.Geometries", "Location_Id", "dbo.Locations");
            DropForeignKey("dbo.GeoCodes", "Geometry_Id", "dbo.Geometries");
            DropForeignKey("dbo.AddressComponents", "GeoCode_Id", "dbo.GeoCodes");
            DropTable("dbo.GeoCodeLists");
            DropTable("dbo.ViewPorts");
            DropTable("dbo.Locations");
            DropTable("dbo.Geometries");
            DropTable("dbo.GeoCodes");
            DropTable("dbo.AddressComponents");
        }
    }
}
