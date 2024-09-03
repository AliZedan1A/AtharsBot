using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtharsBot.Migrations
{
    /// <inheritdoc />
    public partial class f1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<ulong>(
                name: "ChannelID",
                table: "AtherTable",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0ul);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChannelID",
                table: "AtherTable");
        }
    }
}
