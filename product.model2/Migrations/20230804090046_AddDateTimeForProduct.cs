﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace product.model2.Migrations
{
    /// <inheritdoc />
    public partial class AddDateTimeForProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PublishDate",
                table: "Products",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublishDate",
                table: "Products");
        }
    }
}
