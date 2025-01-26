using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arabytak.Repository.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "adplan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    planType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adplan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "deals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone1 = table.Column<int>(type: "int", nullable: true),
                    Phone2 = table.Column<int>(type: "int", nullable: true),
                    Phone3 = table.Column<int>(type: "int", nullable: true),
                    WhatsApp1 = table.Column<int>(type: "int", nullable: true),
                    Facebook = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instagram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Branch1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Branch2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Branch3 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "insuranceCompanys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_insuranceCompanys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "maintenanceCenter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AvailableServices = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_maintenanceCenter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "models",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_models", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "rescueCompanys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone1 = table.Column<int>(type: "int", nullable: false),
                    Phone2 = table.Column<int>(type: "int", nullable: true),
                    Phone3 = table.Column<int>(type: "int", nullable: true),
                    Service1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Service2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Service3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Service4 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rescueCompanys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "specNewCars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gears = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    FuelEfficiency = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TopSpeed = table.Column<int>(type: "int", nullable: false),
                    OriginCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssemblyCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Acceleration = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Length = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Width = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Height = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GroundClearance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Wheelbase = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TrunkSize = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Seats = table.Column<int>(type: "int", nullable: false),
                    Drivetrain = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fuel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HorsePower = table.Column<int>(type: "int", nullable: false),
                    Transmission = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_specNewCars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "specUsedCars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FuelType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Transmission = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManufacturingYear = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mileage = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_specUsedCars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    condition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DealershipId = table.Column<int>(type: "int", nullable: true),
                    BrandId = table.Column<int>(type: "int", nullable: true),
                    ModelId = table.Column<int>(type: "int", nullable: true),
                    SpecNewCarId = table.Column<int>(type: "int", nullable: true),
                    SpecUsedCarId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cars_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_cars_deals_DealershipId",
                        column: x => x.DealershipId,
                        principalTable: "deals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_cars_models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "models",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_cars_specNewCars_SpecNewCarId",
                        column: x => x.SpecNewCarId,
                        principalTable: "specNewCars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cars_specUsedCars_SpecUsedCarId",
                        column: x => x.SpecUsedCarId,
                        principalTable: "specUsedCars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "advertisements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    StartCreateAdvertisement = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SellerEmail = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ContactInfo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdPlanId = table.Column<int>(type: "int", nullable: true),
                    CarId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_advertisements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_advertisements_adplan_AdPlanId",
                        column: x => x.AdPlanId,
                        principalTable: "adplan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_advertisements_cars_CarId",
                        column: x => x.CarId,
                        principalTable: "cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "carsPictureUrls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carsPictureUrls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_carsPictureUrls_cars_CarId",
                        column: x => x.CarId,
                        principalTable: "cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_advertisements_AdPlanId",
                table: "advertisements",
                column: "AdPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_advertisements_CarId",
                table: "advertisements",
                column: "CarId",
                unique: true,
                filter: "[CarId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_cars_BrandId",
                table: "cars",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_cars_DealershipId",
                table: "cars",
                column: "DealershipId");

            migrationBuilder.CreateIndex(
                name: "IX_cars_ModelId",
                table: "cars",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_cars_SpecNewCarId",
                table: "cars",
                column: "SpecNewCarId",
                unique: true,
                filter: "[SpecNewCarId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_cars_SpecUsedCarId",
                table: "cars",
                column: "SpecUsedCarId",
                unique: true,
                filter: "[SpecUsedCarId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_carsPictureUrls_CarId",
                table: "carsPictureUrls",
                column: "CarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "advertisements");

            migrationBuilder.DropTable(
                name: "carsPictureUrls");

            migrationBuilder.DropTable(
                name: "insuranceCompanys");

            migrationBuilder.DropTable(
                name: "maintenanceCenter");

            migrationBuilder.DropTable(
                name: "rescueCompanys");

            migrationBuilder.DropTable(
                name: "adplan");

            migrationBuilder.DropTable(
                name: "cars");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "deals");

            migrationBuilder.DropTable(
                name: "models");

            migrationBuilder.DropTable(
                name: "specNewCars");

            migrationBuilder.DropTable(
                name: "specUsedCars");
        }
    }
}
