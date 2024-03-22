using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cms.Data.Migrations
{
    /// <inheritdoc />
    public partial class secondCheckIn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 3, 13, 22, 0, 0, 967, DateTimeKind.Local).AddTicks(2764), new DateTime(2024, 3, 13, 22, 0, 0, 967, DateTimeKind.Local).AddTicks(2765) });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 3, 13, 22, 0, 0, 967, DateTimeKind.Local).AddTicks(7627), new DateTime(2024, 3, 13, 22, 0, 0, 967, DateTimeKind.Local).AddTicks(7628) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 3, 13, 22, 0, 0, 968, DateTimeKind.Local).AddTicks(239), new DateTime(2024, 3, 13, 22, 0, 0, 968, DateTimeKind.Local).AddTicks(240) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 3, 13, 22, 0, 0, 968, DateTimeKind.Local).AddTicks(1251), new DateTime(2024, 3, 13, 22, 0, 0, 968, DateTimeKind.Local).AddTicks(1252) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "DoctorId", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 3, 13, 22, 0, 0, 968, DateTimeKind.Local).AddTicks(4699), 9, new DateTime(2024, 3, 13, 22, 0, 0, 968, DateTimeKind.Local).AddTicks(4700) });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 3, 13, 22, 0, 0, 969, DateTimeKind.Local).AddTicks(1035), new DateTime(2024, 3, 13, 22, 0, 0, 969, DateTimeKind.Local).AddTicks(1036) });

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 3, 13, 22, 0, 0, 969, DateTimeKind.Local).AddTicks(2763), new DateTime(2024, 3, 13, 22, 0, 0, 969, DateTimeKind.Local).AddTicks(2764) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 3, 13, 22, 0, 0, 969, DateTimeKind.Local).AddTicks(3775), new DateTime(2024, 3, 13, 22, 0, 0, 969, DateTimeKind.Local).AddTicks(3775) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 3, 13, 22, 0, 0, 969, DateTimeKind.Local).AddTicks(3778), new DateTime(2024, 3, 13, 22, 0, 0, 969, DateTimeKind.Local).AddTicks(3779) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 3, 13, 22, 0, 0, 969, DateTimeKind.Local).AddTicks(3781), new DateTime(2024, 3, 13, 22, 0, 0, 969, DateTimeKind.Local).AddTicks(3782) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 3, 13, 22, 0, 0, 969, DateTimeKind.Local).AddTicks(7697), new DateTime(2024, 3, 13, 22, 0, 0, 969, DateTimeKind.Local).AddTicks(7698) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 3, 11, 22, 44, 30, 913, DateTimeKind.Local).AddTicks(3004), new DateTime(2024, 3, 11, 22, 44, 30, 913, DateTimeKind.Local).AddTicks(3007) });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 3, 11, 22, 44, 30, 913, DateTimeKind.Local).AddTicks(8703), new DateTime(2024, 3, 11, 22, 44, 30, 913, DateTimeKind.Local).AddTicks(8704) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 3, 11, 22, 44, 30, 914, DateTimeKind.Local).AddTicks(1786), new DateTime(2024, 3, 11, 22, 44, 30, 914, DateTimeKind.Local).AddTicks(1787) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 3, 11, 22, 44, 30, 914, DateTimeKind.Local).AddTicks(3074), new DateTime(2024, 3, 11, 22, 44, 30, 914, DateTimeKind.Local).AddTicks(3075) });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 55, "Samsun" },
                    { 56, "Siirt" },
                    { 57, "Sinop" },
                    { 59, "Tekirdağ" }
                });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "DoctorId", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 3, 11, 22, 44, 30, 914, DateTimeKind.Local).AddTicks(6334), 0, new DateTime(2024, 3, 11, 22, 44, 30, 914, DateTimeKind.Local).AddTicks(6335) });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 3, 11, 22, 44, 30, 915, DateTimeKind.Local).AddTicks(3383), new DateTime(2024, 3, 11, 22, 44, 30, 915, DateTimeKind.Local).AddTicks(3383) });

            migrationBuilder.UpdateData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 3, 11, 22, 44, 30, 915, DateTimeKind.Local).AddTicks(5428), new DateTime(2024, 3, 11, 22, 44, 30, 915, DateTimeKind.Local).AddTicks(5429) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 3, 11, 22, 44, 30, 915, DateTimeKind.Local).AddTicks(6627), new DateTime(2024, 3, 11, 22, 44, 30, 915, DateTimeKind.Local).AddTicks(6628) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 3, 11, 22, 44, 30, 915, DateTimeKind.Local).AddTicks(6631), new DateTime(2024, 3, 11, 22, 44, 30, 915, DateTimeKind.Local).AddTicks(6632) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 3, 11, 22, 44, 30, 915, DateTimeKind.Local).AddTicks(6635), new DateTime(2024, 3, 11, 22, 44, 30, 915, DateTimeKind.Local).AddTicks(6635) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2024, 3, 11, 22, 44, 30, 916, DateTimeKind.Local).AddTicks(8772), new DateTime(2024, 3, 11, 22, 44, 30, 916, DateTimeKind.Local).AddTicks(8774) });
        }
    }
}
