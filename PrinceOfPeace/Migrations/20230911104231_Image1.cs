using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrinceOfPeace.Migrations
{
    /// <inheritdoc />
    public partial class Image1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "ChurchMembers");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Images",
                newName: "ImageName");

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "ChurchMembers",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "ChurchMembers");

            migrationBuilder.RenameColumn(
                name: "ImageName",
                table: "Images",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "ChurchMembers",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
