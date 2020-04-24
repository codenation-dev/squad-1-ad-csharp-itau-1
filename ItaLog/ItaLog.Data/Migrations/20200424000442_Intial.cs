using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ItaLog.Data.Migrations
{
    public partial class Intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApiRole",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApiUser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserToken = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    UserName = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    NormalizedUserName = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    Email = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    Password = table.Column<string>(type: "varchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Environment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Environment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Level",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Level", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApiUserRole",
                columns: table => new
                {
                    ApiUserId = table.Column<int>(nullable: false),
                    ApiRoleId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiUserRole", x => new { x.ApiUserId, x.ApiRoleId });
                    table.ForeignKey(
                        name: "FK_ApiUserRole_ApiRole_ApiRoleId",
                        column: x => x.ApiRoleId,
                        principalTable: "ApiRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApiUserRole_ApiUser_ApiUserId",
                        column: x => x.ApiUserId,
                        principalTable: "ApiUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    Origin = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    Archived = table.Column<bool>(nullable: false),
                    LevelId = table.Column<int>(nullable: false),
                    EnvironmentId = table.Column<int>(nullable: false),
                    ApiUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Log_ApiUser_ApiUserId",
                        column: x => x.ApiUserId,
                        principalTable: "ApiUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Log_Environment_EnvironmentId",
                        column: x => x.EnvironmentId,
                        principalTable: "Environment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Log_Level_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Level",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Detail = table.Column<string>(type: "varchar(1024)", maxLength: 1024, nullable: false),
                    ErrorDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Event_Log_LogId",
                        column: x => x.LogId,
                        principalTable: "Log",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ApiRole",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "User" },
                    { 2, "Administrator" }
                });

            migrationBuilder.InsertData(
                table: "Environment",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Production" },
                    { 2, "Homologation" },
                    { 3, "Development" }
                });

            migrationBuilder.InsertData(
                table: "Level",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Debug" },
                    { 2, "Warning" },
                    { 3, "Error" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApiUserRole_ApiRoleId",
                table: "ApiUserRole",
                column: "ApiRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_LogId",
                table: "Event",
                column: "LogId");

            migrationBuilder.CreateIndex(
                name: "IX_Log_ApiUserId",
                table: "Log",
                column: "ApiUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Log_EnvironmentId",
                table: "Log",
                column: "EnvironmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Log_LevelId",
                table: "Log",
                column: "LevelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApiUserRole");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "ApiRole");

            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DropTable(
                name: "ApiUser");

            migrationBuilder.DropTable(
                name: "Environment");

            migrationBuilder.DropTable(
                name: "Level");
        }
    }
}
