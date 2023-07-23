using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace chomer_backend.Migrations
{
    /// <inheritdoc />
    public partial class seeddatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HouseUsers_Users_UserId",
                table: "HouseUsers");

            migrationBuilder.DropIndex(
                name: "IX_HouseUsers_UserId",
                table: "HouseUsers");

            migrationBuilder.InsertData(
                table: "Chores",
                columns: new[] { "Id", "AssignedToId", "CreatedById", "Description", "HouseId", "Name", "Value" },
                values: new object[,]
                {
                    { 1, 1, 2, "Whole villa otherwise I will not count it <3", 1, "Vaccum", 100 },
                    { 2, null, 2, null, 1, "Dishwasher", null }
                });

            migrationBuilder.UpdateData(
                table: "HouseUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "HouseUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "IsAdmin", "UserId" },
                values: new object[] { true, 2 });

            migrationBuilder.InsertData(
                table: "HouseUsers",
                columns: new[] { "Id", "HouseId", "IsAdmin", "Points", "UserId" },
                values: new object[] { 3, 1, false, 0, 3 });

            migrationBuilder.InsertData(
                table: "Rewards",
                columns: new[] { "Id", "Cost", "HouseId", "Name", "Quantity" },
                values: new object[,]
                {
                    { 1, 2000, 1, "Holiday trip", 1 },
                    { 2, 200, 1, "Ice cream", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[] { 3, "walt@gmail.com", "Walter", "Walword" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Chores",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Chores",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "HouseUsers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rewards",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "HouseUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "HouseUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "IsAdmin", "UserId" },
                values: new object[] { false, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_HouseUsers_UserId",
                table: "HouseUsers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_HouseUsers_Users_UserId",
                table: "HouseUsers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
