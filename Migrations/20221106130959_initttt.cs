using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMSProject.Migrations
{
    public partial class initttt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Key = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AadharNo = table.Column<int>(type: "int", nullable: false),
                    PanNo = table.Column<int>(type: "int", nullable: false),
                    DL_No = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.UserName);
                    table.ForeignKey(
                        name: "FK_Documents_Logins_UserName",
                        column: x => x.UserName,
                        principalTable: "Logins",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanDetails",
                columns: table => new
                {
                    LoanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    currentdate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoanType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoanStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanDetails", x => x.LoanId);
                    table.ForeignKey(
                        name: "FK_LoanDetails_Logins_UserName",
                        column: x => x.UserName,
                        principalTable: "Logins",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Last_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone_No = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDetails_Logins_UserName",
                        column: x => x.UserName,
                        principalTable: "Logins",
                        principalColumn: "Username");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoanDetails_UserName",
                table: "LoanDetails",
                column: "UserName");

            migrationBuilder.CreateIndex(
                name: "IX_UserDetails_UserName",
                table: "UserDetails",
                column: "UserName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "LoanDetails");

            migrationBuilder.DropTable(
                name: "UserDetails");

            migrationBuilder.DropTable(
                name: "Logins");
        }
    }
}
