using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class Updatetest1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Borrow_Id",
                table: "Book");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Book",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "BorrowId",
                table: "Book",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Book_BorrowId",
                table: "Book",
                column: "BorrowId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Borrow_BorrowId",
                table: "Book",
                column: "BorrowId",
                principalTable: "Borrow",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Borrow_BorrowId",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_BorrowId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "BorrowId",
                table: "Book");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Book",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Borrow_Id",
                table: "Book",
                column: "Id",
                principalTable: "Borrow",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
