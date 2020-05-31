using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SecondTask.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankUserTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    CreditorId = table.Column<string>(nullable: false),
                    DebitorId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankUserTransactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Amount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0", 0, 1000, "2c180c47-599a-4d5e-a340-855648ef6192", "user0@user.ma", false, false, null, "user0@user.ma", null, "AQAAAAEAACcQAAAAEN/iWfjEn5JcMklpXuQwKdGCBZPyFZIZPyeOusJT8xt8tU9JNMTFnxnNDXOJmLsZlg==", null, false, "71d92b13-3926-4e67-86ed-48a99d3c2012", false, "user 0" },
                    { "1", 0, 1000, "86f657b9-a034-49c3-a682-c33683f95388", "user1@user.ma", false, false, null, "user1@user.ma", null, "AQAAAAEAACcQAAAAECFTF+E3tGpKdu0tS+Hqg9wLIJSFWdRDhKds/ia97HNWrCjRV5Tp2oxhbqX/vGM4QA==", null, false, "b117215e-17f5-45bc-9e09-6ae55ce6fa28", false, "user 1" },
                    { "2", 0, 1000, "64735e6e-9045-4864-9eac-ecc518f4878f", "user2@user.ma", false, false, null, "user2@user.ma", null, "AQAAAAEAACcQAAAAEFLKfdxlCJZbBaeL5Cop+2Z81ZJKynwnxAw4Dl6WEdio4NuB7tFnz3+fNbzfWxmGww==", null, false, "8cfb2ff7-fe07-48f9-864e-d6dca647803d", false, "user 2" },
                    { "3", 0, 1000, "0e6ab433-5700-42a0-afa2-628a38b7dd88", "user3@user.ma", false, false, null, "user3@user.ma", null, "AQAAAAEAACcQAAAAENhf30pTRBe+9A8PHAQlyaVGPrMuKOt7KK+t0o0O4fAJ/AcInwCzWveJNBHv6VxVqg==", null, false, "b1ad4a4c-d74f-4e8e-8338-f781ff82b433", false, "user 3" },
                    { "4", 0, 1000, "a36c73f0-8993-430e-8348-2dafb64a96ea", "user4@user.ma", false, false, null, "user4@user.ma", null, "AQAAAAEAACcQAAAAEPr12vKc5Gwszc8PRVt+FmILwuGzfwSd8Wo3IIIuUtuNj1GmunGWzLjwu1XcnBTBDg==", null, false, "6595df45-f935-4e68-b93c-2338777e6094", false, "user 4" },
                    { "5", 0, 1000, "3582c96e-45c4-4fbc-bea2-1f7666adea61", "user5@user.ma", false, false, null, "user5@user.ma", null, "AQAAAAEAACcQAAAAEAqmdJZiCjlgqnb5s9fUAaXKQZ7+G1E92mNpKRPWWASwY1Djp/oJlEx6DCa3ZH7Nmw==", null, false, "c88c8314-9d7d-40ce-9d31-fad8598d0de4", false, "user 5" },
                    { "6", 0, 1000, "ad7eacd5-5d1b-4eb5-87cc-129bb4bc2f52", "user6@user.ma", false, false, null, "user6@user.ma", null, "AQAAAAEAACcQAAAAEL1xaHi3EOG94ENH32PxlNg9oweZgEJMBOaqkpITUZCWBajClz0W9nmFqpMO0pYwsg==", null, false, "ccab243c-580e-44c3-a08d-7daebd5406e7", false, "user 6" },
                    { "7", 0, 1000, "f3d4ca02-9e24-4379-925a-447d93be9231", "user7@user.ma", false, false, null, "user7@user.ma", null, "AQAAAAEAACcQAAAAEEQ3OpHGsBg1tAn7x+JjHgmYC4H9deBDmCu+vm8DQrisf7H4pGUM3saV7f10nwfCbA==", null, false, "8f1aca07-e54e-4d33-b82c-f81eec21682d", false, "user 7" },
                    { "8", 0, 1000, "61960215-0ab4-45f8-a708-284541cf4e94", "user8@user.ma", false, false, null, "user8@user.ma", null, "AQAAAAEAACcQAAAAEB6uSNykeBmTVGyN6aTk77l0q6jiJmhUjpMeMT3scmhlKQSbe/VgdcPddyn3mOw8SA==", null, false, "eb424ace-edc4-40f2-81b2-ba285927fa17", false, "user 8" },
                    { "9", 0, 1000, "10888979-10c6-4857-8983-e071aacc2351", "user9@user.ma", false, false, null, "user9@user.ma", null, "AQAAAAEAACcQAAAAEL8JHJYJX2my2K0q0biLm7fEy2S+GwQVfm2Zt0lrSl+/WhDi4OP8uSrwdZnfIZYjTA==", null, false, "b43218b5-6974-4fb6-bf6d-9010cb4a5276", false, "user 9" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BankUserTransactions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
