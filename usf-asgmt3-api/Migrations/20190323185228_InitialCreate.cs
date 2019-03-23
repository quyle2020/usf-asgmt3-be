using Microsoft.EntityFrameworkCore.Migrations;

namespace usf_asgmt3_api.Migrations
{
    public partial class InitialCreate : Migration
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Prices");
        }
    }
}
