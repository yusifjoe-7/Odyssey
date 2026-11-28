using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Odyssey.Infrastructure.Common.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class HostMainImageKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MainImageKey",
                table: "Hosts",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainImageKey",
                table: "Hosts");
        }
    }
}
