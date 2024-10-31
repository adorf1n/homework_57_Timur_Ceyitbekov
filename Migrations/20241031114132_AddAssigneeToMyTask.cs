using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hw57.Migrations
{
    /// <inheritdoc />
    public partial class AddAssigneeToMyTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Assignee",
                table: "MyTasks",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Assignee",
                table: "MyTasks");
        }
    }
}
