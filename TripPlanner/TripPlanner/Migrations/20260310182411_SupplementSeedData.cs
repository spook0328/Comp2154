using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TripPlanner.Migrations
{
    /// <inheritdoc />
    public partial class SupplementSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "countries",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CountryName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CountryLanguage = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Latitude = table.Column<decimal>(type: "numeric(9,6)", nullable: false),
                    Longitude = table.Column<decimal>(type: "numeric(9,6)", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    PlaceId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
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
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
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
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "itineraries",
                columns: table => new
                {
                    itinerary_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    CountryId = table.Column<int>(type: "integer", nullable: true),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_itineraries", x => x.itinerary_id);
                    table.ForeignKey(
                        name: "FK_itineraries_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_itineraries_countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "phrases",
                columns: table => new
                {
                    PhraseId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CountryId = table.Column<int>(type: "integer", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    Translation = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phrases", x => x.PhraseId);
                    table.ForeignKey(
                        name: "FK_phrases_countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "itinerary_items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ItineraryId = table.Column<int>(type: "integer", nullable: false),
                    LocationId = table.Column<int>(type: "integer", nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StopOrder = table.Column<int>(type: "integer", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_itinerary_items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_itinerary_items_itineraries_ItineraryId",
                        column: x => x.ItineraryId,
                        principalTable: "itineraries",
                        principalColumn: "itinerary_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_itinerary_items_locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "countries",
                columns: new[] { "CountryId", "CountryLanguage", "CountryName" },
                values: new object[,]
                {
                    { 1, "French", "France" },
                    { 2, "Persian (Farsi)", "Iran" },
                    { 3, "Mandarin", "China/Taiwan" },
                    { 4, "Japanese", "Japan" }
                });

            migrationBuilder.InsertData(
                table: "itineraries",
                columns: new[] { "itinerary_id", "CountryId", "Description", "EndDate", "StartDate", "Title", "UserId" },
                values: new object[] { 2, null, null, new DateTime(2026, 6, 14, 9, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 3, 15, 9, 0, 0, 0, DateTimeKind.Utc), "Second Trip", null });

            migrationBuilder.InsertData(
                table: "locations",
                columns: new[] { "Id", "Address", "Description", "Latitude", "Longitude", "Name", "PlaceId" },
                values: new object[,]
                {
                    { 1, "N/A For Test", null, 45.504537m, -73.556094m, "Notre-Dame Basilica", null },
                    { 2, "Isfahan, Isfahan Province, Iran", null, 32.65745m, 51.677778m, "Naqsh-e Jahan Square", null },
                    { 3, "Yuchi Township, Nantou County, Taiwan", null, 23.866667m, 120.916667m, "Sun Moon Lake", null },
                    { 4, "Tuojiang Town, Fenghuang County, Xiangxi Tujia and Miao Autonomous Prefecture of Hunan Province", null, 27.952822m, 109.600989m, "Fenghuang Ancient City", null }
                });

            migrationBuilder.InsertData(
                table: "itineraries",
                columns: new[] { "itinerary_id", "CountryId", "Description", "EndDate", "StartDate", "Title", "UserId" },
                values: new object[] { 1, 1, null, new DateTime(2026, 3, 14, 9, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 1, 15, 9, 0, 0, 0, DateTimeKind.Utc), "First Trip", null });

            migrationBuilder.InsertData(
                table: "itinerary_items",
                columns: new[] { "Id", "EndDateTime", "ItineraryId", "LocationId", "Note", "StartDateTime", "StopOrder" },
                values: new object[,]
                {
                    { 3, new DateTime(2026, 4, 15, 9, 0, 0, 0, DateTimeKind.Utc), 2, 3, null, new DateTime(2026, 3, 16, 9, 0, 0, 0, DateTimeKind.Utc), 1 },
                    { 4, new DateTime(2026, 5, 15, 9, 0, 0, 0, DateTimeKind.Utc), 2, 4, null, new DateTime(2026, 4, 16, 9, 0, 0, 0, DateTimeKind.Utc), 2 },
                    { 5, new DateTime(2026, 6, 1, 9, 0, 0, 0, DateTimeKind.Utc), 2, 4, null, new DateTime(2026, 5, 16, 9, 0, 0, 0, DateTimeKind.Utc), 3 }
                });

            migrationBuilder.InsertData(
                table: "phrases",
                columns: new[] { "PhraseId", "Content", "CountryId", "Translation" },
                values: new object[,]
                {
                    { 1, "Bonjour", 1, "Hello" },
                    { 2, "Merci", 1, "Thank you" },
                    { 3, "Où sont les toilettes ?", 1, "Where is the restroom?" },
                    { 4, "Combien ça coûte ?", 1, "How much is it?" },
                    { 5, "سلام", 2, "Hello" },
                    { 6, "متشکرم", 2, "Thank you" },
                    { 7, "سرویس بهداشتی کجاست؟", 2, "Where is the restroom?" },
                    { 8, "این چقدر است؟", 2, "How much is it?" },
                    { 9, "你好", 3, "Hello" },
                    { 10, "谢谢", 3, "Thank you" },
                    { 11, "请问卫生间在哪？", 3, "Where is the restroom?" },
                    { 12, "这个多少钱？", 3, "How much is it?" },
                    { 13, "こんにちは", 4, "Hello" },
                    { 14, "ありがとう", 4, "Thank you" }
                });

            migrationBuilder.InsertData(
                table: "itinerary_items",
                columns: new[] { "Id", "EndDateTime", "ItineraryId", "LocationId", "Note", "StartDateTime", "StopOrder" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 2, 15, 9, 0, 0, 0, DateTimeKind.Utc), 1, 1, null, new DateTime(2026, 1, 16, 9, 0, 0, 0, DateTimeKind.Utc), 1 },
                    { 2, new DateTime(2026, 3, 15, 9, 0, 0, 0, DateTimeKind.Utc), 1, 2, null, new DateTime(2026, 2, 16, 9, 0, 0, 0, DateTimeKind.Utc), 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_itineraries_CountryId",
                table: "itineraries",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_itineraries_UserId",
                table: "itineraries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_itinerary_items_ItineraryId",
                table: "itinerary_items",
                column: "ItineraryId");

            migrationBuilder.CreateIndex(
                name: "IX_itinerary_items_LocationId",
                table: "itinerary_items",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_phrases_CountryId",
                table: "phrases",
                column: "CountryId");
        }

        /// <inheritdoc />
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
                name: "itinerary_items");

            migrationBuilder.DropTable(
                name: "phrases");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "itineraries");

            migrationBuilder.DropTable(
                name: "locations");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "countries");
        }
    }
}
