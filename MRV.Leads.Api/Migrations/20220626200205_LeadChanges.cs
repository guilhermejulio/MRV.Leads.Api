using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MRV.Leads.Api.Migrations
{
    /// <inheritdoc />
    public partial class LeadChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leads_LeadStatus_StatusId",
                table: "Leads");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Leads",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                table: "Leads",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Leads",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Leads",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Leads",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Leads",
                type: "nvarchar(max)",
                nullable: false,
                computedColumnSql: "[Name] + ', ' + [LastName]");

            migrationBuilder.AddForeignKey(
                name: "FK_Leads_LeadStatus_StatusId",
                table: "Leads",
                column: "StatusId",
                principalTable: "LeadStatus",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leads_LeadStatus_StatusId",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Leads");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Leads",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Leads_LeadStatus_StatusId",
                table: "Leads",
                column: "StatusId",
                principalTable: "LeadStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
