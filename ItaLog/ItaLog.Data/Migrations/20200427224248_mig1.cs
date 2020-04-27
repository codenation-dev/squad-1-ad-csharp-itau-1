using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ItaLog.Data.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Environment",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Environment",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Environment",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Level",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Level",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Level",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 7);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
