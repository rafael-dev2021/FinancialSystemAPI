using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinancialSystemAPI.Migrations
{
    /// <inheritdoc />
    public partial class FirstTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    CPF = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    AccountManager_EmployeeCode = table.Column<int>(type: "int", nullable: true),
                    EmployeeCode = table.Column<int>(type: "int", nullable: true),
                    AddressObjectValue_ZipCode = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    AddressObjectValue_Country = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    AddressObjectValue_State = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    AddressObjectValue_City = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.CPF);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountNumber);
                    table.ForeignKey(
                        name: "FK_Accounts_User_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "User",
                        principalColumn: "CPF",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionCashs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AccountOriginAccountNumber = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AccountDestinationAccountNumber = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionCashs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionCashs_Accounts_AccountDestinationAccountNumber",
                        column: x => x.AccountDestinationAccountNumber,
                        principalTable: "Accounts",
                        principalColumn: "AccountNumber");
                    table.ForeignKey(
                        name: "FK_TransactionCashs_Accounts_AccountOriginAccountNumber",
                        column: x => x.AccountOriginAccountNumber,
                        principalTable: "Accounts",
                        principalColumn: "AccountNumber");
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "CPF", "Discriminator", "Email", "Name", "Phone", "AddressObjectValue_City", "AddressObjectValue_Country", "AddressObjectValue_State", "AddressObjectValue_ZipCode" },
                values: new object[,]
                {
                    { "092.863.523-46", "Customer", "SatoruGojo@gmail.com", "Satoru Gojo", "+55 1191234-5678", "Purple Void", "Japão", "Unlimited", "984-0032" },
                    { "185.828.510-55", "Customer", "NobaraKugisaki@gmail.com", "Nobara Kugisaki", "+55 1191234-5678", "Morioka", "Japão", "Iwate", "984-0032" },
                    { "352.252.250-81", "Customer", "MegumiFushiguro@gmail.com", "Megumi Fushiguro", "+55 1191234-5678", "Tsumiki Fushiguro", "Japão", "Toji Fushiguro", "984-0082" },
                    { "622.850.130-51", "Customer", "YujiItadori@gmail.com", "Yuji Itadori", "+55 1191234-5678", "Sendai-shi", "Japão", "Miyagi", "984-0032" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountNumber", "Balance", "CustomerId", "Type" },
                values: new object[,]
                {
                    { "196020-2", 4550m, "185.828.510-55", "Current Account" },
                    { "50548-7", 50m, "092.863.523-46", "Current Account" },
                    { "595540-6", 1250.95m, "622.850.130-51", "Current account" },
                    { "92172-7", 2250.45m, "352.252.250-81", "Current Account" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CustomerId",
                table: "Accounts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionCashs_AccountDestinationAccountNumber",
                table: "TransactionCashs",
                column: "AccountDestinationAccountNumber");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionCashs_AccountOriginAccountNumber",
                table: "TransactionCashs",
                column: "AccountOriginAccountNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransactionCashs");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
