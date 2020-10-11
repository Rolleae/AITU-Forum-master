using Microsoft.EntityFrameworkCore.Migrations;

namespace AITU_forum1.Migrations
{
    public partial class mgr6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Groups_GroupId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "UserList");

            migrationBuilder.RenameIndex(
                name: "IX_Users_GroupId",
                table: "UserList",
                newName: "IX_UserList_GroupId");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "UserList",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserList",
                table: "UserList",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserList_Groups_GroupId",
                table: "UserList",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserList_Groups_GroupId",
                table: "UserList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserList",
                table: "UserList");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "UserList");

            migrationBuilder.RenameTable(
                name: "UserList",
                newName: "Users");

            migrationBuilder.RenameIndex(
                name: "IX_UserList_GroupId",
                table: "Users",
                newName: "IX_Users_GroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Groups_GroupId",
                table: "Users",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
