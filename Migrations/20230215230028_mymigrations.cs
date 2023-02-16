using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace mscontrolefinanceiro.Migrations
{
    /// <inheritdoc />
    public partial class mymigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "log",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user = table.Column<string>(type: "text", nullable: false),
                    value = table.Column<double>(type: "double precision", nullable: false),
                    transitiontype = table.Column<string>(name: "transition_type", type: "text", nullable: false),
                    transitiondate = table.Column<DateTime>(name: "transition_date", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_log", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userlogin = table.Column<string>(name: "user_login", type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    birth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    work = table.Column<string>(type: "text", nullable: false),
                    expectedsalary = table.Column<double>(name: "expected_salary", type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "balance",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userid = table.Column<int>(name: "user_id", type: "integer", nullable: false),
                    value = table.Column<double>(type: "double precision", nullable: false),
                    lastupdate = table.Column<DateTime>(name: "last_update", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_balance", x => x.id);
                    table.ForeignKey(
                        name: "FK_balance_user_user_id",
                        column: x => x.userid,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "input",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userid = table.Column<int>(name: "user_id", type: "integer", nullable: false),
                    value = table.Column<double>(type: "double precision", nullable: false),
                    inputdate = table.Column<DateTime>(name: "input_date", type: "timestamp with time zone", nullable: false),
                    tobankaccount = table.Column<string>(name: "to_bank_account", type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_input", x => x.id);
                    table.ForeignKey(
                        name: "FK_input_user_user_id",
                        column: x => x.userid,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "output",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userid = table.Column<int>(name: "user_id", type: "integer", nullable: false),
                    value = table.Column<double>(type: "double precision", nullable: false),
                    outputdate = table.Column<DateTime>(name: "output_date", type: "timestamp with time zone", nullable: false),
                    referingto = table.Column<string>(name: "refering_to", type: "text", nullable: false),
                    hasinterest = table.Column<bool>(name: "has_interest", type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_output", x => x.id);
                    table.ForeignKey(
                        name: "FK_output_user_user_id",
                        column: x => x.userid,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_balance_user_id",
                table: "balance",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_input_user_id",
                table: "input",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_output_user_id",
                table: "output",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "balance");

            migrationBuilder.DropTable(
                name: "input");

            migrationBuilder.DropTable(
                name: "log");

            migrationBuilder.DropTable(
                name: "output");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
