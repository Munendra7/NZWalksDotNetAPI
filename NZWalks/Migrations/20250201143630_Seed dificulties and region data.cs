using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.Migrations
{
    /// <inheritdoc />
    public partial class Seeddificultiesandregiondata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("24d5e56f-673a-49e1-b772-bd48d02f6161"), "Hard" },
                    { new Guid("312c3022-95cb-4749-a0e7-814c5c8b3e9b"), "Easy" },
                    { new Guid("5f59e1cc-1105-45b4-91ed-3a82011ebea1"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageProperty" },
                values: new object[,]
                {
                    { new Guid("21b657dc-bb98-4cc1-9758-0837c9e9cd64"), "TRG", "Tauranga", "https://example.com/images/tauranga.jpg" },
                    { new Guid("3c8147da-7de1-4b88-9419-c18e38979d24"), "PMR", "Palmerston North", "https://example.com/images/palmerston-north.jpg" },
                    { new Guid("4a87771b-4d56-491e-8a39-b5bb81b364f0"), "DUD", "Dunedin", "https://example.com/images/dunedin.jpg" },
                    { new Guid("53c87fdf-f8e2-4b3b-8bb6-33d4913f7dcd"), "NSN", "Nelson", "https://example.com/images/nelson.jpg" },
                    { new Guid("5a8e078f-9b8f-4abd-bae8-e4b3dc200725"), "WLG", "Wellington", "https://example.com/images/wellington.jpg" },
                    { new Guid("981b4ed7-b0f2-4cbb-a447-76ed1e1fba4c"), "IVC", "Invercargill", "https://example.com/images/invercargill.jpg" },
                    { new Guid("bb4ec9d4-79b9-47ba-83f2-8bfe04a014f3"), "CHC", "Christchurch", "https://example.com/images/christchurch.jpg" },
                    { new Guid("c888e272-d9cd-493b-8a01-e96d28e4beb0"), "AKL", "Auckland", "https://example.com/images/auckland.jpg" },
                    { new Guid("e1a22c36-2e7b-411d-a1aa-2cfd5f80c16d"), "HAM", "Hamilton", "https://example.com/images/hamilton.jpg" },
                    { new Guid("f8a943ff-6c5a-4b28-b32e-2218145f0e47"), "NPE", "Napier", "https://example.com/images/napier.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("24d5e56f-673a-49e1-b772-bd48d02f6161"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("312c3022-95cb-4749-a0e7-814c5c8b3e9b"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("5f59e1cc-1105-45b4-91ed-3a82011ebea1"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("21b657dc-bb98-4cc1-9758-0837c9e9cd64"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("3c8147da-7de1-4b88-9419-c18e38979d24"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("4a87771b-4d56-491e-8a39-b5bb81b364f0"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("53c87fdf-f8e2-4b3b-8bb6-33d4913f7dcd"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("5a8e078f-9b8f-4abd-bae8-e4b3dc200725"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("981b4ed7-b0f2-4cbb-a447-76ed1e1fba4c"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("bb4ec9d4-79b9-47ba-83f2-8bfe04a014f3"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("c888e272-d9cd-493b-8a01-e96d28e4beb0"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("e1a22c36-2e7b-411d-a1aa-2cfd5f80c16d"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f8a943ff-6c5a-4b28-b32e-2218145f0e47"));
        }
    }
}
