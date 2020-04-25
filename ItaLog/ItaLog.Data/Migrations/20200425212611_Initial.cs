using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ItaLog.Data.Migrations
{
    public partial class Initial : Migration
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
                    Password = table.Column<string>(type: "varchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime", nullable: false)
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
                    ErrorDate = table.Column<DateTime>(type: "datetime", nullable: false),
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
                table: "ApiUser",
                columns: new[] { "Id", "CreateDate", "Email", "EmailConfirmed", "LastUpdateDate", "Name", "NormalizedUserName", "Password", "UserName", "UserToken" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 4, 25, 18, 26, 11, 68, DateTimeKind.Local).AddTicks(8403), "admin@contato.com", true, new DateTime(2020, 4, 25, 18, 26, 11, 69, DateTimeKind.Local).AddTicks(1965), "Admin", "ADMIN@CONTATO.COM", "AQAAAAEAACcQAAAAENiU++GjfU7q1nAIgwulJmL319Hj8DHBCiiag198T1yUIOSQusFnjpQDjdYZuxjCPw==", "admin@contato.com", new Guid("63c7a51a-06d6-4819-b690-d0ca40a90103") },
                    { 2, new DateTime(2020, 4, 25, 18, 26, 11, 69, DateTimeKind.Local).AddTicks(2603), "itau@contato.com", true, new DateTime(2020, 4, 25, 18, 26, 11, 69, DateTimeKind.Local).AddTicks(2615), "Itau", "ITAU@CONTATO.COM", "AQAAAAEAACcQAAAAENiU++GjfU7q1nAIgwulJmL319Hj8DHBCiiag198T1yUIOSQusFnjpQDjdYZuxjCPw==", "itau@contato.com", new Guid("ca32612a-ab36-4acf-8610-001cfd9f4cc4") },
                    { 3, new DateTime(2020, 4, 25, 18, 26, 11, 69, DateTimeKind.Local).AddTicks(2637), "afonso@contato.com", true, new DateTime(2020, 4, 25, 18, 26, 11, 69, DateTimeKind.Local).AddTicks(2639), "Afonso", "AFONSO@CONTATO.COM", "AQAAAAEAACcQAAAAENiU++GjfU7q1nAIgwulJmL319Hj8DHBCiiag198T1yUIOSQusFnjpQDjdYZuxjCPw==", "afonso@contato.com", new Guid("2fb55a27-23f0-4d4f-aecb-a280010e8d57") },
                    { 4, new DateTime(2020, 4, 25, 18, 26, 11, 69, DateTimeKind.Local).AddTicks(2641), "andre@contato.com", true, new DateTime(2020, 4, 25, 18, 26, 11, 69, DateTimeKind.Local).AddTicks(2642), "André", "ANDRE@CONTATO.COM", "AQAAAAEAACcQAAAAENiU++GjfU7q1nAIgwulJmL319Hj8DHBCiiag198T1yUIOSQusFnjpQDjdYZuxjCPw==", "andre@contato.com", new Guid("56e9e440-0bfe-4105-aa9d-a50084aae2e3") },
                    { 5, new DateTime(2020, 4, 25, 18, 26, 11, 69, DateTimeKind.Local).AddTicks(2645), "brunna@contato.com", true, new DateTime(2020, 4, 25, 18, 26, 11, 69, DateTimeKind.Local).AddTicks(2646), "Brunna", "BRUNNA@CONTATO.COM", "AQAAAAEAACcQAAAAENiU++GjfU7q1nAIgwulJmL319Hj8DHBCiiag198T1yUIOSQusFnjpQDjdYZuxjCPw==", "brunna@contato.com", new Guid("56f88cc2-acc1-4a14-821f-f7b7058d1c06") },
                    { 6, new DateTime(2020, 4, 25, 18, 26, 11, 69, DateTimeKind.Local).AddTicks(2648), "bruno@contato.com", true, new DateTime(2020, 4, 25, 18, 26, 11, 69, DateTimeKind.Local).AddTicks(2649), "Bruno", "BRUNO@CONTATO.COM", "AQAAAAEAACcQAAAAENiU++GjfU7q1nAIgwulJmL319Hj8DHBCiiag198T1yUIOSQusFnjpQDjdYZuxjCPw==", "bruno@contato.com", new Guid("19137a30-888e-49ba-a60d-2dd5c03c8227") },
                    { 7, new DateTime(2020, 4, 25, 18, 26, 11, 69, DateTimeKind.Local).AddTicks(2652), "carlos@contato.com", true, new DateTime(2020, 4, 25, 18, 26, 11, 69, DateTimeKind.Local).AddTicks(2652), "Carlos", "CARLOS@CONTATO.COM", "AQAAAAEAACcQAAAAENiU++GjfU7q1nAIgwulJmL319Hj8DHBCiiag198T1yUIOSQusFnjpQDjdYZuxjCPw==", "carlos@contato.com", new Guid("7eb7c1bd-9e17-4b62-bfa1-3485054e04d9") }
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
