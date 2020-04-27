using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ItaLog.Data.Migrations
{
    public partial class mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ApiUser",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "LastUpdateDate", "UserToken" },
                values: new object[] { new DateTime(2020, 4, 27, 0, 9, 18, 961, DateTimeKind.Local).AddTicks(566), new DateTime(2020, 4, 27, 0, 9, 18, 962, DateTimeKind.Local).AddTicks(2053), new Guid("8a74affc-f625-451f-9ea7-651980e87fdc") });

            migrationBuilder.UpdateData(
                table: "ApiUser",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "LastUpdateDate", "UserToken" },
                values: new object[] { new DateTime(2020, 4, 27, 0, 9, 18, 962, DateTimeKind.Local).AddTicks(2868), new DateTime(2020, 4, 27, 0, 9, 18, 962, DateTimeKind.Local).AddTicks(2886), new Guid("a677d9b6-37df-4863-9759-2730e3c45023") });

            migrationBuilder.UpdateData(
                table: "ApiUser",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "LastUpdateDate", "UserToken" },
                values: new object[] { new DateTime(2020, 4, 27, 0, 9, 18, 962, DateTimeKind.Local).AddTicks(2899), new DateTime(2020, 4, 27, 0, 9, 18, 962, DateTimeKind.Local).AddTicks(2900), new Guid("719a5a86-51a4-4680-b3b0-36bb6043d0bf") });

            migrationBuilder.UpdateData(
                table: "ApiUser",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreateDate", "LastUpdateDate", "UserToken" },
                values: new object[] { new DateTime(2020, 4, 27, 0, 9, 18, 962, DateTimeKind.Local).AddTicks(2903), new DateTime(2020, 4, 27, 0, 9, 18, 962, DateTimeKind.Local).AddTicks(2905), new Guid("15fad97a-54fc-4f93-94c3-5761570a9a53") });

            migrationBuilder.UpdateData(
                table: "ApiUser",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreateDate", "LastUpdateDate", "UserToken" },
                values: new object[] { new DateTime(2020, 4, 27, 0, 9, 18, 962, DateTimeKind.Local).AddTicks(2908), new DateTime(2020, 4, 27, 0, 9, 18, 962, DateTimeKind.Local).AddTicks(2909), new Guid("2dc18d4a-4c26-4e25-ab3e-12b3e2cee373") });

            migrationBuilder.UpdateData(
                table: "ApiUser",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreateDate", "LastUpdateDate", "UserToken" },
                values: new object[] { new DateTime(2020, 4, 27, 0, 9, 18, 962, DateTimeKind.Local).AddTicks(2913), new DateTime(2020, 4, 27, 0, 9, 18, 962, DateTimeKind.Local).AddTicks(2914), new Guid("50b97946-a456-4d85-990f-57504def02d9") });

            migrationBuilder.UpdateData(
                table: "ApiUser",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreateDate", "LastUpdateDate", "UserToken" },
                values: new object[] { new DateTime(2020, 4, 27, 0, 9, 18, 962, DateTimeKind.Local).AddTicks(2918), new DateTime(2020, 4, 27, 0, 9, 18, 962, DateTimeKind.Local).AddTicks(2919), new Guid("70cfe502-06b1-41f6-8b82-c9b1a0aaa580") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ApiUser",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "LastUpdateDate", "UserToken" },
                values: new object[] { new DateTime(2020, 4, 25, 18, 26, 11, 68, DateTimeKind.Local).AddTicks(8403), new DateTime(2020, 4, 25, 18, 26, 11, 69, DateTimeKind.Local).AddTicks(1965), new Guid("63c7a51a-06d6-4819-b690-d0ca40a90103") });

            migrationBuilder.UpdateData(
                table: "ApiUser",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "LastUpdateDate", "UserToken" },
                values: new object[] { new DateTime(2020, 4, 25, 18, 26, 11, 69, DateTimeKind.Local).AddTicks(2603), new DateTime(2020, 4, 25, 18, 26, 11, 69, DateTimeKind.Local).AddTicks(2615), new Guid("ca32612a-ab36-4acf-8610-001cfd9f4cc4") });

            migrationBuilder.UpdateData(
                table: "ApiUser",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "LastUpdateDate", "UserToken" },
                values: new object[] { new DateTime(2020, 4, 25, 18, 26, 11, 69, DateTimeKind.Local).AddTicks(2637), new DateTime(2020, 4, 25, 18, 26, 11, 69, DateTimeKind.Local).AddTicks(2639), new Guid("2fb55a27-23f0-4d4f-aecb-a280010e8d57") });

            migrationBuilder.UpdateData(
                table: "ApiUser",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreateDate", "LastUpdateDate", "UserToken" },
                values: new object[] { new DateTime(2020, 4, 25, 18, 26, 11, 69, DateTimeKind.Local).AddTicks(2641), new DateTime(2020, 4, 25, 18, 26, 11, 69, DateTimeKind.Local).AddTicks(2642), new Guid("56e9e440-0bfe-4105-aa9d-a50084aae2e3") });

            migrationBuilder.UpdateData(
                table: "ApiUser",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreateDate", "LastUpdateDate", "UserToken" },
                values: new object[] { new DateTime(2020, 4, 25, 18, 26, 11, 69, DateTimeKind.Local).AddTicks(2645), new DateTime(2020, 4, 25, 18, 26, 11, 69, DateTimeKind.Local).AddTicks(2646), new Guid("56f88cc2-acc1-4a14-821f-f7b7058d1c06") });

            migrationBuilder.UpdateData(
                table: "ApiUser",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreateDate", "LastUpdateDate", "UserToken" },
                values: new object[] { new DateTime(2020, 4, 25, 18, 26, 11, 69, DateTimeKind.Local).AddTicks(2648), new DateTime(2020, 4, 25, 18, 26, 11, 69, DateTimeKind.Local).AddTicks(2649), new Guid("19137a30-888e-49ba-a60d-2dd5c03c8227") });

            migrationBuilder.UpdateData(
                table: "ApiUser",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreateDate", "LastUpdateDate", "UserToken" },
                values: new object[] { new DateTime(2020, 4, 25, 18, 26, 11, 69, DateTimeKind.Local).AddTicks(2652), new DateTime(2020, 4, 25, 18, 26, 11, 69, DateTimeKind.Local).AddTicks(2652), new Guid("7eb7c1bd-9e17-4b62-bfa1-3485054e04d9") });
        }
    }
}
