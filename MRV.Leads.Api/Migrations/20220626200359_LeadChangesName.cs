using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MRV.Leads.Api.Migrations
{
    /// <inheritdoc />
    public partial class LeadChangesName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Leads",
                type: "nvarchar(max)",
                nullable: false,
                computedColumnSql: "[Name] + ' ' + [LastName]",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComputedColumnSql: "[Name] + ', ' + [LastName]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Leads",
                type: "nvarchar(max)",
                nullable: false,
                computedColumnSql: "[Name] + ', ' + [LastName]",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComputedColumnSql: "[Name] + ' ' + [LastName]");
        }
    }
}
