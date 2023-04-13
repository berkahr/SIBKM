using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class RelationshipAndCardinality : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Profilings_education_id",
                table: "Profilings",
                column: "education_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Educations_university_id",
                table: "Educations",
                column: "university_id");

            migrationBuilder.CreateIndex(
                name: "IX_AccountRoles_account_nik",
                table: "AccountRoles",
                column: "account_nik");

            migrationBuilder.CreateIndex(
                name: "IX_AccountRoles_role_id",
                table: "AccountRoles",
                column: "role_id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountRoles_Accounts_account_nik",
                table: "AccountRoles",
                column: "account_nik",
                principalTable: "Accounts",
                principalColumn: "employee_nik",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountRoles_Roles_role_id",
                table: "AccountRoles",
                column: "role_id",
                principalTable: "Roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Employees_employee_nik",
                table: "Accounts",
                column: "employee_nik",
                principalTable: "Employees",
                principalColumn: "nik",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_Universities_university_id",
                table: "Educations",
                column: "university_id",
                principalTable: "Universities",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profilings_Educations_education_id",
                table: "Profilings",
                column: "education_id",
                principalTable: "Educations",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profilings_Employees_employee_nik",
                table: "Profilings",
                column: "employee_nik",
                principalTable: "Employees",
                principalColumn: "nik",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountRoles_Accounts_account_nik",
                table: "AccountRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountRoles_Roles_role_id",
                table: "AccountRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Employees_employee_nik",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Educations_Universities_university_id",
                table: "Educations");

            migrationBuilder.DropForeignKey(
                name: "FK_Profilings_Educations_education_id",
                table: "Profilings");

            migrationBuilder.DropForeignKey(
                name: "FK_Profilings_Employees_employee_nik",
                table: "Profilings");

            migrationBuilder.DropIndex(
                name: "IX_Profilings_education_id",
                table: "Profilings");

            migrationBuilder.DropIndex(
                name: "IX_Educations_university_id",
                table: "Educations");

            migrationBuilder.DropIndex(
                name: "IX_AccountRoles_account_nik",
                table: "AccountRoles");

            migrationBuilder.DropIndex(
                name: "IX_AccountRoles_role_id",
                table: "AccountRoles");
        }
    }
}
