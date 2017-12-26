using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace LiveWorks.Core.Migrations
{
    public partial class RemovedInventory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemSetItems_Items_ItemId",
                table: "ItemSetItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orderitems_Items_ItemId",
                table: "Orderitems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orderitems_Orders_OrderId",
                table: "Orderitems");

            migrationBuilder.DropTable(
                name: "BillOrders");

            migrationBuilder.DropTable(
                name: "ItemInventories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orderitems",
                table: "Orderitems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.RenameTable(
                name: "Orderitems",
                newName: "OrderItems");

            migrationBuilder.RenameTable(
                name: "Items",
                newName: "Item");

            migrationBuilder.RenameIndex(
                name: "IX_Orderitems_OrderId",
                table: "OrderItems",
                newName: "IX_OrderItems_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Orderitems_ItemId",
                table: "OrderItems",
                newName: "IX_OrderItems_ItemId");

            migrationBuilder.AddColumn<int>(
                name: "AvailableQuantity",
                table: "Item",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "RestockDate",
                table: "Item",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "RestockQuantity",
                table: "Item",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Item",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Item",
                table: "Item",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemSetItems_Item_ItemId",
                table: "ItemSetItems",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Item_ItemId",
                table: "OrderItems",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemSetItems_Item_ItemId",
                table: "ItemSetItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Item_ItemId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Item",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "AvailableQuantity",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "RestockDate",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "RestockQuantity",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Item");

            migrationBuilder.RenameTable(
                name: "OrderItems",
                newName: "Orderitems");

            migrationBuilder.RenameTable(
                name: "Item",
                newName: "Items");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_OrderId",
                table: "Orderitems",
                newName: "IX_Orderitems_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_ItemId",
                table: "Orderitems",
                newName: "IX_Orderitems_ItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orderitems",
                table: "Orderitems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BillOrders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BillId = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillOrders_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemInventories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AvailableQuantity = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    RestockDate = table.Column<DateTime>(nullable: false),
                    RestockQuantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemInventories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemInventories_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BillOrders_BillId",
                table: "BillOrders",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_BillOrders_OrderId",
                table: "BillOrders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemInventories_ItemId",
                table: "ItemInventories",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemSetItems_Items_ItemId",
                table: "ItemSetItems",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orderitems_Items_ItemId",
                table: "Orderitems",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orderitems_Orders_OrderId",
                table: "Orderitems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
