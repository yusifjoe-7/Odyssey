using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Odyssey.Infrastructure.Common.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemoveApprovedAddHostRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApprovedAddHostRequests");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApprovedAddHostRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApprovedAdminId = table.Column<int>(type: "integer", nullable: false),
                    HostId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovedAddHostRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApprovedAddHostRequests_Admins_ApprovedAdminId",
                        column: x => x.ApprovedAdminId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApprovedAddHostRequests_Hosts_HostId",
                        column: x => x.HostId,
                        principalTable: "Hosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApprovedAddHostRequests_ApprovedAdminId",
                table: "ApprovedAddHostRequests",
                column: "ApprovedAdminId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovedAddHostRequests_HostId",
                table: "ApprovedAddHostRequests",
                column: "HostId");
        }
    }
}
