using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace music_performance_greenroom_server.Migrations
{
    /// <inheritdoc />
    public partial class removefullname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "User");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "User",
                type: "nvarchar(125)",
                maxLength: 125,
                nullable: false,
                defaultValue: "");
        }
    }
}
