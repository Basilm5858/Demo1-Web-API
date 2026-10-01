using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DriverLicenseNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Position = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Make = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    Mileage = table.Column<int>(type: "int", nullable: false),
                    VIN = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false),
                    FuelType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Transmission = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Available"),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerProfiles_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Comfortable passenger cars", "Sedan" },
                    { 2, "Sport utility vehicles", "SUV" },
                    { 3, "Compact practical cars", "Hatchback" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "DriverLicenseNumber", "Email", "FullName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "DL100001", "ahmed.hassan@example.com", "Ahmed Hassan", "01010000001" },
                    { 2, "DL100002", "mona.adel@example.com", "Mona Adel", "01010000002" },
                    { 3, "DL100003", "omar.khaled@example.com", "Omar Khaled", "01010000003" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "FullName", "HireDate", "Phone", "Position" },
                values: new object[,]
                {
                    { 1, "mostafa.nabil@autodrive.com", "Mostafa Nabil", new DateTime(2032, 4, 2, 13, 6, 50, 866, DateTimeKind.Local).AddTicks(6359), "01020000001", "Sales Manager" },
                    { 2, "aya.emad@autodrive.com", "Aya Emad", new DateTime(2032, 4, 2, 13, 6, 50, 866, DateTimeKind.Local).AddTicks(6528), "01020000002", "Sales Consultant" },
                    { 3, "hassan.ali@autodrive.com", "Hassan Ali", new DateTime(2032, 4, 2, 13, 6, 50, 866, DateTimeKind.Local).AddTicks(6581), "01020000003", "Sales Consultant" }
                });

            migrationBuilder.InsertData(
                table: "CustomerProfiles",
                columns: new[] { "Id", "Address", "City", "CustomerId", "DateOfBirth", "Nationality" },
                values: new object[,]
                {
                    { 1, "12 Nile St.", "Cairo", 1, new DateTime(2032, 2, 29, 13, 6, 50, 866, DateTimeKind.Local).AddTicks(6135), "Egyptian" },
                    { 2, "25 Tahrir St.", "Giza", 2, new DateTime(2032, 2, 16, 13, 6, 50, 866, DateTimeKind.Local).AddTicks(6261), "Egyptian" },
                    { 3, "12 Nile St.", "Cairo", 3, new DateTime(2032, 2, 24, 13, 6, 50, 866, DateTimeKind.Local).AddTicks(6309), "Egyptian" }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "CategoryId", "Color", "FuelType", "Make", "Mileage", "Model", "Price", "Status", "Transmission", "VIN", "Year" },
                values: new object[,]
                {
                    { 1, 1, "White", "Petrol", "Toyota", 12000, "Corolla", 650000m, "Available", "Automatic", "VIN00000000000001", 2024 },
                    { 2, 2, "Black", "Petrol", "Hyundai", 18000, "Elantra", 590000m, "Available", "Automatic", "VIN00000000000002", 2023 },
                    { 3, 3, "Gray", "Petrol", "Kia", 9000, "Sportage", 980000m, "Available", "Automatic", "VIN00000000000003", 2024 }
                });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "Id", "CustomerId", "EmployeeId", "Notes", "PaymentMethod", "SaleDate", "SalePrice", "VehicleId" },
                values: new object[,]
                {
                    { 1, 1, 1, "Completed sale.", "Bank Transfer", new DateTime(2032, 3, 26, 13, 6, 50, 866, DateTimeKind.Local).AddTicks(6632), 1750000m, 1 },
                    { 2, 2, 2, "Completed sale.", "Bank Transfer", new DateTime(2032, 3, 19, 13, 6, 50, 866, DateTimeKind.Local).AddTicks(6685), 1850000m, 2 },
                    { 3, 3, 3, "Completed sale.", "Cash", new DateTime(2032, 4, 4, 13, 6, 50, 866, DateTimeKind.Local).AddTicks(6732), 510000m, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerProfiles_CustomerId",
                table: "CustomerProfiles",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_DriverLicenseNumber",
                table: "Customers",
                column: "DriverLicenseNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Email",
                table: "Customers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Email",
                table: "Employees",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sales_CustomerId",
                table: "Sales",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_EmployeeId",
                table: "Sales",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_VehicleId",
                table: "Sales",
                column: "VehicleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_CategoryId",
                table: "Vehicles",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VIN",
                table: "Vehicles",
                column: "VIN",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerProfiles");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
