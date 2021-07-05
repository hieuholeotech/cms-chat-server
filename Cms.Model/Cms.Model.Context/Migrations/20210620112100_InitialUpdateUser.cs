using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cms.Model.Context.Migrations
{
    public partial class InitialUpdateUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_message_app_users_app_user_id",
                table: "message");

            migrationBuilder.DropForeignKey(
                name: "FK_message_app_users_target_user_id",
                table: "message");

            migrationBuilder.DropIndex(
                name: "IX_message_target_user_id",
                table: "message");

            migrationBuilder.DropColumn(
                name: "target_user_id",
                table: "message");

            migrationBuilder.UpdateData(
                table: "app_roles",
                keyColumn: "id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "concurrency_stamp",
                value: "ce066c86-b17c-4a76-923f-79566195942c");

            migrationBuilder.UpdateData(
                table: "app_users",
                keyColumn: "id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "concurrency_stamp", "password_hash" },
                values: new object[] { "af415d57-77dd-4336-91fe-aca734a1e872", "AQAAAAEAACcQAAAAEB8pK452Lt3ovlaUawEo7vpKwFmpd+BouEQtgKQTDMOyJNgeUvSLtFmyk7/x/ArzOw==" });

            migrationBuilder.AddForeignKey(
                name: "FK_message_app_users_app_user_id",
                table: "message",
                column: "app_user_id",
                principalTable: "app_users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_message_app_users_app_user_id",
                table: "message");

            migrationBuilder.AddColumn<Guid>(
                name: "target_user_id",
                table: "message",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "app_roles",
                keyColumn: "id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "concurrency_stamp",
                value: "b58b2457-eb36-4b1c-bceb-fc42d775577e");

            migrationBuilder.UpdateData(
                table: "app_users",
                keyColumn: "id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "concurrency_stamp", "password_hash" },
                values: new object[] { "e532af67-7ec8-451e-ac2e-bce2af07243a", "AQAAAAEAACcQAAAAELVYQ2RFn2p8GbptHJLIMeRWfkbjjx0cyAMAuyUC9ZcQtyFbCEqDmh6vH7uteA/hvA==" });

            migrationBuilder.CreateIndex(
                name: "IX_message_target_user_id",
                table: "message",
                column: "target_user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_message_app_users_app_user_id",
                table: "message",
                column: "app_user_id",
                principalTable: "app_users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_message_app_users_target_user_id",
                table: "message",
                column: "target_user_id",
                principalTable: "app_users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
