using Microsoft.EntityFrameworkCore.Migrations;

namespace Rookie.Ecom.DataAccessor.Migrations
{
    public partial class updateproductrating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductRating_User_UserID",
                table: "ProductRating");

            migrationBuilder.DropIndex(
                name: "IX_ProductRating_UserID",
                table: "ProductRating");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ProductRating_UserID",
                table: "ProductRating",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductRating_User_UserID",
                table: "ProductRating",
                column: "UserID",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
