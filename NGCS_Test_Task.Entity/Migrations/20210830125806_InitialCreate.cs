using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace NGCS_Test_Task.Entity.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.CreateTable(
				name: "Albums",
				columns: table => new
				{
					artistName = table.Column<string>(type: "nvarchar(max)", nullable: true),
					albumName = table.Column<string>(type: "nvarchar(max)", nullable: true),
					albumCensoredName = table.Column<string>(type: "nvarchar(max)", nullable: true),
					artistViewUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
					albumViewUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
					artworkUrl60 = table.Column<string>(type: "nvarchar(max)", nullable: true),
					artworkUrl100 = table.Column<string>(type: "nvarchar(max)", nullable: true),
					price = table.Column<float>(type: "real", nullable: false),
					trackCount = table.Column<int>(type: "int", nullable: false),
					copyright = table.Column<string>(type: "nvarchar(max)", nullable: true),
					country = table.Column<string>(type: "nvarchar(max)", nullable: true),
					currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
					releaseDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
					genre = table.Column<string>(type: "nvarchar(max)", nullable: true)
				},
				constraints: table =>
				{
				});
		}

        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.DropTable(
			name: "Albums");
		}
    }
}
