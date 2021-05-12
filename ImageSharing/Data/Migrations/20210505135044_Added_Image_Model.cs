using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ImageSharing.Data.Migrations
{
    public partial class Added_Image_Model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Images");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Images",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_Username",
                table: "Images",
                column: "Username");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_AspNetUsers_Username",
                table: "Images",
                column: "Username",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_AspNetUsers_Username",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_Username",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Images");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Images",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });
        }
    }
}
