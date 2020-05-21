using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReconciliationApp.EntityFrameworkCore.Migrations
{
    public partial class Initial_Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IncomeOrExpenseTypes",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    ModificationTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DeviceInfo = table.Column<string>(nullable: true),
                    IpAddress = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(maxLength: 128, nullable: true),
                    IsSystem = table.Column<bool>(nullable: false),
                    SystemName = table.Column<string>(maxLength: 128, nullable: true),
                    Flag = table.Column<int>(nullable: false),
                    IncomeOrExpenseTypeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeOrExpenseTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncomeOrExpenseTypes_IncomeOrExpenseTypes_IncomeOrExpenseTypeId",
                        column: x => x.IncomeOrExpenseTypeId,
                        principalTable: "IncomeOrExpenseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IncomeOrExpenses",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    ModificationTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DeviceInfo = table.Column<string>(nullable: true),
                    IpAddress = table.Column<string>(nullable: true),
                    IncomeOrExpenseTypeId = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeOrExpenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncomeOrExpenses_IncomeOrExpenseTypes_IncomeOrExpenseTypeId",
                        column: x => x.IncomeOrExpenseTypeId,
                        principalTable: "IncomeOrExpenseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reconciliations",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    ModificationTime = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    DeviceInfo = table.Column<string>(nullable: true),
                    IpAddress = table.Column<string>(nullable: true),
                    IncomeOrExpenseTypeId = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false),
                    Month = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reconciliations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reconciliations_IncomeOrExpenseTypes_IncomeOrExpenseTypeId",
                        column: x => x.IncomeOrExpenseTypeId,
                        principalTable: "IncomeOrExpenseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IncomeOrExpenses_IncomeOrExpenseTypeId",
                table: "IncomeOrExpenses",
                column: "IncomeOrExpenseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_IncomeOrExpenseTypes_IncomeOrExpenseTypeId",
                table: "IncomeOrExpenseTypes",
                column: "IncomeOrExpenseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reconciliations_IncomeOrExpenseTypeId",
                table: "Reconciliations",
                column: "IncomeOrExpenseTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IncomeOrExpenses");

            migrationBuilder.DropTable(
                name: "Reconciliations");

            migrationBuilder.DropTable(
                name: "IncomeOrExpenseTypes");
        }
    }
}
