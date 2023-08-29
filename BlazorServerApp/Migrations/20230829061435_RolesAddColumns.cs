using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorServerApp.Migrations
{
    /// <inheritdoc />
    public partial class RolesAddColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsChecked",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsChecked",
                table: "Roles");
        }
    }
}
