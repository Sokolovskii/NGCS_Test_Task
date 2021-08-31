using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace NGCS_Test_Task.Entity.Migrations
{
    public partial class Migration_v11 : Migration
    {
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<int>(
				name: "Id",
				table: "Albums",
				type: "int",
				nullable: false,
				defaultValue: 0)
				.Annotation("SqlServer:Identity", "1, 1");

			migrationBuilder.AddPrimaryKey(
				name: "PK_Albums",
				table: "Albums",
				column: "Id");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropPrimaryKey(
				name: "PK_Albums",
				table: "Albums");

			migrationBuilder.DropColumn(
				name: "Id",
				table: "Albums");
		}
	}
}
