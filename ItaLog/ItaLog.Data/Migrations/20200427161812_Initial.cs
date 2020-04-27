using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ItaLog.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
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
                    table.PrimaryKey("PK_User", x => x.Id);
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
                        name: "FK_Log_User_ApiUserId",
                        column: x => x.ApiUserId,
                        principalTable: "User",
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
                name: "UserRole",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
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

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "User" },
                    { 2, "Administrator" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreateDate", "Email", "EmailConfirmed", "LastUpdateDate", "Name", "NormalizedUserName", "Password", "UserName", "UserToken" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 4, 27, 13, 18, 12, 347, DateTimeKind.Local).AddTicks(2515), "admin@contato.com", true, new DateTime(2020, 4, 27, 13, 18, 12, 347, DateTimeKind.Local).AddTicks(5883), "Admin", "ADMIN@CONTATO.COM", "AQAAAAEAACcQAAAAENiU++GjfU7q1nAIgwulJmL319Hj8DHBCiiag198T1yUIOSQusFnjpQDjdYZuxjCPw==", "admin@contato.com", new Guid("ca00974e-c905-4c09-97e2-17e1ff8ebccc") },
                    { 2, new DateTime(2020, 4, 27, 13, 18, 12, 347, DateTimeKind.Local).AddTicks(6460), "itau@contato.com", true, new DateTime(2020, 4, 27, 13, 18, 12, 347, DateTimeKind.Local).AddTicks(6472), "Itau", "ITAU@CONTATO.COM", "AQAAAAEAACcQAAAAENiU++GjfU7q1nAIgwulJmL319Hj8DHBCiiag198T1yUIOSQusFnjpQDjdYZuxjCPw==", "itau@contato.com", new Guid("1ee36516-e92b-4be7-8732-7e8667b7fff2") },
                    { 3, new DateTime(2020, 4, 27, 13, 18, 12, 347, DateTimeKind.Local).AddTicks(6482), "afonso@contato.com", true, new DateTime(2020, 4, 27, 13, 18, 12, 347, DateTimeKind.Local).AddTicks(6483), "Afonso", "AFONSO@CONTATO.COM", "AQAAAAEAACcQAAAAENiU++GjfU7q1nAIgwulJmL319Hj8DHBCiiag198T1yUIOSQusFnjpQDjdYZuxjCPw==", "afonso@contato.com", new Guid("5c0d3586-81ef-44d4-aa50-afab3e0e70e6") },
                    { 4, new DateTime(2020, 4, 27, 13, 18, 12, 347, DateTimeKind.Local).AddTicks(6486), "andre@contato.com", true, new DateTime(2020, 4, 27, 13, 18, 12, 347, DateTimeKind.Local).AddTicks(6487), "André", "ANDRE@CONTATO.COM", "AQAAAAEAACcQAAAAENiU++GjfU7q1nAIgwulJmL319Hj8DHBCiiag198T1yUIOSQusFnjpQDjdYZuxjCPw==", "andre@contato.com", new Guid("ca894eda-98b7-4992-843d-817eb9afdf43") },
                    { 5, new DateTime(2020, 4, 27, 13, 18, 12, 347, DateTimeKind.Local).AddTicks(6490), "brunna@contato.com", true, new DateTime(2020, 4, 27, 13, 18, 12, 347, DateTimeKind.Local).AddTicks(6491), "Brunna", "BRUNNA@CONTATO.COM", "AQAAAAEAACcQAAAAENiU++GjfU7q1nAIgwulJmL319Hj8DHBCiiag198T1yUIOSQusFnjpQDjdYZuxjCPw==", "brunna@contato.com", new Guid("3dac8ca4-31ab-4c4e-86b3-58956b188675") },
                    { 6, new DateTime(2020, 4, 27, 13, 18, 12, 347, DateTimeKind.Local).AddTicks(6493), "bruno@contato.com", true, new DateTime(2020, 4, 27, 13, 18, 12, 347, DateTimeKind.Local).AddTicks(6494), "Bruno", "BRUNO@CONTATO.COM", "AQAAAAEAACcQAAAAENiU++GjfU7q1nAIgwulJmL319Hj8DHBCiiag198T1yUIOSQusFnjpQDjdYZuxjCPw==", "bruno@contato.com", new Guid("3fd11e2f-836e-4986-8c73-aebf65235e89") },
                    { 7, new DateTime(2020, 4, 27, 13, 18, 12, 347, DateTimeKind.Local).AddTicks(6496), "carlos@contato.com", true, new DateTime(2020, 4, 27, 13, 18, 12, 347, DateTimeKind.Local).AddTicks(6497), "Carlos", "CARLOS@CONTATO.COM", "AQAAAAEAACcQAAAAENiU++GjfU7q1nAIgwulJmL319Hj8DHBCiiag198T1yUIOSQusFnjpQDjdYZuxjCPw==", "carlos@contato.com", new Guid("be7b8f9a-64b5-4c92-9bf4-2c1b77fc9612") }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Environment");

            migrationBuilder.DropTable(
                name: "Level");
        }
    }
}
