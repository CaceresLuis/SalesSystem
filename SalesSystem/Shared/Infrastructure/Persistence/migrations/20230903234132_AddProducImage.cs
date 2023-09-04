using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SalesSystem.shared.infrastructure.persistence.migrations
{
    /// <inheritdoc />
    public partial class AddProducImage : Migration
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
                    FirstName = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    LastName = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    PhoneNumber = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: true),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeleteAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsUpdated = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
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
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsUpdated = table.Column<bool>(type: "boolean", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Price = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    Stock = table.Column<int>(type: "integer", maxLength: 4, nullable: false),
                    CreateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsUpdated = table.Column<bool>(type: "boolean", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleteAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
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
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
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
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
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
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserAddres",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Department = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    AddressSpecific = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAddres_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserCards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    CardNumber = table.Column<string>(type: "text", nullable: false),
                    OwnerCard = table.Column<string>(type: "text", nullable: false),
                    ExpiredDate = table.Column<string>(type: "text", nullable: false),
                    CVC = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCards_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Buys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    Qty = table.Column<int>(type: "integer", nullable: false),
                    DateBuy = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buys_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Buys_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: true),
                    ImageUrl = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: true),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductCategories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TempCartItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: true),
                    TempUser = table.Column<Guid>(type: "uuid", nullable: false),
                    Qty = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TempCartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TempCartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: true),
                    CartId = table.Column<Guid>(type: "uuid", nullable: true),
                    Qty = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3958470b-9398-4a82-82ab-ffb5bf79a7f5", null, "Admin", "ADMIN" },
                    { "56ab6f8b-35fb-49cd-856d-39d67fcc4a68", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreateAt", "DeleteAt", "Email", "EmailConfirmed", "FirstName", "IsDeleted", "IsUpdated", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdateAt", "UserName" },
                values: new object[,]
                {
                    { "9ca44540-450e-4c48-97c9-df5ab5ee88ee", 0, "472b8a87-3bd1-4bad-9893-4e37a1723277", new DateTime(2023, 9, 3, 23, 41, 31, 802, DateTimeKind.Utc).AddTicks(8295), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Steven@mail.com", false, "Steven", false, false, "Caceres", true, null, "STEVEN@MAIL.COM", "STEVEN@MAIL.COM", "AQAAAAIAAYagAAAAEJ8ED7UihyrnSuaw/w2Lu+DmKYtZYaKgaLduWOfbeSfX8jsxmf7vLKTkXLhZX75lnw==", "7588-5214", false, "779773c2-e31f-4b6d-b568-0cfb87697193", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Steven@mail.com" },
                    { "cfbef3a1-333e-484f-b6ce-4f3f5d6c63ce", 0, "9bbd3535-4c2c-4590-ab22-fac16c498cb5", new DateTime(2023, 9, 3, 23, 41, 31, 802, DateTimeKind.Utc).AddTicks(8129), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luis@mail.com", false, "Luis", false, false, "Caceres", true, null, "LUIS@MAIL.COM", "LUIS@MAIL.COM", "AQAAAAIAAYagAAAAEFQfGFfpPcCCHshDUiT37yakLx9K66Fpf4LnuRrVZeyw/5QglwwH3WIHOvjFZUHE0Q==", "7588-5214", false, "1d6d0cb6-0e8f-4f65-8a64-6c9c26852151", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luis@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateAt", "DeleteAt", "IsDeleted", "IsUpdated", "Name", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("0bf0847b-d6b4-4db7-b484-b26df76fb28a"), new DateTime(2023, 9, 3, 23, 41, 32, 145, DateTimeKind.Utc).AddTicks(2590), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Automóviles y Motocicletas", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1ddb8031-20bf-42a1-b309-04b0ab613aae"), new DateTime(2023, 9, 3, 23, 41, 32, 145, DateTimeKind.Utc).AddTicks(2579), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Alimentación y Bebidas", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1ede711d-0e00-4190-a1e7-1a629625ce5f"), new DateTime(2023, 9, 3, 23, 41, 32, 145, DateTimeKind.Utc).AddTicks(2557), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Deportes y Aire Libre", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6398607b-7a6b-4521-996e-74bcfbb3fd51"), new DateTime(2023, 9, 3, 23, 41, 32, 145, DateTimeKind.Utc).AddTicks(2534), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Belleza y Cuidado Personal", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6990ff30-a496-4f7d-bb63-1e342a52a9d0"), new DateTime(2023, 9, 3, 23, 41, 32, 145, DateTimeKind.Utc).AddTicks(2570), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Juguetes y Juegos", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8b03b56d-b6be-46d6-87bf-2056a4d4047e"), new DateTime(2023, 9, 3, 23, 41, 32, 145, DateTimeKind.Utc).AddTicks(2575), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Libros y Entretenimiento", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b3f6c2cb-084c-4037-93a2-eefda27d4e47"), new DateTime(2023, 9, 3, 23, 41, 32, 145, DateTimeKind.Utc).AddTicks(2502), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Electrónica", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b8a977ba-138e-4f5e-ac7a-b3af30b4337b"), new DateTime(2023, 9, 3, 23, 41, 32, 145, DateTimeKind.Utc).AddTicks(2529), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Hogar y Decoración", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d0a72eac-45b1-4522-aeee-a55bb0c32a86"), new DateTime(2023, 9, 3, 23, 41, 32, 145, DateTimeKind.Utc).AddTicks(2525), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Ropa y Accesorios", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ef251957-ad4e-49b8-bf26-3003f6219904"), new DateTime(2023, 9, 3, 23, 41, 32, 145, DateTimeKind.Utc).AddTicks(2583), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Salud y Bienestar", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreateAt", "DeleteAt", "Description", "IsDeleted", "IsUpdated", "Name", "Price", "Stock", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("0b535a49-8f14-4cc9-b707-4ae6e0d0470d"), new DateTime(2023, 9, 3, 23, 41, 32, 145, DateTimeKind.Utc).AddTicks(3138), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Ropa deportiva para running, incluye camiseta y pantalones cortos", 355m, 64, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0c7a4ae7-0b39-4cde-b094-15cde554e47f"), new DateTime(2023, 9, 3, 23, 41, 32, 145, DateTimeKind.Utc).AddTicks(3188), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Selección de chocolates gourmet de diferentes países", 12m, 528, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("134e84f1-decc-47d3-ae86-022a304218db"), new DateTime(2023, 9, 3, 23, 41, 32, 145, DateTimeKind.Utc).AddTicks(3148), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Juego de construcción LEGO Classic", 135m, 155, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1be672cd-3664-4055-93cc-e59422fed135"), new DateTime(2023, 9, 3, 23, 41, 32, 145, DateTimeKind.Utc).AddTicks(3133), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Bicicleta de montaña todoterreno", 350m, 98, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1ec7f116-cc7c-4450-aa87-792ac4b5ad6a"), new DateTime(2023, 9, 3, 23, 41, 32, 145, DateTimeKind.Utc).AddTicks(2888), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Set de maquillaje profesional de alta gama", 156m, 52, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2560c15e-6c45-4244-8cef-a0c88a244c23"), new DateTime(2023, 9, 3, 23, 41, 32, 145, DateTimeKind.Utc).AddTicks(3225), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Funda de asiento de cuero para automóvil", 75m, 56, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("399724bb-1ac0-45ce-8c71-71b879636a9b"), new DateTime(2023, 9, 3, 23, 41, 32, 145, DateTimeKind.Utc).AddTicks(3201), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Set de suplementos vitamínicos para la salud general", 129m, 504, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4b2b4004-2b1e-4757-89cd-79f099f945d6"), new DateTime(2023, 9, 3, 23, 41, 32, 145, DateTimeKind.Utc).AddTicks(3220), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Kit de limpieza y cuidado automotriz de calidad profesional", 359m, 74, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("52587219-25e8-4b74-8a90-5f566db822b4"), new DateTime(2023, 9, 3, 23, 41, 32, 145, DateTimeKind.Utc).AddTicks(2859), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Pantalones vaqueros de corte ajustado", 25m, 210, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("575ccf27-1107-4dcb-9a9d-62450a4ca6da"), new DateTime(2023, 9, 3, 23, 41, 32, 145, DateTimeKind.Utc).AddTicks(3206), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Dispositivo de seguimiento de actividad física y sueño", 98m, 127, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("65c76211-bc25-4bc6-9c5a-8b7139dd851a"), new DateTime(2023, 9, 3, 23, 41, 32, 145, DateTimeKind.Utc).AddTicks(3162), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Juego de mesa estratégico \"Catan\"", 120m, 85, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("66d1db62-597b-435f-8d2b-dfb03e413c57"), new DateTime(2023, 9, 3, 23, 41, 32, 145, DateTimeKind.Utc).AddTicks(3215), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Mascarilla facial de cuidado intensivo con ingredientes naturales", 234m, 529, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6fa4ec16-d4b7-4911-8c27-ddafbeba3bca"), new DateTime(2023, 9, 3, 23, 41, 32, 145, DateTimeKind.Utc).AddTicks(2802), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Smartphone Samsung Galaxy S22", 525m, 255, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("76d94a0d-5c49-45a0-a4c3-78bc9c8c69e4"), new DateTime(2023, 9, 3, 23, 41, 32, 145, DateTimeKind.Utc).AddTicks(3238), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Casco de motocicleta de diseño aerodinámico y alta seguridad", 125m, 142, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("850b80ad-b010-42ac-9315-a472aae8f68a"), new DateTime(2023, 9, 3, 23, 41, 32, 145, DateTimeKind.Utc).AddTicks(3178), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "CD de la banda sonora original de una película popular", 21m, 485, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8c6e6381-308d-47e3-b03d-c00c05e60829"), new DateTime(2023, 9, 3, 23, 41, 32, 145, DateTimeKind.Utc).AddTicks(2877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Juego de sábanas de algodón con diseño moderno", 255m, 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8d28269f-0ceb-4a08-ac80-0216e591d1b2"), new DateTime(2023, 9, 3, 23, 41, 32, 145, DateTimeKind.Utc).AddTicks(3183), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Videojuego de aventuras \"The Legend of Zelda: Breath of the Wild\"", 55m, 785, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9855e282-fbbf-48da-b4c7-28360a4d289a"), new DateTime(2023, 9, 3, 23, 41, 32, 145, DateTimeKind.Utc).AddTicks(2903), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Cepillo alisador de cabello con tecnología iónica", 175m, 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9f4e3e8a-d329-4035-b9b5-aed7134e010f"), new DateTime(2023, 9, 3, 23, 41, 32, 145, DateTimeKind.Utc).AddTicks(2867), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Bolso de cuero genuino con diseño elegante", 30m, 50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a91470f3-d7eb-401d-9748-42b1eac343d8"), new DateTime(2023, 9, 3, 23, 41, 32, 145, DateTimeKind.Utc).AddTicks(2837), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Laptop HP Pavilion 16", 1500m, 210, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ad17c611-b992-4122-ab8c-ea663e3b651f"), new DateTime(2023, 9, 3, 23, 41, 32, 145, DateTimeKind.Utc).AddTicks(3192), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Caja de té variado con sabores exóticos", 25m, 740, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b6b8357d-da2b-4b01-8aaf-1cd2821cfeef"), new DateTime(2023, 9, 3, 23, 41, 32, 145, DateTimeKind.Utc).AddTicks(2855), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Camiseta de algodón con estampado floral", 40m, 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b6d4f303-dd86-4b13-8fef-5da04206dc6c"), new DateTime(2023, 9, 3, 23, 41, 32, 145, DateTimeKind.Utc).AddTicks(2872), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Juego de muebles de sala en tonos neutros", 720m, 78, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bd89d1ab-d43e-4030-81be-80bafd9db27f"), new DateTime(2023, 9, 3, 23, 41, 32, 145, DateTimeKind.Utc).AddTicks(3143), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Tienda de campaña resistente al agua para 4 personas", 423m, 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bf6d0c96-1b7f-4c32-88ab-9386285ac732"), new DateTime(2023, 9, 3, 23, 41, 32, 145, DateTimeKind.Utc).AddTicks(2850), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Auriculares inalámbricos Sony WH-1000XM4", 120m, 520, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d0584496-48ac-42f3-bf12-cb76b464af97"), new DateTime(2023, 9, 3, 23, 41, 32, 145, DateTimeKind.Utc).AddTicks(3153), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Peluche suave y tierno de animalito", 45m, 525, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d25aeb5e-bb2b-436f-b3c2-780bc7f73a14"), new DateTime(2023, 9, 3, 23, 41, 32, 145, DateTimeKind.Utc).AddTicks(3197), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Vino tinto reserva de una bodega reconocida", 128m, 196, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e5daabef-d638-40c6-8278-8fdff3860b4c"), new DateTime(2023, 9, 3, 23, 41, 32, 145, DateTimeKind.Utc).AddTicks(3173), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Novela de suspenso \"La Chica del Tren\" de Paula Hawkins", 25m, 320, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e6eece15-e7b2-4baa-a6a3-fb0ad481dede"), new DateTime(2023, 9, 3, 23, 41, 32, 145, DateTimeKind.Utc).AddTicks(2881), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Lámpara de mesa de estilo industrial", 120m, 55, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fb4ea868-30ca-4e5f-8343-1dec213682a5"), new DateTime(2023, 9, 3, 23, 41, 32, 145, DateTimeKind.Utc).AddTicks(2898), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Perfume floral y fresco para mujer", 85m, 75, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "56ab6f8b-35fb-49cd-856d-39d67fcc4a68", "9ca44540-450e-4c48-97c9-df5ab5ee88ee" },
                    { "3958470b-9398-4a82-82ab-ffb5bf79a7f5", "cfbef3a1-333e-484f-b6ce-4f3f5d6c63ce" }
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "UserId" },
                values: new object[,]
                {
                    { new Guid("515c175f-3808-42db-b843-1b5ab89a294c"), "9ca44540-450e-4c48-97c9-df5ab5ee88ee" },
                    { new Guid("790512c0-58a2-43e4-af02-dc110b86dd51"), "cfbef3a1-333e-484f-b6ce-4f3f5d6c63ce" }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 1, new Guid("b3f6c2cb-084c-4037-93a2-eefda27d4e47"), new Guid("6fa4ec16-d4b7-4911-8c27-ddafbeba3bca") },
                    { 2, new Guid("b3f6c2cb-084c-4037-93a2-eefda27d4e47"), new Guid("a91470f3-d7eb-401d-9748-42b1eac343d8") },
                    { 3, new Guid("b3f6c2cb-084c-4037-93a2-eefda27d4e47"), new Guid("bf6d0c96-1b7f-4c32-88ab-9386285ac732") },
                    { 4, new Guid("d0a72eac-45b1-4522-aeee-a55bb0c32a86"), new Guid("b6b8357d-da2b-4b01-8aaf-1cd2821cfeef") },
                    { 5, new Guid("d0a72eac-45b1-4522-aeee-a55bb0c32a86"), new Guid("52587219-25e8-4b74-8a90-5f566db822b4") },
                    { 6, new Guid("d0a72eac-45b1-4522-aeee-a55bb0c32a86"), new Guid("9f4e3e8a-d329-4035-b9b5-aed7134e010f") },
                    { 7, new Guid("b8a977ba-138e-4f5e-ac7a-b3af30b4337b"), new Guid("b6d4f303-dd86-4b13-8fef-5da04206dc6c") },
                    { 8, new Guid("b8a977ba-138e-4f5e-ac7a-b3af30b4337b"), new Guid("8c6e6381-308d-47e3-b03d-c00c05e60829") },
                    { 9, new Guid("b8a977ba-138e-4f5e-ac7a-b3af30b4337b"), new Guid("e6eece15-e7b2-4baa-a6a3-fb0ad481dede") },
                    { 10, new Guid("6398607b-7a6b-4521-996e-74bcfbb3fd51"), new Guid("1ec7f116-cc7c-4450-aa87-792ac4b5ad6a") },
                    { 11, new Guid("6398607b-7a6b-4521-996e-74bcfbb3fd51"), new Guid("fb4ea868-30ca-4e5f-8343-1dec213682a5") },
                    { 12, new Guid("6398607b-7a6b-4521-996e-74bcfbb3fd51"), new Guid("9855e282-fbbf-48da-b4c7-28360a4d289a") },
                    { 13, new Guid("1ede711d-0e00-4190-a1e7-1a629625ce5f"), new Guid("1be672cd-3664-4055-93cc-e59422fed135") },
                    { 14, new Guid("1ede711d-0e00-4190-a1e7-1a629625ce5f"), new Guid("0b535a49-8f14-4cc9-b707-4ae6e0d0470d") },
                    { 15, new Guid("1ede711d-0e00-4190-a1e7-1a629625ce5f"), new Guid("bd89d1ab-d43e-4030-81be-80bafd9db27f") },
                    { 16, new Guid("6990ff30-a496-4f7d-bb63-1e342a52a9d0"), new Guid("134e84f1-decc-47d3-ae86-022a304218db") },
                    { 17, new Guid("6990ff30-a496-4f7d-bb63-1e342a52a9d0"), new Guid("d0584496-48ac-42f3-bf12-cb76b464af97") },
                    { 18, new Guid("6990ff30-a496-4f7d-bb63-1e342a52a9d0"), new Guid("65c76211-bc25-4bc6-9c5a-8b7139dd851a") },
                    { 19, new Guid("8b03b56d-b6be-46d6-87bf-2056a4d4047e"), new Guid("e5daabef-d638-40c6-8278-8fdff3860b4c") },
                    { 20, new Guid("8b03b56d-b6be-46d6-87bf-2056a4d4047e"), new Guid("850b80ad-b010-42ac-9315-a472aae8f68a") },
                    { 21, new Guid("8b03b56d-b6be-46d6-87bf-2056a4d4047e"), new Guid("8d28269f-0ceb-4a08-ac80-0216e591d1b2") },
                    { 22, new Guid("1ddb8031-20bf-42a1-b309-04b0ab613aae"), new Guid("0c7a4ae7-0b39-4cde-b094-15cde554e47f") },
                    { 23, new Guid("1ddb8031-20bf-42a1-b309-04b0ab613aae"), new Guid("ad17c611-b992-4122-ab8c-ea663e3b651f") },
                    { 24, new Guid("1ddb8031-20bf-42a1-b309-04b0ab613aae"), new Guid("d25aeb5e-bb2b-436f-b3c2-780bc7f73a14") },
                    { 25, new Guid("ef251957-ad4e-49b8-bf26-3003f6219904"), new Guid("399724bb-1ac0-45ce-8c71-71b879636a9b") },
                    { 26, new Guid("ef251957-ad4e-49b8-bf26-3003f6219904"), new Guid("575ccf27-1107-4dcb-9a9d-62450a4ca6da") },
                    { 27, new Guid("ef251957-ad4e-49b8-bf26-3003f6219904"), new Guid("66d1db62-597b-435f-8d2b-dfb03e413c57") },
                    { 28, new Guid("0bf0847b-d6b4-4db7-b484-b26df76fb28a"), new Guid("4b2b4004-2b1e-4757-89cd-79f099f945d6") },
                    { 29, new Guid("0bf0847b-d6b4-4db7-b484-b26df76fb28a"), new Guid("2560c15e-6c45-4244-8cef-a0c88a244c23") },
                    { 30, new Guid("0bf0847b-d6b4-4db7-b484-b26df76fb28a"), new Guid("76d94a0d-5c49-45a0-a4c3-78bc9c8c69e4") }
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
                name: "IX_Buys_ProductId",
                table: "Buys",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Buys_UserId",
                table: "Buys",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductId",
                table: "Images",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CategoryId",
                table: "ProductCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_ProductId",
                table: "ProductCategories",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TempCartItems_ProductId",
                table: "TempCartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddres_UserId",
                table: "UserAddres",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCards_UserId",
                table: "UserCards",
                column: "UserId");
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
                name: "Buys");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "TempCartItems");

            migrationBuilder.DropTable(
                name: "UserAddres");

            migrationBuilder.DropTable(
                name: "UserCards");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
