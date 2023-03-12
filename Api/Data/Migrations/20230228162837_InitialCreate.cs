using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingLibraryDSR.Data.Migrations
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
                    difficulty_index = table.Column<int>(type: "integer", nullable: false)
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
                    password_hash = table.Column<string>(type: "text", nullable: false),
                    user_status = table.Column<string>(type: "text", nullable: false)
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
                    difficult_index = table.Column<int>(type: "integer", nullable: false),
                    category_uid = table.Column<Guid>(type: "uuid", nullable: false),
                    language_uid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_problems", x => x.uid);
                    table.ForeignKey(
                        name: "fk_problems_categories_category_uid",
                        column: x => x.category_uid,
                        principalTable: "categories",
                        principalColumn: "uid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_problems_languages_language_uid",
                        column: x => x.language_uid,
                        principalTable: "languages",
                        principalColumn: "uid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    uid = table.Column<Guid>(type: "uuid", nullable: false),
                    content_comments = table.Column<string>(type: "text", nullable: false),
                    left_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    problem_uid = table.Column<Guid>(type: "uuid", nullable: false),
                    user_uid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_comments", x => x.uid);
                    table.ForeignKey(
                        name: "fk_comments_problems_problem_temp_id",
                        column: x => x.problem_uid,
                        principalTable: "problems",
                        principalColumn: "uid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_comments_users_user_temp_id",
                        column: x => x.user_uid,
                        principalTable: "users",
                        principalColumn: "uid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "subscriptions",
                columns: table => new
                {
                    uid = table.Column<Guid>(type: "uuid", nullable: false),
                    status_subscriptions = table.Column<string>(type: "text", nullable: false),
                    problem_uid = table.Column<Guid>(type: "uuid", nullable: false),
                    user_uid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_subscriptions", x => x.uid);
                    table.ForeignKey(
                        name: "fk_subscriptions_problems_problem_uid",
                        column: x => x.problem_uid,
                        principalTable: "problems",
                        principalColumn: "uid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_subscriptions_users_user_temp_id1",
                        column: x => x.user_uid,
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
