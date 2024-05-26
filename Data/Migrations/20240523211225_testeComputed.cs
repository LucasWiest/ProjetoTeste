using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoTeste.Data.Migrations
{
    /// <inheritdoc />
    public partial class testeComputed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Group",
                table: "Professions");

            migrationBuilder.AlterColumn<decimal>(
                name: "NetSalary",
                schema: "dbo",
                table: "Clients",
                type: "decimal(18,2)",
                nullable: false,
                computedColumnSql: "[GrossSalary] - [Discount]",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Group",
                table: "Professions",
                type: "varchar(250)",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "NetSalary",
                schema: "dbo",
                table: "Clients",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldComputedColumnSql: "[GrossSalary] - [Discount]");
        }
    }
}
