using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace chomer_backend.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Houses_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HouseUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Points = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    HouseId = table.Column<int>(type: "int", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HouseUsers_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HouseUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rewards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    HouseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rewards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rewards_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Chores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<int>(type: "int", nullable: true),
                    HouseId = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    AssignedToId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chores_HouseUsers_AssignedToId",
                        column: x => x.AssignedToId,
                        principalTable: "HouseUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Chores_HouseUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "HouseUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Chores_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[,]
                {
                    { 1, "pablo@gmail.com", "Pablo", "Paword" },
                    { 2, "gustav@gmail.com", "Gustavo", "Gusword" },
                    { 3, "walt@gmail.com", "Walter", "Walword" }
                });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Name", "OwnerId" },
                values: new object[] { 1, "Gustavilla", 2 });

            migrationBuilder.InsertData(
                table: "HouseUsers",
                columns: new[] { "Id", "HouseId", "IsAdmin", "Points", "UserId" },
                values: new object[,]
                {
                    { 1, 1, true, 0, 1 },
                    { 2, 1, true, 0, 2 },
                    { 3, 1, false, 0, 3 }
                });

            migrationBuilder.InsertData(
                table: "Rewards",
                columns: new[] { "Id", "Cost", "HouseId", "Name", "Quantity" },
                values: new object[,]
                {
                    { 1, 2000, 1, "Holiday trip", 1 },
                    { 2, 200, 1, "Ice cream", null }
                });

            migrationBuilder.InsertData(
                table: "Chores",
                columns: new[] { "Id", "AssignedToId", "CreatedById", "Description", "HouseId", "Name", "Value" },
                values: new object[,]
                {
                    { 1, 1, 2, "Whole villa otherwise I will not count it <3", 1, "Vaccum", 100 },
                    { 2, null, 2, null, 1, "Dishwasher", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chores_AssignedToId",
                table: "Chores",
                column: "AssignedToId");

            migrationBuilder.CreateIndex(
                name: "IX_Chores_CreatedById",
                table: "Chores",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Chores_HouseId",
                table: "Chores",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_OwnerId",
                table: "Houses",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseUsers_HouseId",
                table: "HouseUsers",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseUsers_UserId",
                table: "HouseUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rewards_HouseId",
                table: "Rewards",
                column: "HouseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chores");

            migrationBuilder.DropTable(
                name: "Rewards");

            migrationBuilder.DropTable(
                name: "HouseUsers");

            migrationBuilder.DropTable(
                name: "Houses");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
