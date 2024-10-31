﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hw57.Migrations
{
    /// <inheritdoc />
    public partial class AddClosedAtToMyTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ClosedAt",
                table: "MyTasks",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClosedAt",
                table: "MyTasks");
        }
    }
}
