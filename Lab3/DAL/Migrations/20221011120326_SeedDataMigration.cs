using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class SeedDataMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Category 1" },
                    { 2L, "Category 2" },
                    { 3L, "Category 3" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Country 1" },
                    { 2L, "Country 2" },
                    { 3L, "Country 3" }
                });

            migrationBuilder.InsertData(
                table: "Galleries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Gallery 1" },
                    { 2L, "Gallery 2" },
                    { 3L, "Gallery 3" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Role 1" },
                    { 2L, "Role 2" },
                    { 3L, "Role 3" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 1L, 1L, "City 1" },
                    { 2L, 2L, "City 2" },
                    { 3L, 3L, "City 3" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "GalleryId", "Name" },
                values: new object[,]
                {
                    { 1L, 1L, "Image 1" },
                    { 2L, 2L, "Image 2" },
                    { 3L, 2L, "Image 3" },
                    { 4L, 3L, "Image 4" },
                    { 5L, 3L, "Image 5" },
                    { 6L, 3L, "Image 6" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "Telephone" },
                values: new object[] { 1L, 1L, "user1@email.com", "FirstName1", "LastName1", "Password1", "00000000001" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "Telephone" },
                values: new object[] { 2L, 2L, "user2@email.com", "FirstName2", "LastName2", "Password2", "00000000002" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "Telephone" },
                values: new object[] { 3L, 3L, "user3@email.com", "FirstName3", "LastName3", "Password3", "00000000003" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CityId", "GalleryId", "Name", "UserId" },
                values: new object[,]
                {
                    { 1L, 1L, 1L, "Event 1", 1L },
                    { 2L, 1L, 1L, "Event 2", 1L },
                    { 3L, 1L, 1L, "Event 3", 1L },
                    { 4L, 2L, 2L, "Event 4", 2L },
                    { 5L, 3L, 3L, "Event 5", 3L }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "CreateAt", "UserId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2022, 10, 11, 15, 3, 26, 125, DateTimeKind.Local).AddTicks(7042), 1L },
                    { 2L, new DateTime(2022, 10, 11, 15, 3, 26, 125, DateTimeKind.Local).AddTicks(7079), 1L },
                    { 3L, new DateTime(2022, 10, 11, 15, 3, 26, 125, DateTimeKind.Local).AddTicks(7082), 1L },
                    { 4L, new DateTime(2022, 10, 11, 15, 3, 26, 125, DateTimeKind.Local).AddTicks(7085), 2L },
                    { 5L, new DateTime(2022, 10, 11, 15, 3, 26, 125, DateTimeKind.Local).AddTicks(7087), 3L }
                });

            migrationBuilder.InsertData(
                table: "RoleUser",
                columns: new[] { "RolesId", "UsersId" },
                values: new object[,]
                {
                    { 1L, 1L },
                    { 2L, 1L },
                    { 2L, 2L },
                    { 3L, 3L }
                });

            migrationBuilder.InsertData(
                table: "CategoryEvent",
                columns: new[] { "CategoriesId", "EventsId" },
                values: new object[,]
                {
                    { 1L, 1L },
                    { 1L, 2L },
                    { 2L, 2L },
                    { 3L, 3L },
                    { 3L, 4L },
                    { 3L, 5L }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CategoryEvent",
                keyColumns: new[] { "CategoriesId", "EventsId" },
                keyValues: new object[] { 1L, 1L });

            migrationBuilder.DeleteData(
                table: "CategoryEvent",
                keyColumns: new[] { "CategoriesId", "EventsId" },
                keyValues: new object[] { 1L, 2L });

            migrationBuilder.DeleteData(
                table: "CategoryEvent",
                keyColumns: new[] { "CategoriesId", "EventsId" },
                keyValues: new object[] { 2L, 2L });

            migrationBuilder.DeleteData(
                table: "CategoryEvent",
                keyColumns: new[] { "CategoriesId", "EventsId" },
                keyValues: new object[] { 3L, 3L });

            migrationBuilder.DeleteData(
                table: "CategoryEvent",
                keyColumns: new[] { "CategoriesId", "EventsId" },
                keyValues: new object[] { 3L, 4L });

            migrationBuilder.DeleteData(
                table: "CategoryEvent",
                keyColumns: new[] { "CategoriesId", "EventsId" },
                keyValues: new object[] { 3L, 5L });

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "RoleUser",
                keyColumns: new[] { "RolesId", "UsersId" },
                keyValues: new object[] { 1L, 1L });

            migrationBuilder.DeleteData(
                table: "RoleUser",
                keyColumns: new[] { "RolesId", "UsersId" },
                keyValues: new object[] { 2L, 1L });

            migrationBuilder.DeleteData(
                table: "RoleUser",
                keyColumns: new[] { "RolesId", "UsersId" },
                keyValues: new object[] { 2L, 2L });

            migrationBuilder.DeleteData(
                table: "RoleUser",
                keyColumns: new[] { "RolesId", "UsersId" },
                keyValues: new object[] { 3L, 3L });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Galleries",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Galleries",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Galleries",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3L);
        }
    }
}
