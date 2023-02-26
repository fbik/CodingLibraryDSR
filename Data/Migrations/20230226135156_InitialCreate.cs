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
                    difficulty_index = table.Column<string>(type: "text", nullable: false)
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
                    difficult_index = table.Column<string>(type: "text", nullable: false),
                    categories_uid = table.Column<Guid>(type: "uuid", nullable: true),
                    languages_uid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_problems", x => x.uid);
                    table.ForeignKey(
                        name: "fk_problems_categories_categories_uid",
                        column: x => x.categories_uid,
                        principalTable: "categories",
                        principalColumn: "uid");
                    table.ForeignKey(
                        name: "fk_problems_languages_languages_uid",
                        column: x => x.languages_uid,
                        principalTable: "languages",
                        principalColumn: "uid");
                });

            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    uid = table.Column<Guid>(type: "uuid", nullable: false),
                    content_comments = table.Column<string>(type: "text", nullable: false),
                    left_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    problems_uid = table.Column<Guid>(type: "uuid", nullable: true),
                    users_uid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_comments", x => x.uid);
                    table.ForeignKey(
                        name: "fk_comments_problems_problems_temp_id",
                        column: x => x.problems_uid,
                        principalTable: "problems",
                        principalColumn: "uid");
                    table.ForeignKey(
                        name: "fk_comments_users_users_uid",
                        column: x => x.users_uid,
                        principalTable: "users",
                        principalColumn: "uid");
                });

            migrationBuilder.CreateTable(
                name: "subscriptions",
                columns: table => new
                {
                    uid = table.Column<Guid>(type: "uuid", nullable: false),
                    status_subscriptions = table.Column<string>(type: "text", nullable: false),
                    problems_uid = table.Column<Guid>(type: "uuid", nullable: true),
                    users_uid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_subscriptions", x => x.uid);
                    table.ForeignKey(
                        name: "fk_subscriptions_problems_problems_uid",
                        column: x => x.problems_uid,
                        principalTable: "problems",
                        principalColumn: "uid");
                    table.ForeignKey(
                        name: "fk_subscriptions_users_users_uid",
                        column: x => x.users_uid,
                        principalTable: "users",
                        principalColumn: "uid");
                });

            migrationBuilder.CreateIndex(
                name: "ix_categories_uid",
                table: "categories",
                column: "uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_comments_problems_uid",
                table: "comments",
                column: "problems_uid");

            migrationBuilder.CreateIndex(
                name: "ix_comments_uid",
                table: "comments",
                column: "uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_comments_users_uid",
                table: "comments",
                column: "users_uid");

            migrationBuilder.CreateIndex(
                name: "ix_languages_uid",
                table: "languages",
                column: "uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_problems_categories_uid",
                table: "problems",
                column: "categories_uid");

            migrationBuilder.CreateIndex(
                name: "ix_problems_languages_uid",
                table: "problems",
                column: "languages_uid");

            migrationBuilder.CreateIndex(
                name: "ix_problems_uid",
                table: "problems",
                column: "uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_subscriptions_problems_uid",
                table: "subscriptions",
                column: "problems_uid");

            migrationBuilder.CreateIndex(
                name: "ix_subscriptions_uid",
                table: "subscriptions",
                column: "uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_subscriptions_users_uid",
                table: "subscriptions",
                column: "users_uid");

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
