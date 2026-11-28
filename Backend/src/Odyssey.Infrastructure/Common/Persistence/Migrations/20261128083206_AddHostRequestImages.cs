using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Odyssey.Infrastructure.Common.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddHostRequestImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddHostRequestId",
                table: "HostImages",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HostImages_AddHostRequestId",
                table: "HostImages",
                column: "AddHostRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_HostImages_AddHostRequests_AddHostRequestId",
                table: "HostImages",
                column: "AddHostRequestId",
                principalTable: "AddHostRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HostImages_AddHostRequests_AddHostRequestId",
                table: "HostImages");

            migrationBuilder.DropIndex(
                name: "IX_HostImages_AddHostRequestId",
                table: "HostImages");

            migrationBuilder.DropColumn(
                name: "AddHostRequestId",
                table: "HostImages");
        }
    }
}
