using Microsoft.EntityFrameworkCore.Migrations;

namespace usf_asgmt3_api.Migrations
{
    public partial class addedfinancial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company_Financials",
                columns: table => new
                {
                    symbol = table.Column<string>(nullable: false),
                    reportDate = table.Column<string>(nullable: false),
                    grossProfit = table.Column<long>(nullable: false),
                    costOfRevenue = table.Column<long>(nullable: false),
                    operatingRevenue = table.Column<long>(nullable: false),
                    totalRevenue = table.Column<long>(nullable: false),
                    operatingIncome = table.Column<long>(nullable: false),
                    netIncome = table.Column<long>(nullable: false),
                    researchAndDevelopment = table.Column<long>(nullable: false),
                    operatingExpense = table.Column<long>(nullable: false),
                    currentAssets = table.Column<long>(nullable: false),
                    totalAssets = table.Column<long>(nullable: false),
                    totalLiabilities = table.Column<long>(nullable: false),
                    currentCash = table.Column<long>(nullable: false),
                    currentDebt = table.Column<long>(nullable: false),
                    totalCash = table.Column<long>(nullable: false),
                    totalDebt = table.Column<long>(nullable: false),
                    shareholderEquity = table.Column<long>(nullable: false),
                    cashChange = table.Column<long>(nullable: false),
                    cashFlow = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company_Financials", x => new { x.symbol, x.reportDate });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Company_Financials");
        }
    }
}
