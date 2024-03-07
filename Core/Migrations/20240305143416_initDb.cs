using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersionalExpenditureManagement.Migrations
{
    public partial class initDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MonthOfSpendings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YearOfMonth = table.Column<int>(type: "int", nullable: false),
                    MonthName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthOfSpendings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpendingCategorys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpendingCategorys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AmountPerCategorys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmountExpected = table.Column<double>(type: "float", nullable: false),
                    SpendingCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmountPerCategorys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AmountPerCategorys_SpendingCategorys_SpendingCategoryId",
                        column: x => x.SpendingCategoryId,
                        principalTable: "SpendingCategorys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AmountPerMonthDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalRevenue = table.Column<double>(type: "float", nullable: false),
                    TotalSpending = table.Column<double>(type: "float", nullable: false),
                    TotalAmountRemaining = table.Column<double>(type: "float", nullable: false),
                    MonthOfSpendingId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmountPerMonthDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AmountPerMonthDetails_MonthOfSpendings_MonthOfSpendingId",
                        column: x => x.MonthOfSpendingId,
                        principalTable: "MonthOfSpendings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AmountPerMonthDetails_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BankAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentAmount = table.Column<double>(type: "float", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankAccounts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CurrentActualCashAmounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentCashAmount = table.Column<double>(type: "float", nullable: false),
                    MonthOfSpendingId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentActualCashAmounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrentActualCashAmounts_MonthOfSpendings_MonthOfSpendingId",
                        column: x => x.MonthOfSpendingId,
                        principalTable: "MonthOfSpendings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CurrentActualCashAmounts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpendingActualPerDays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalSpedingAmount = table.Column<double>(type: "float", nullable: false),
                    MonthOfSpendingId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpendingActualPerDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpendingActualPerDays_MonthOfSpendings_MonthOfSpendingId",
                        column: x => x.MonthOfSpendingId,
                        principalTable: "MonthOfSpendings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpendingActualPerDays_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpendingByDays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfSpending = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AmountSpending = table.Column<double>(type: "float", nullable: false),
                    MonthOfSpendingId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SpendingCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpendingByDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpendingByDays_MonthOfSpendings_MonthOfSpendingId",
                        column: x => x.MonthOfSpendingId,
                        principalTable: "MonthOfSpendings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpendingByDays_SpendingCategorys_SpendingCategoryId",
                        column: x => x.SpendingCategoryId,
                        principalTable: "SpendingCategorys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpendingByDays_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TotalAmountCategoryPerMonths",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalAmount = table.Column<double>(type: "float", nullable: false),
                    SpendingCategoryId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MonthOfSpendingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TotalAmountCategoryPerMonths", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TotalAmountCategoryPerMonths_MonthOfSpendings_MonthOfSpendingId",
                        column: x => x.MonthOfSpendingId,
                        principalTable: "MonthOfSpendings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TotalAmountCategoryPerMonths_SpendingCategorys_SpendingCategoryId",
                        column: x => x.SpendingCategoryId,
                        principalTable: "SpendingCategorys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TotalAmountCategoryPerMonths_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSpendingPerMonths",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MonthOfSpendingId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SpendingCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSpendingPerMonths", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSpendingPerMonths_MonthOfSpendings_MonthOfSpendingId",
                        column: x => x.MonthOfSpendingId,
                        principalTable: "MonthOfSpendings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSpendingPerMonths_SpendingCategorys_SpendingCategoryId",
                        column: x => x.SpendingCategoryId,
                        principalTable: "SpendingCategorys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSpendingPerMonths_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WithdrawHistorys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WithdrawDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WithdrawAmount = table.Column<double>(type: "float", nullable: false),
                    BankId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WithdrawHistorys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WithdrawHistorys_BankAccounts_BankId",
                        column: x => x.BankId,
                        principalTable: "BankAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AmountPerCategorys_SpendingCategoryId",
                table: "AmountPerCategorys",
                column: "SpendingCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AmountPerMonthDetails_MonthOfSpendingId",
                table: "AmountPerMonthDetails",
                column: "MonthOfSpendingId");

            migrationBuilder.CreateIndex(
                name: "IX_AmountPerMonthDetails_UserId",
                table: "AmountPerMonthDetails",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_UserId",
                table: "BankAccounts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentActualCashAmounts_MonthOfSpendingId",
                table: "CurrentActualCashAmounts",
                column: "MonthOfSpendingId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentActualCashAmounts_UserId",
                table: "CurrentActualCashAmounts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SpendingActualPerDays_MonthOfSpendingId",
                table: "SpendingActualPerDays",
                column: "MonthOfSpendingId");

            migrationBuilder.CreateIndex(
                name: "IX_SpendingActualPerDays_UserId",
                table: "SpendingActualPerDays",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SpendingByDays_MonthOfSpendingId",
                table: "SpendingByDays",
                column: "MonthOfSpendingId");

            migrationBuilder.CreateIndex(
                name: "IX_SpendingByDays_SpendingCategoryId",
                table: "SpendingByDays",
                column: "SpendingCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SpendingByDays_UserId",
                table: "SpendingByDays",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TotalAmountCategoryPerMonths_MonthOfSpendingId",
                table: "TotalAmountCategoryPerMonths",
                column: "MonthOfSpendingId");

            migrationBuilder.CreateIndex(
                name: "IX_TotalAmountCategoryPerMonths_SpendingCategoryId",
                table: "TotalAmountCategoryPerMonths",
                column: "SpendingCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TotalAmountCategoryPerMonths_UserId",
                table: "TotalAmountCategoryPerMonths",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSpendingPerMonths_MonthOfSpendingId",
                table: "UserSpendingPerMonths",
                column: "MonthOfSpendingId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSpendingPerMonths_SpendingCategoryId",
                table: "UserSpendingPerMonths",
                column: "SpendingCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSpendingPerMonths_UserId",
                table: "UserSpendingPerMonths",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WithdrawHistorys_BankId",
                table: "WithdrawHistorys",
                column: "BankId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AmountPerCategorys");

            migrationBuilder.DropTable(
                name: "AmountPerMonthDetails");

            migrationBuilder.DropTable(
                name: "CurrentActualCashAmounts");

            migrationBuilder.DropTable(
                name: "SpendingActualPerDays");

            migrationBuilder.DropTable(
                name: "SpendingByDays");

            migrationBuilder.DropTable(
                name: "TotalAmountCategoryPerMonths");

            migrationBuilder.DropTable(
                name: "UserSpendingPerMonths");

            migrationBuilder.DropTable(
                name: "WithdrawHistorys");

            migrationBuilder.DropTable(
                name: "MonthOfSpendings");

            migrationBuilder.DropTable(
                name: "SpendingCategorys");

            migrationBuilder.DropTable(
                name: "BankAccounts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
