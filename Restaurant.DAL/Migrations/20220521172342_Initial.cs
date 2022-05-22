using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurant.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IngredientProduct",
                columns: table => new
                {
                    IngredientsId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientProduct", x => new { x.IngredientsId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_IngredientProduct_Ingredients_IngredientsId",
                        column: x => x.IngredientsId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsComplete = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    TotalSum = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Pizza" },
                    { 2, "Sushi" },
                    { 3, "WOK" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 32, "chili pepper" },
                    { 33, "salmon" },
                    { 34, "mango" },
                    { 35, "tiger shrimp" },
                    { 36, "microgeen" },
                    { 37, "tobiko caviar" },
                    { 38, "Japanese mayonnaise" },
                    { 39, "avocado" },
                    { 40, "scrambled eggs" },
                    { 41, "snow crab" },
                    { 42, "tobika" },
                    { 43, "unagi sauce" },
                    { 44, "eel" },
                    { 45, "Chinese cabbage" },
                    { 46, "carrot" },
                    { 47, "sesame" },
                    { 48, "udon" },
                    { 49, "soy sauce" },
                    { 50, "soba" },
                    { 51, "brokolli" },
                    { 52, "funchoza" },
                    { 53, "mussels" },
                    { 54, "shrimps" },
                    { 55, "turkey" },
                    { 56, "veal" },
                    { 57, "peanut" },
                    { 31, "cucumber" },
                    { 30, "philadelphia cheese" },
                    { 28, "nori" },
                    { 14, "olives" },
                    { 3, "tomato sauce" },
                    { 4, "champignons" },
                    { 5, "oregano" },
                    { 6, "tabasco" },
                    { 7, "italian sousages" },
                    { 8, "onion" },
                    { 9, "bavarian sausages" },
                    { 10, "alfredo sause" },
                    { 11, "dor blue" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 12, "parmezan" },
                    { 13, "cheddar" },
                    { 29, "tuna" },
                    { 15, "tomatoes" },
                    { 16, "basil" },
                    { 17, "olive oil" },
                    { 18, "chiken" },
                    { 19, "pineapple" },
                    { 20, "corn" },
                    { 21, "Bualgaeian papper" },
                    { 22, "black eyed peas" },
                    { 23, "beacon" },
                    { 24, "charries" },
                    { 25, "salad iceberg" },
                    { 26, "quail eggs" },
                    { 27, "rice" },
                    { 2, "mozzarella" },
                    { 1, "salyami" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Administrator" },
                    { 2, "User" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Cost", "Name", "Weight" },
                values: new object[,]
                {
                    { 1, 1, 205m, "Papperoni", 450 },
                    { 22, 3, 125m, "Rice with veal", 400 },
                    { 21, 3, 145m, "Soba with turkey", 400 },
                    { 20, 3, 175m, "Rice with shrimps", 400 },
                    { 19, 3, 185m, "Funchoza seafood", 400 },
                    { 18, 3, 105m, "Soba with vegetables", 400 },
                    { 17, 3, 125m, "Udon with beacon", 400 },
                    { 16, 3, 120m, "Rice with Chiken", 400 },
                    { 15, 2, 105m, "Cheese roll", 220 },
                    { 14, 2, 230m, "Kanada roll", 240 },
                    { 13, 2, 155m, "Spider roll", 230 },
                    { 12, 2, 140m, "Tokio roll", 250 },
                    { 11, 2, 260m, "California with salmon", 220 },
                    { 10, 2, 270m, "Mango roll", 215 },
                    { 9, 2, 130m, "Tuna Tataki", 250 },
                    { 8, 1, 250m, "Caesar", 530 },
                    { 7, 1, 220m, "Vegeterian", 490 },
                    { 6, 1, 230m, "Hawaiian", 450 },
                    { 5, 1, 200m, "Margarita", 500 },
                    { 4, 1, 220m, "Salyami", 550 },
                    { 3, 1, 250m, "Four cheese", 450 },
                    { 2, 1, 215m, "Diablo", 500 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Password", "PhoneNumber", "RoleId" },
                values: new object[,]
                {
                    { 1, "admin@restaurant.com", "$2a$12$ie9R50Trbh8G0AMkqmGi7eR8EpgKJXSrekpeUs3VwOPTASNotdsTe", "0677678634", 1 },
                    { 2, "user@test.com", "$2a$12$QLyrnlYxql6mShPy/Y.4hODTslCkM008Kc3ZYOq4bmGxWX7.2FNuq", "0676512534", 2 }
                });

            migrationBuilder.InsertData(
                table: "IngredientProduct",
                columns: new[] { "IngredientsId", "ProductsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 49, 17 },
                    { 48, 17 },
                    { 47, 16 },
                    { 46, 16 },
                    { 21, 16 },
                    { 8, 16 },
                    { 45, 16 },
                    { 18, 16 },
                    { 27, 16 },
                    { 13, 15 },
                    { 30, 15 },
                    { 27, 15 },
                    { 44, 14 },
                    { 43, 14 },
                    { 33, 14 },
                    { 31, 14 },
                    { 39, 14 },
                    { 28, 14 },
                    { 27, 14 },
                    { 25, 13 },
                    { 42, 13 },
                    { 41, 13 },
                    { 40, 13 },
                    { 30, 13 },
                    { 28, 13 },
                    { 27, 13 },
                    { 31, 12 },
                    { 23, 17 },
                    { 18, 17 },
                    { 8, 17 },
                    { 46, 17 },
                    { 57, 22 },
                    { 46, 22 },
                    { 4, 22 },
                    { 45, 22 },
                    { 56, 22 },
                    { 27, 22 },
                    { 19, 21 },
                    { 20, 21 },
                    { 55, 21 },
                    { 50, 21 }
                });

            migrationBuilder.InsertData(
                table: "IngredientProduct",
                columns: new[] { "IngredientsId", "ProductsId" },
                values: new object[,]
                {
                    { 46, 20 },
                    { 51, 20 },
                    { 54, 20 },
                    { 39, 12 },
                    { 27, 20 },
                    { 45, 19 },
                    { 8, 19 },
                    { 46, 19 },
                    { 54, 19 },
                    { 53, 19 },
                    { 52, 19 },
                    { 46, 18 },
                    { 8, 18 },
                    { 15, 18 },
                    { 4, 18 },
                    { 45, 18 },
                    { 51, 18 },
                    { 50, 18 },
                    { 21, 19 },
                    { 37, 12 },
                    { 33, 12 },
                    { 27, 12 },
                    { 21, 7 },
                    { 2, 6 },
                    { 20, 6 },
                    { 19, 6 },
                    { 18, 6 },
                    { 2, 5 },
                    { 3, 5 },
                    { 17, 5 },
                    { 16, 5 },
                    { 15, 5 },
                    { 1, 4 },
                    { 2, 4 },
                    { 3, 4 },
                    { 22, 7 },
                    { 2, 3 },
                    { 12, 3 },
                    { 11, 3 },
                    { 10, 3 },
                    { 9, 2 },
                    { 8, 2 }
                });

            migrationBuilder.InsertData(
                table: "IngredientProduct",
                columns: new[] { "IngredientsId", "ProductsId" },
                values: new object[,]
                {
                    { 7, 2 },
                    { 6, 2 },
                    { 2, 2 },
                    { 1, 2 },
                    { 5, 1 },
                    { 4, 1 },
                    { 3, 1 },
                    { 2, 1 },
                    { 13, 3 },
                    { 28, 12 },
                    { 17, 7 },
                    { 4, 7 },
                    { 39, 11 },
                    { 38, 11 },
                    { 37, 11 },
                    { 28, 11 },
                    { 27, 11 },
                    { 36, 10 },
                    { 35, 10 },
                    { 34, 10 },
                    { 33, 10 },
                    { 28, 10 },
                    { 27, 10 },
                    { 32, 9 },
                    { 16, 7 },
                    { 30, 9 },
                    { 31, 9 },
                    { 28, 9 },
                    { 15, 7 },
                    { 3, 7 },
                    { 2, 7 },
                    { 20, 7 },
                    { 29, 9 },
                    { 18, 8 },
                    { 2, 8 },
                    { 12, 8 },
                    { 26, 8 },
                    { 24, 8 },
                    { 25, 8 },
                    { 27, 9 },
                    { 23, 8 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Date", "IsComplete", "TotalSum", "UserId" },
                values: new object[] { 3, new DateTime(2020, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 300m, 2 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Date", "IsComplete", "TotalSum", "UserId" },
                values: new object[] { 1, new DateTime(2020, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 100m, 1 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Date", "IsComplete", "TotalSum", "UserId" },
                values: new object[] { 2, new DateTime(2022, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 200m, 1 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Date", "IsComplete", "TotalSum", "UserId" },
                values: new object[] { 4, new DateTime(2021, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 300m, 2 });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "Id", "OrderId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 2, 2, 1 },
                    { 3, 3, 3, 2 },
                    { 4, 4, 4, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientProduct_ProductsId",
                table: "IngredientProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientProduct");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
