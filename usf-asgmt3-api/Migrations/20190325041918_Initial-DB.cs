using Microsoft.EntityFrameworkCore.Migrations;

namespace usf_asgmt3_api.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    ticker = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    lei = table.Column<string>(nullable: true),
                    cik = table.Column<string>(nullable: true),
                    industry_category = table.Column<string>(nullable: true),
                    market_cap = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.ticker);
                });

            migrationBuilder.CreateTable(
                name: "Company_Details",
                columns: table => new
                {
                    symbol = table.Column<string>(nullable: false),
                    companyName = table.Column<string>(nullable: true),
                    exchange = table.Column<string>(nullable: true),
                    industry = table.Column<string>(nullable: true),
                    website = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    CEO = table.Column<string>(nullable: true),
                    issueType = table.Column<string>(nullable: true),
                    sector = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company_Details", x => x.symbol);
                });

            migrationBuilder.CreateTable(
                name: "Company_Dividends",
                columns: table => new
                {
                    symbol = table.Column<string>(nullable: false),
                    exDate = table.Column<string>(nullable: false),
                    paymentDate = table.Column<string>(nullable: true),
                    recordDate = table.Column<string>(nullable: true),
                    declaredDate = table.Column<string>(nullable: true),
                    amount = table.Column<float>(nullable: false),
                    flag = table.Column<string>(nullable: true),
                    type = table.Column<string>(nullable: true),
                    qualified = table.Column<string>(nullable: true),
                    indicated = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company_Dividends", x => new { x.symbol, x.exDate });
                });

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    ticker = table.Column<string>(nullable: true),
                    date = table.Column<string>(nullable: true),
                    intraperiod = table.Column<bool>(nullable: false),
                    frequency = table.Column<string>(nullable: true),
                    open = table.Column<float>(nullable: false),
                    high = table.Column<float>(nullable: false),
                    low = table.Column<float>(nullable: false),
                    close = table.Column<float>(nullable: false),
                    volume = table.Column<int>(nullable: false),
                    adj_open = table.Column<float>(nullable: false),
                    adj_high = table.Column<float>(nullable: false),
                    adj_low = table.Column<float>(nullable: false),
                    adj_close = table.Column<float>(nullable: false),
                    adj_volume = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Symbols",
                columns: table => new
                {
                    symbol = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    date = table.Column<string>(nullable: true),
                    isEnabled = table.Column<bool>(nullable: false),
                    type = table.Column<string>(nullable: true),
                    iexId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Symbols", x => x.symbol);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Company_Details");

            migrationBuilder.DropTable(
                name: "Company_Dividends");

            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "Symbols");
        }
    }
}
