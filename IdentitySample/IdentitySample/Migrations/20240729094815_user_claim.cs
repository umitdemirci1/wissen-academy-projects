using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentitySample.Migrations
{
    /// <inheritdoc />
    public partial class user_claim : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "LocalClaim",
                table: "AspNetUserClaims",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocalClaim",
                table: "AspNetUserClaims");
        }
    }
}
