using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using OdeToFood.Entities;

namespace OdeToFood.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CuisineType",
                table: "Restaurants",
                nullable: false,
                defaultValue: CuisineType.None);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CuisineType",
                table: "Restaurants");
        }
    }
}
