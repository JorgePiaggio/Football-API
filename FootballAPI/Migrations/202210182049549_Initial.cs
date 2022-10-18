namespace FootballAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Areas",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        Code = c.String(),
                        Flag = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Competitions",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        Code = c.String(),
                        Type = c.String(),
                        Emblem = c.String(),
                        Plan = c.String(),
                        SeasonId = c.Int(),
                        AreaId = c.Int(nullable: false),
                        NumberOfAvailableSeasons = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Areas", t => t.AreaId, cascadeDelete: true)
                .ForeignKey("dbo.Seasons", t => t.SeasonId)
                .Index(t => t.SeasonId)
                .Index(t => t.AreaId);
            
            CreateTable(
                "dbo.Seasons",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        CurrentMatchDay = c.Int(nullable: false),
                        Winner_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.Winner_Id)
                .Index(t => t.Winner_Id);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        ShortName = c.String(),
                        Tla = c.String(),
                        Crest = c.String(),
                        Address = c.String(),
                        Website = c.String(),
                        Founded = c.Int(),
                        ClubColours = c.String(),
                        Venue = c.String(),
                        MarketValue = c.Int(nullable: false),
                        AreaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Areas", t => t.AreaId, cascadeDelete: true)
                .Index(t => t.AreaId);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Position = c.String(),
                        ShirtNumber = c.Short(nullable: false),
                        TeamName = c.String(),
                        TeamId = c.Int(nullable: false),
                        Name = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Nationality = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.TeamId, cascadeDelete: true)
                .Index(t => t.TeamId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Players", "TeamId", "dbo.Teams");
            DropForeignKey("dbo.Competitions", "SeasonId", "dbo.Seasons");
            DropForeignKey("dbo.Seasons", "Winner_Id", "dbo.Teams");
            DropForeignKey("dbo.Teams", "AreaId", "dbo.Areas");
            DropForeignKey("dbo.Competitions", "AreaId", "dbo.Areas");
            DropIndex("dbo.Players", new[] { "TeamId" });
            DropIndex("dbo.Teams", new[] { "AreaId" });
            DropIndex("dbo.Seasons", new[] { "Winner_Id" });
            DropIndex("dbo.Competitions", new[] { "AreaId" });
            DropIndex("dbo.Competitions", new[] { "SeasonId" });
            DropTable("dbo.Players");
            DropTable("dbo.Teams");
            DropTable("dbo.Seasons");
            DropTable("dbo.Competitions");
            DropTable("dbo.Areas");
        }
    }
}
