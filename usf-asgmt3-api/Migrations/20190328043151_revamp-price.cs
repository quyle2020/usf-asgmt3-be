using Microsoft.EntityFrameworkCore.Migrations;

namespace usf_asgmt3_api.Migrations
{
    public partial class revampprice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.CreateTable(
                name: "Company_Prices",
                columns: table => new
                {
                    symbol = table.Column<string>(nullable: false),
                    date = table.Column<string>(nullable: false),
                    open = table.Column<float>(nullable: false),
                    high = table.Column<float>(nullable: false),
                    low = table.Column<float>(nullable: false),
                    close = table.Column<float>(nullable: false),
                    volume = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company_Prices", x => new { x.symbol, x.date });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Company_Prices");

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    adj_close = table.Column<float>(nullable: false),
                    adj_high = table.Column<float>(nullable: false),
                    adj_low = table.Column<float>(nullable: false),
                    adj_open = table.Column<float>(nullable: false),
                    adj_volume = table.Column<int>(nullable: false),
                    close = table.Column<float>(nullable: false),
                    date = table.Column<string>(nullable: true),
                    frequency = table.Column<string>(nullable: true),
                    high = table.Column<float>(nullable: false),
                    intraperiod = table.Column<bool>(nullable: false),
                    low = table.Column<float>(nullable: false),
                    open = table.Column<float>(nullable: false),
                    ticker = table.Column<string>(nullable: true),
                    volume = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.id);
                });
        }
    }
}
