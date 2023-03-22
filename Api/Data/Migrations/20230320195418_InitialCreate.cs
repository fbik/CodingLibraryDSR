using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    uid = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    difficultyindex = table.Column<int>(name: "difficulty_index", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_categories", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "languages",
                columns: table => new
                {
                    uid = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    version = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_languages", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    uid = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    passwordhash = table.Column<string>(name: "password_hash", type: "text", nullable: false),
                    userstatus = table.Column<string>(name: "user_status", type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.uid);
                });

            migrationBuilder.CreateTable(
                name: "problems",
                columns: table => new
                {
                    uid = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    solution = table.Column<string>(type: "text", nullable: false),
                    difficultindex = table.Column<int>(name: "difficult_index", type: "integer", nullable: false),
                    categoryuid = table.Column<Guid>(name: "category_uid", type: "uuid", nullable: false),
                    languageuid = table.Column<Guid>(name: "language_uid", type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_problems", x => x.uid);
                    table.ForeignKey(
                        name: "fk_problems_categories_category_uid",
                        column: x => x.categoryuid,
                        principalTable: "categories",
                        principalColumn: "uid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_problems_languages_language_uid",
                        column: x => x.languageuid,
                        principalTable: "languages",
                        principalColumn: "uid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    uid = table.Column<Guid>(type: "uuid", nullable: false),
                    contentcomments = table.Column<string>(name: "content_comments", type: "text", nullable: false),
                    lefttime = table.Column<DateTime>(name: "left_time", type: "timestamp with time zone", nullable: false),
                    problemuid = table.Column<Guid>(name: "problem_uid", type: "uuid", nullable: false),
                    useruid = table.Column<Guid>(name: "user_uid", type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_comments", x => x.uid);
                    table.ForeignKey(
                        name: "fk_comments_problems_problem_temp_id",
                        column: x => x.problemuid,
                        principalTable: "problems",
                        principalColumn: "uid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_comments_users_user_temp_id",
                        column: x => x.useruid,
                        principalTable: "users",
                        principalColumn: "uid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "subscriptions",
                columns: table => new
                {
                    uid = table.Column<Guid>(type: "uuid", nullable: false),
                    statussubscriptions = table.Column<string>(name: "status_subscriptions", type: "text", nullable: false),
                    problemuid = table.Column<Guid>(name: "problem_uid", type: "uuid", nullable: false),
                    useruid = table.Column<Guid>(name: "user_uid", type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_subscriptions", x => x.uid);
                    table.ForeignKey(
                        name: "fk_subscriptions_problems_problem_uid",
                        column: x => x.problemuid,
                        principalTable: "problems",
                        principalColumn: "uid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_subscriptions_users_user_temp_id1",
                        column: x => x.useruid,
                        principalTable: "users",
                        principalColumn: "uid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_categories_uid",
                table: "categories",
                column: "uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_comments_problem_uid",
                table: "comments",
                column: "problem_uid");

            migrationBuilder.CreateIndex(
                name: "ix_comments_uid",
                table: "comments",
                column: "uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_comments_user_uid",
                table: "comments",
                column: "user_uid");

            migrationBuilder.CreateIndex(
                name: "ix_languages_uid",
                table: "languages",
                column: "uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_problems_category_uid",
                table: "problems",
                column: "category_uid");

            migrationBuilder.CreateIndex(
                name: "ix_problems_language_uid",
                table: "problems",
                column: "language_uid");

            migrationBuilder.CreateIndex(
                name: "ix_problems_uid",
                table: "problems",
                column: "uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_subscriptions_problem_uid",
                table: "subscriptions",
                column: "problem_uid");

            migrationBuilder.CreateIndex(
                name: "ix_subscriptions_uid",
                table: "subscriptions",
                column: "uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_subscriptions_user_uid",
                table: "subscriptions",
                column: "user_uid");

            migrationBuilder.CreateIndex(
                name: "ix_users_uid",
                table: "users",
                column: "uid",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.DropTable(
                name: "subscriptions");

            migrationBuilder.DropTable(
                name: "problems");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "languages");
        }
    }
}
