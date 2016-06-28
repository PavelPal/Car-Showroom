using System.Data.Entity.Migrations;

namespace CarShowroom.Migrations
{
    public partial class DataMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BodyTypes",
                c => new
                {
                    Id = c.Int(false, true),
                    Body = c.String(false)
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Cars",
                c => new
                {
                    Id = c.Int(false, true),
                    Name = c.String(false),
                    Cost = c.Decimal(false, 18, 2),
                    Discount = c.Int(false),
                    Count = c.Int(false),
                    DateCreated = c.DateTime(false),
                    DateAdded = c.DateTime(false),
                    Width = c.Double(false),
                    Height = c.Double(false),
                    Length = c.Double(false),
                    Wheelbase = c.Double(false),
                    Clearance = c.Double(false),
                    TrunkVolume = c.Double(false),
                    FuelTankVolume = c.Double(false),
                    Weight = c.Double(false),
                    DoorCount = c.Int(false),
                    EngineVolume = c.Double(false),
                    CylindersCount = c.Int(false),
                    Supercharger = c.Boolean(false),
                    EnginePower = c.Int(false),
                    MaxSpeed = c.Int(false),
                    TopGear = c.Int(false),
                    Acceleration = c.Double(false),
                    FuelConsumption = c.Double(false),
                    SeatFinish = c.String(false),
                    ConditioningSystem = c.Boolean(false),
                    AdjustableSteeringColumn = c.Boolean(false),
                    Heating = c.Boolean(false),
                    Navigation = c.Boolean(false),
                    Signaling = c.Boolean(false),
                    CruiseControl = c.Boolean(false),
                    BodyTypeId = c.Int(false),
                    EngineId = c.Int(false),
                    TransmissionId = c.Int(false),
                    DriveUnitId = c.Int(false),
                    CarTypeId = c.Int(false),
                    BrandId = c.Int(false),
                    HeadlightId = c.Int(false)
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BodyTypes", t => t.BodyTypeId, true)
                .ForeignKey("dbo.Brands", t => t.BrandId, true)
                .ForeignKey("dbo.CarTypes", t => t.CarTypeId, true)
                .ForeignKey("dbo.DriveUnits", t => t.DriveUnitId, true)
                .ForeignKey("dbo.Engines", t => t.EngineId, true)
                .ForeignKey("dbo.Headlights", t => t.HeadlightId, true)
                .ForeignKey("dbo.Transmissions", t => t.TransmissionId, true)
                .Index(t => t.BodyTypeId)
                .Index(t => t.EngineId)
                .Index(t => t.TransmissionId)
                .Index(t => t.DriveUnitId)
                .Index(t => t.CarTypeId)
                .Index(t => t.BrandId)
                .Index(t => t.HeadlightId);

            CreateTable(
                "dbo.Brands",
                c => new
                {
                    Id = c.Int(false, true),
                    Body = c.String(false),
                    Image = c.Binary(),
                    ImageType = c.String(),
                    Country = c.String(false)
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.CarImages",
                c => new
                {
                    Id = c.Int(false, true),
                    Image = c.Binary(),
                    ImageType = c.String(),
                    CarId = c.Int(false)
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.CarId, true)
                .Index(t => t.CarId);

            CreateTable(
                "dbo.CarTypes",
                c => new
                {
                    Id = c.Int(false, true),
                    Body = c.String(false)
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.DriveUnits",
                c => new
                {
                    Id = c.Int(false, true),
                    Body = c.String(false)
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Engines",
                c => new
                {
                    Id = c.Int(false, true),
                    Body = c.String(false)
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Headlights",
                c => new
                {
                    Id = c.Int(false, true),
                    Body = c.String(false)
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Reviews",
                c => new
                {
                    Id = c.Int(false, true),
                    Body = c.String(),
                    Date = c.DateTime(false),
                    ApplicationUserId = c.String(maxLength: 128),
                    IsAccept = c.Boolean(false),
                    CarId = c.Int(false)
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.Cars", t => t.CarId, true)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.CarId);

            CreateTable(
                "dbo.AspNetUsers",
                c => new
                {
                    Id = c.String(false, 128),
                    Email = c.String(maxLength: 256),
                    EmailConfirmed = c.Boolean(false),
                    PasswordHash = c.String(),
                    SecurityStamp = c.String(),
                    PhoneNumber = c.String(),
                    PhoneNumberConfirmed = c.Boolean(false),
                    TwoFactorEnabled = c.Boolean(false),
                    LockoutEndDateUtc = c.DateTime(),
                    LockoutEnabled = c.Boolean(false),
                    AccessFailedCount = c.Int(false),
                    UserName = c.String(false, 256)
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");

            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                {
                    Id = c.Int(false, true),
                    UserId = c.String(false, 128),
                    ClaimType = c.String(),
                    ClaimValue = c.String()
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                {
                    LoginProvider = c.String(false, 128),
                    ProviderKey = c.String(false, 128),
                    UserId = c.String(false, 128)
                })
                .PrimaryKey(t => new {t.LoginProvider, t.ProviderKey, t.UserId})
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.Orders",
                c => new
                {
                    Id = c.Int(false, true),
                    Cost = c.Decimal(false, 18, 2),
                    ApplicationUserId = c.Int(false),
                    CarId = c.Int(false),
                    Date = c.DateTime(false),
                    DateDelivery = c.DateTime(false),
                    InProgress = c.Boolean(false),
                    IsComplete = c.Boolean(false),
                    ApplicationUser_Id = c.String(maxLength: 128)
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Cars", t => t.CarId, true)
                .Index(t => t.CarId)
                .Index(t => t.ApplicationUser_Id);

            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                {
                    UserId = c.String(false, 128),
                    RoleId = c.String(false, 128)
                })
                .PrimaryKey(t => new {t.UserId, t.RoleId})
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);

            CreateTable(
                "dbo.Transmissions",
                c => new
                {
                    Id = c.Int(false, true),
                    Body = c.String(false)
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.AspNetRoles",
                c => new
                {
                    Id = c.String(false, 128),
                    Name = c.String(false, 256)
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
        }

        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Cars", "TransmissionId", "dbo.Transmissions");
            DropForeignKey("dbo.Reviews", "CarId", "dbo.Cars");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Reviews", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Orders", "CarId", "dbo.Cars");
            DropForeignKey("dbo.Orders", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Cars", "HeadlightId", "dbo.Headlights");
            DropForeignKey("dbo.Cars", "EngineId", "dbo.Engines");
            DropForeignKey("dbo.Cars", "DriveUnitId", "dbo.DriveUnits");
            DropForeignKey("dbo.Cars", "CarTypeId", "dbo.CarTypes");
            DropForeignKey("dbo.CarImages", "CarId", "dbo.Cars");
            DropForeignKey("dbo.Cars", "BrandId", "dbo.Brands");
            DropForeignKey("dbo.Cars", "BodyTypeId", "dbo.BodyTypes");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] {"RoleId"});
            DropIndex("dbo.AspNetUserRoles", new[] {"UserId"});
            DropIndex("dbo.Orders", new[] {"ApplicationUser_Id"});
            DropIndex("dbo.Orders", new[] {"CarId"});
            DropIndex("dbo.AspNetUserLogins", new[] {"UserId"});
            DropIndex("dbo.AspNetUserClaims", new[] {"UserId"});
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Reviews", new[] {"CarId"});
            DropIndex("dbo.Reviews", new[] {"ApplicationUserId"});
            DropIndex("dbo.CarImages", new[] {"CarId"});
            DropIndex("dbo.Cars", new[] {"HeadlightId"});
            DropIndex("dbo.Cars", new[] {"BrandId"});
            DropIndex("dbo.Cars", new[] {"CarTypeId"});
            DropIndex("dbo.Cars", new[] {"DriveUnitId"});
            DropIndex("dbo.Cars", new[] {"TransmissionId"});
            DropIndex("dbo.Cars", new[] {"EngineId"});
            DropIndex("dbo.Cars", new[] {"BodyTypeId"});
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Transmissions");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Orders");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Reviews");
            DropTable("dbo.Headlights");
            DropTable("dbo.Engines");
            DropTable("dbo.DriveUnits");
            DropTable("dbo.CarTypes");
            DropTable("dbo.CarImages");
            DropTable("dbo.Brands");
            DropTable("dbo.Cars");
            DropTable("dbo.BodyTypes");
        }
    }
}