using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hw57.Migrations
{
    /// <inheritdoc />
    public partial class AddPriorityToMyTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "MyTasks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Priority",
                table: "MyTasks");
        }
    }
}
