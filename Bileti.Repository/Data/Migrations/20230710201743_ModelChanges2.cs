using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bileti.Web.Data.Migrations
{
    public partial class ModelChanges2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Bilets",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BiletName = table.Column<string>(nullable: false),
                    BiletDescription = table.Column<string>(nullable: false),
                    BiletPrice = table.Column<double>(nullable: false),
                    BiletCount = table.Column<int>(nullable: false),
                    BiletDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bilets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCards",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OwnerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCards_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BiletInOrder",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OrderId = table.Column<Guid>(nullable: false),
                    BiletId = table.Column<Guid>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BiletInOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BiletInOrder_Bilets_BiletId",
                        column: x => x.BiletId,
                        principalTable: "Bilets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BiletInOrder_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BiletInShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BiletId = table.Column<Guid>(nullable: false),
                    ShoppingCartId = table.Column<Guid>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BiletInShoppingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BiletInShoppingCarts_Bilets_BiletId",
                        column: x => x.BiletId,
                        principalTable: "Bilets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BiletInShoppingCarts_ShoppingCards_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "ShoppingCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BiletInOrder_BiletId",
                table: "BiletInOrder",
                column: "BiletId");

            migrationBuilder.CreateIndex(
                name: "IX_BiletInOrder_OrderId",
                table: "BiletInOrder",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_BiletInShoppingCarts_BiletId",
                table: "BiletInShoppingCarts",
                column: "BiletId");

            migrationBuilder.CreateIndex(
                name: "IX_BiletInShoppingCarts_ShoppingCartId",
                table: "BiletInShoppingCarts",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId",
                table: "Order",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCards_OwnerId",
                table: "ShoppingCards",
                column: "OwnerId",
                unique: true,
                filter: "[OwnerId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BiletInOrder");

            migrationBuilder.DropTable(
                name: "BiletInShoppingCarts");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Bilets");

            migrationBuilder.DropTable(
                name: "ShoppingCards");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
