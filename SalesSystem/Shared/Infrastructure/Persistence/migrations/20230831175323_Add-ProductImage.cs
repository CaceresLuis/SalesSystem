using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SalesSystem.shared.infrastructure.persistence.migrations
{
    /// <inheritdoc />
    public partial class AddProductImage : Migration
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
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
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
                    { "c5012f7b-4cbc-4c66-a467-7fd5af53b57a", null, "Admin", "ADMIN" },
                    { "dd5eecad-2615-45b4-a3cf-40f262931194", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreateAt", "DeleteAt", "Email", "EmailConfirmed", "FirstName", "IsDeleted", "IsUpdated", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdateAt", "UserName" },
                values: new object[,]
                {
                    { "9eb3c88f-e2e1-4d83-8b03-ad506ed4e576", 0, "12975a81-15f5-42b8-a23b-2cc400f7291b", new DateTime(2023, 8, 31, 17, 53, 22, 623, DateTimeKind.Utc).AddTicks(6155), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luis@mail.com", false, "Luis", false, false, "Caceres", true, null, "LUIS@MAIL.COM", "LUIS@MAIL.COM", "AQAAAAIAAYagAAAAECB6cp6P6YggIwmj+zSYrG98N7L3hSSJ7UBTMI22eZIf9Xkgo8bptId8m7Ozf/Q/ig==", "7588-5214", false, "39f6cee6-90ab-40a7-b3b2-01a33db45763", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luis@mail.com" },
                    { "aec741be-ceb7-445f-9853-6ce750f2c607", 0, "369bd5f4-977e-4196-b328-312e3b768266", new DateTime(2023, 8, 31, 17, 53, 22, 623, DateTimeKind.Utc).AddTicks(6178), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Steven@mail.com", false, "Steven", false, false, "Caceres", true, null, "STEVEN@MAIL.COM", "STEVEN@MAIL.COM", "AQAAAAIAAYagAAAAEGjsVWxB6GhW9TB2w3BpuiUQceKDq4+IpZB2beM4eU9zfmuqeeLhkbnoFMwo3YhVGw==", "7588-5214", false, "8083a285-20fe-4f80-bc44-979d944aed7c", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Steven@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateAt", "DeleteAt", "IsDeleted", "IsUpdated", "Name", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("07e3a10c-f25e-4e29-93e4-96099c2e1b62"), new DateTime(2023, 8, 31, 17, 53, 22, 782, DateTimeKind.Utc).AddTicks(8713), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Libros y Entretenimiento", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0bfc609c-447d-453e-9ba4-49cd315026d7"), new DateTime(2023, 8, 31, 17, 53, 22, 782, DateTimeKind.Utc).AddTicks(8707), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Juguetes y Juegos", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("30ee5a65-32f9-4807-913e-79c0902ed954"), new DateTime(2023, 8, 31, 17, 53, 22, 782, DateTimeKind.Utc).AddTicks(8683), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Ropa y Accesorios", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7bcda787-3f97-4c4f-a48c-ab17c254cd33"), new DateTime(2023, 8, 31, 17, 53, 22, 782, DateTimeKind.Utc).AddTicks(8689), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Belleza y Cuidado Personal", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("84186444-d216-4129-bdb9-450bdfb5ed7a"), new DateTime(2023, 8, 31, 17, 53, 22, 782, DateTimeKind.Utc).AddTicks(8715), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Alimentación y Bebidas", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("846e4eab-676f-46f6-92b6-6e4b0df92c45"), new DateTime(2023, 8, 31, 17, 53, 22, 782, DateTimeKind.Utc).AddTicks(8691), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Deportes y Aire Libre", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9f1450be-b97a-48d1-be02-7746a3e6aa8d"), new DateTime(2023, 8, 31, 17, 53, 22, 782, DateTimeKind.Utc).AddTicks(8718), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Salud y Bienestar", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("be05452d-cde3-4a6f-b0fe-ae18c7b006c6"), new DateTime(2023, 8, 31, 17, 53, 22, 782, DateTimeKind.Utc).AddTicks(8686), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Hogar y Decoración", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d2a37980-a661-48a4-ac6e-65f6f2fe8cbf"), new DateTime(2023, 8, 31, 17, 53, 22, 782, DateTimeKind.Utc).AddTicks(8721), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Automóviles y Motocicletas", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ec818aee-633e-4089-aa36-1547155e2836"), new DateTime(2023, 8, 31, 17, 53, 22, 782, DateTimeKind.Utc).AddTicks(8674), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Electrónica", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreateAt", "DeleteAt", "Description", "IsDeleted", "IsUpdated", "Name", "Price", "Stock", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("0ac6a7da-e1c4-44df-8551-274ab3412183"), new DateTime(2023, 8, 31, 17, 53, 22, 782, DateTimeKind.Utc).AddTicks(8885), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Funda de asiento de cuero para automóvil Handao-Us", 75m, 56, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1332d295-52e2-4ddf-a6b2-2ec201e9bb11"), new DateTime(2023, 8, 31, 17, 53, 22, 782, DateTimeKind.Utc).AddTicks(8878), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Mascarilla facial Cucumber, de cuidado intensivo con ingredientes naturales", 234m, 529, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("197d5aa1-38ff-4f80-b7bc-1f9cf85db60a"), new DateTime(2023, 8, 31, 17, 53, 22, 782, DateTimeKind.Utc).AddTicks(8825), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Caja de té variado con sabores exóticos: Bigelow", 25m, 740, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("27767dd8-9a24-4d9b-a579-3a5e92a890cc"), new DateTime(2023, 8, 31, 17, 53, 22, 782, DateTimeKind.Utc).AddTicks(8793), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Cepillo alisador de cabello con tecnología iónica", 175m, 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("297ddc01-3c5d-44d7-bfaa-3ad36e96fb53"), new DateTime(2023, 8, 31, 17, 53, 22, 782, DateTimeKind.Utc).AddTicks(8804), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Juego de construcción LEGO Classic", 135m, 155, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3494e9a9-d49f-481f-90c8-336195121160"), new DateTime(2023, 8, 31, 17, 53, 22, 782, DateTimeKind.Utc).AddTicks(8887), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Casco de motocicleta de diseño aerodinámico y alta seguridad BCBKD", 125m, 142, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3bc2f28e-a49a-4d36-8117-8015e4caea66"), new DateTime(2023, 8, 31, 17, 53, 22, 782, DateTimeKind.Utc).AddTicks(8802), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Tienda de campaña resistente al agua para 4 personas", 423m, 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3d389ed0-e764-4c4d-bfd8-b5c94f9f9d20"), new DateTime(2023, 8, 31, 17, 53, 22, 782, DateTimeKind.Utc).AddTicks(8807), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Peluche suave y tierno de animalito", 45m, 525, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3e0b3723-ec2d-4dfa-8b34-6e61107a2042"), new DateTime(2023, 8, 31, 17, 53, 22, 782, DateTimeKind.Utc).AddTicks(8800), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Ropa deportiva para running, incluye camiseta y pantalones cortos", 355m, 64, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4d1370ac-3d88-44ba-8a64-039f5f4b1f36"), new DateTime(2023, 8, 31, 17, 53, 22, 782, DateTimeKind.Utc).AddTicks(8827), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Vino tinto reserva de una bodega Alavesas", 128m, 196, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5ba7b849-7e6f-469b-b796-4376116cf2d8"), new DateTime(2023, 8, 31, 17, 53, 22, 782, DateTimeKind.Utc).AddTicks(8776), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Bolso de cuero genuino con diseño elegante", 30m, 50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("64691c1a-7558-4583-891c-aa52547aff06"), new DateTime(2023, 8, 31, 17, 53, 22, 782, DateTimeKind.Utc).AddTicks(8781), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Juego de sábanas de algodón con diseño moderno", 255m, 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7738fddd-3b46-48e2-8295-0f5dfded87ba"), new DateTime(2023, 8, 31, 17, 53, 22, 782, DateTimeKind.Utc).AddTicks(8830), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Set de suplementos vitamínicos Arete, para la salud general", 129m, 504, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8172c711-bd72-438c-9502-7ef4ed280685"), new DateTime(2023, 8, 31, 17, 53, 22, 782, DateTimeKind.Utc).AddTicks(8778), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Juego de muebles de sala en tonos neutros", 720m, 78, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8979e7a4-52a0-4128-b02d-def5dd062bca"), new DateTime(2023, 8, 31, 17, 53, 22, 782, DateTimeKind.Utc).AddTicks(8815), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "CD de la banda sonora original de Greace", 21m, 485, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8aab0882-3ebd-4984-84ca-c60f6348db4a"), new DateTime(2023, 8, 31, 17, 53, 22, 782, DateTimeKind.Utc).AddTicks(8811), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Juego de mesa estratégico \"Catan\"", 120m, 85, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9c412375-70f7-447d-8507-c0363067624d"), new DateTime(2023, 8, 31, 17, 53, 22, 782, DateTimeKind.Utc).AddTicks(8767), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Camiseta de algodón con estampado floral", 40m, 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a1f465ed-46a0-491a-96d4-ad6a763a6468"), new DateTime(2023, 8, 31, 17, 53, 22, 782, DateTimeKind.Utc).AddTicks(8790), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Perfume floral y fresco para mujer", 85m, 75, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a3b9eca0-5298-4b83-9af0-9a6c8bdbc5bc"), new DateTime(2023, 8, 31, 17, 53, 22, 782, DateTimeKind.Utc).AddTicks(8783), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Lámpara de mesa de estilo industrial", 120m, 55, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ab7ff19d-fc3d-4bb1-a19d-2a10582fc5f0"), new DateTime(2023, 8, 31, 17, 53, 22, 782, DateTimeKind.Utc).AddTicks(8880), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Kit de limpieza y cuidado automotriz de calidad profesional Chemical Guys", 359m, 74, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b2cf7588-dea4-4825-b593-33646ba49fa7"), new DateTime(2023, 8, 31, 17, 53, 22, 782, DateTimeKind.Utc).AddTicks(8798), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Bicicleta de montaña todoterreno", 350m, 98, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c2b623b6-33d7-482c-9b65-e65cb38df321"), new DateTime(2023, 8, 31, 17, 53, 22, 782, DateTimeKind.Utc).AddTicks(8813), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Novela de suspenso \"La Chica del Tren\" de Paula Hawkins", 25m, 320, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ca2e2697-761b-4361-bf06-545e99cccf19"), new DateTime(2023, 8, 31, 17, 53, 22, 782, DateTimeKind.Utc).AddTicks(8876), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Dispositivo de seguimiento de actividad física y sueño", 98m, 127, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cdbe3ce9-1592-46d4-b98b-66cb14fa6c77"), new DateTime(2023, 8, 31, 17, 53, 22, 782, DateTimeKind.Utc).AddTicks(8822), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Selección de chocolates gourmet de diferentes países", 12m, 528, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d73a1484-7fd4-4736-a0de-2445283687a8"), new DateTime(2023, 8, 31, 17, 53, 22, 782, DateTimeKind.Utc).AddTicks(8772), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Pantalones vaqueros de corte ajustado", 25m, 210, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("da4ce4aa-c14a-41be-9359-6232dd97210e"), new DateTime(2023, 8, 31, 17, 53, 22, 782, DateTimeKind.Utc).AddTicks(8764), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Auriculares inalámbricos Sony WH-1000XM4", 120m, 520, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e6a79b88-7ecd-4d13-bbb9-7ad317a4749d"), new DateTime(2023, 8, 31, 17, 53, 22, 782, DateTimeKind.Utc).AddTicks(8761), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Laptop HP Pavilion 16", 1500m, 210, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f3209d12-652c-4d00-96ee-b2e67bd275b4"), new DateTime(2023, 8, 31, 17, 53, 22, 782, DateTimeKind.Utc).AddTicks(8787), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Set de maquillaje profesional de alta gama", 156m, 52, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f772c8db-bfbe-4eb2-8d6c-7cd8f4447253"), new DateTime(2023, 8, 31, 17, 53, 22, 782, DateTimeKind.Utc).AddTicks(8750), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Smartphone Samsung Galaxy S22", 525m, 255, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fe9f16b1-3c40-4ab7-a96d-68df023b4bd0"), new DateTime(2023, 8, 31, 17, 53, 22, 782, DateTimeKind.Utc).AddTicks(8820), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Videojuego de aventuras \"The Legend of Zelda: Breath of the Wild\"", 55m, 785, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "c5012f7b-4cbc-4c66-a467-7fd5af53b57a", "9eb3c88f-e2e1-4d83-8b03-ad506ed4e576" },
                    { "dd5eecad-2615-45b4-a3cf-40f262931194", "aec741be-ceb7-445f-9853-6ce750f2c607" }
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "UserId" },
                values: new object[,]
                {
                    { new Guid("b6a253ce-9b1d-4ec8-b959-cca2b308d01d"), "aec741be-ceb7-445f-9853-6ce750f2c607" },
                    { new Guid("b993ecc5-3d87-4169-8b10-90245f0b9780"), "9eb3c88f-e2e1-4d83-8b03-ad506ed4e576" }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 1, new Guid("ec818aee-633e-4089-aa36-1547155e2836"), new Guid("f772c8db-bfbe-4eb2-8d6c-7cd8f4447253") },
                    { 2, new Guid("ec818aee-633e-4089-aa36-1547155e2836"), new Guid("e6a79b88-7ecd-4d13-bbb9-7ad317a4749d") },
                    { 3, new Guid("ec818aee-633e-4089-aa36-1547155e2836"), new Guid("da4ce4aa-c14a-41be-9359-6232dd97210e") },
                    { 4, new Guid("30ee5a65-32f9-4807-913e-79c0902ed954"), new Guid("9c412375-70f7-447d-8507-c0363067624d") },
                    { 5, new Guid("30ee5a65-32f9-4807-913e-79c0902ed954"), new Guid("d73a1484-7fd4-4736-a0de-2445283687a8") },
                    { 6, new Guid("30ee5a65-32f9-4807-913e-79c0902ed954"), new Guid("5ba7b849-7e6f-469b-b796-4376116cf2d8") },
                    { 7, new Guid("be05452d-cde3-4a6f-b0fe-ae18c7b006c6"), new Guid("8172c711-bd72-438c-9502-7ef4ed280685") },
                    { 8, new Guid("be05452d-cde3-4a6f-b0fe-ae18c7b006c6"), new Guid("64691c1a-7558-4583-891c-aa52547aff06") },
                    { 9, new Guid("be05452d-cde3-4a6f-b0fe-ae18c7b006c6"), new Guid("a3b9eca0-5298-4b83-9af0-9a6c8bdbc5bc") },
                    { 10, new Guid("7bcda787-3f97-4c4f-a48c-ab17c254cd33"), new Guid("f3209d12-652c-4d00-96ee-b2e67bd275b4") },
                    { 11, new Guid("7bcda787-3f97-4c4f-a48c-ab17c254cd33"), new Guid("a1f465ed-46a0-491a-96d4-ad6a763a6468") },
                    { 12, new Guid("7bcda787-3f97-4c4f-a48c-ab17c254cd33"), new Guid("27767dd8-9a24-4d9b-a579-3a5e92a890cc") },
                    { 13, new Guid("846e4eab-676f-46f6-92b6-6e4b0df92c45"), new Guid("b2cf7588-dea4-4825-b593-33646ba49fa7") },
                    { 14, new Guid("846e4eab-676f-46f6-92b6-6e4b0df92c45"), new Guid("3e0b3723-ec2d-4dfa-8b34-6e61107a2042") },
                    { 15, new Guid("846e4eab-676f-46f6-92b6-6e4b0df92c45"), new Guid("3bc2f28e-a49a-4d36-8117-8015e4caea66") },
                    { 16, new Guid("0bfc609c-447d-453e-9ba4-49cd315026d7"), new Guid("297ddc01-3c5d-44d7-bfaa-3ad36e96fb53") },
                    { 17, new Guid("0bfc609c-447d-453e-9ba4-49cd315026d7"), new Guid("3d389ed0-e764-4c4d-bfd8-b5c94f9f9d20") },
                    { 18, new Guid("0bfc609c-447d-453e-9ba4-49cd315026d7"), new Guid("8aab0882-3ebd-4984-84ca-c60f6348db4a") },
                    { 19, new Guid("07e3a10c-f25e-4e29-93e4-96099c2e1b62"), new Guid("c2b623b6-33d7-482c-9b65-e65cb38df321") },
                    { 20, new Guid("07e3a10c-f25e-4e29-93e4-96099c2e1b62"), new Guid("8979e7a4-52a0-4128-b02d-def5dd062bca") },
                    { 21, new Guid("07e3a10c-f25e-4e29-93e4-96099c2e1b62"), new Guid("fe9f16b1-3c40-4ab7-a96d-68df023b4bd0") },
                    { 22, new Guid("84186444-d216-4129-bdb9-450bdfb5ed7a"), new Guid("cdbe3ce9-1592-46d4-b98b-66cb14fa6c77") },
                    { 23, new Guid("84186444-d216-4129-bdb9-450bdfb5ed7a"), new Guid("197d5aa1-38ff-4f80-b7bc-1f9cf85db60a") },
                    { 24, new Guid("84186444-d216-4129-bdb9-450bdfb5ed7a"), new Guid("4d1370ac-3d88-44ba-8a64-039f5f4b1f36") },
                    { 25, new Guid("9f1450be-b97a-48d1-be02-7746a3e6aa8d"), new Guid("7738fddd-3b46-48e2-8295-0f5dfded87ba") },
                    { 26, new Guid("9f1450be-b97a-48d1-be02-7746a3e6aa8d"), new Guid("ca2e2697-761b-4361-bf06-545e99cccf19") },
                    { 27, new Guid("9f1450be-b97a-48d1-be02-7746a3e6aa8d"), new Guid("1332d295-52e2-4ddf-a6b2-2ec201e9bb11") },
                    { 28, new Guid("d2a37980-a661-48a4-ac6e-65f6f2fe8cbf"), new Guid("ab7ff19d-fc3d-4bb1-a19d-2a10582fc5f0") },
                    { 29, new Guid("d2a37980-a661-48a4-ac6e-65f6f2fe8cbf"), new Guid("0ac6a7da-e1c4-44df-8551-274ab3412183") },
                    { 30, new Guid("d2a37980-a661-48a4-ac6e-65f6f2fe8cbf"), new Guid("3494e9a9-d49f-481f-90c8-336195121160") }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "ImageUrl", "ProductId" },
                values: new object[,]
                {
                    { new Guid("26acf99d-4704-42ef-a4f3-fbfe54a63834"), "/Shared/Infrastructure/Images/Products/CD de la banda sonora original de Greace", new Guid("8979e7a4-52a0-4128-b02d-def5dd062bca") },
                    { new Guid("427f6fe8-a100-4ec1-a5fe-4136200545eb"), "/Shared/Infrastructure/Images/Products/Lámpara de mesa de estilo industrial.jpg", new Guid("a3b9eca0-5298-4b83-9af0-9a6c8bdbc5bc") },
                    { new Guid("45ea1bd4-fe84-4639-b34b-b2c34952ad3e"), "/Shared/Infrastructure/Images/Products/Ropa deportiva para running.jpg", new Guid("3e0b3723-ec2d-4dfa-8b34-6e61107a2042") },
                    { new Guid("4d03bc49-71e2-441b-a6eb-95979c4d5f1a"), "/Shared/Infrastructure/Images/Products/Kit de limpieza y cuidado automotriz Chemical Guys.jpg", new Guid("ab7ff19d-fc3d-4bb1-a19d-2a10582fc5f0") },
                    { new Guid("5d5ab301-6974-4a45-865d-41ccb9856a89"), "/Shared/Infrastructure/Images/Products/The Legend of Zelda Breath of the Wild.jpg", new Guid("fe9f16b1-3c40-4ab7-a96d-68df023b4bd0") },
                    { new Guid("6163acda-8485-4a3b-9fb6-ffe614589271"), "/Shared/Infrastructure/Images/Products/Juego de muebles de sala en tonos neutros.jpg", new Guid("8172c711-bd72-438c-9502-7ef4ed280685") },
                    { new Guid("623b49e8-d596-490b-99c6-b278143dfc8f"), "/Shared/Infrastructure/Images/Products/Set de maquillaje profesional de alta gama.jpg", new Guid("f3209d12-652c-4d00-96ee-b2e67bd275b4") },
                    { new Guid("64a4755a-18b2-4cc0-b0d9-f02ad69ce0d9"), "/Shared/Infrastructure/Images/Products/Novela de suspenso La Chica del Tren de Paula Hawkins.jpg", new Guid("c2b623b6-33d7-482c-9b65-e65cb38df321") },
                    { new Guid("68f5b090-8d2f-4364-9dde-7f8083cc7d66"), "/Shared/Infrastructure/Images/Products/Pantalones vaqueros de corte ajustado.jpg", new Guid("d73a1484-7fd4-4736-a0de-2445283687a8") },
                    { new Guid("6955a283-ba84-4851-9837-0c030552c138"), "/Shared/Infrastructure/Images/Products/Bolso de cuero genuino con diseño elegante.jpg", new Guid("5ba7b849-7e6f-469b-b796-4376116cf2d8") },
                    { new Guid("7f1044ff-81d8-445a-a5d6-5c8b676482df"), "/Shared/Infrastructure/Images/Products/Cepillo alisador de cabello con tecnología iónica.jpg", new Guid("27767dd8-9a24-4d9b-a579-3a5e92a890cc") },
                    { new Guid("91f116e0-23fc-495a-b07e-789ec2cc1b0b"), "/Shared/Infrastructure/Images/Products/Juego de sábanas de algodón con diseño moderno.jpg", new Guid("64691c1a-7558-4583-891c-aa52547aff06") },
                    { new Guid("93a5f220-9bd1-4cc6-a5a4-1d602554fca9"), "/Shared/Infrastructure/Images/Products/Dispositivo de seguimiento de actividad física y sueño.jpg", new Guid("ca2e2697-761b-4361-bf06-545e99cccf19") },
                    { new Guid("9c2415a4-0060-4da0-abe9-23a9f9330e7b"), "/Shared/Infrastructure/Images/Products/Funda de asiento de cuero Handao-Us.jpg", new Guid("0ac6a7da-e1c4-44df-8551-274ab3412183") },
                    { new Guid("a20b86b5-83e4-4059-9150-a5b29f8c2689"), "/Shared/Infrastructure/Images/Products/Juego de mesa estratégico Catan.jpg", new Guid("8aab0882-3ebd-4984-84ca-c60f6348db4a") },
                    { new Guid("a5a3bcee-f350-498a-9a83-237d86ffc64f"), "/Shared/Infrastructure/Images/Products/Bicicleta de montaña todoterreno.jpg", new Guid("b2cf7588-dea4-4825-b593-33646ba49fa7") },
                    { new Guid("aaccdc04-c1b1-40c6-8a97-a89f360d68be"), "/Shared/Infrastructure/Images/Products/Caja de té variado Bigelow.jpg", new Guid("197d5aa1-38ff-4f80-b7bc-1f9cf85db60a") },
                    { new Guid("ad754911-87f7-4c08-ae39-ed0b186548de"), "/Shared/Infrastructure/Images/Products/Mascarilla facial Cucumber.jpg", new Guid("1332d295-52e2-4ddf-a6b2-2ec201e9bb11") },
                    { new Guid("b18a7575-d6ce-49a1-9fa3-0de4b116222b"), "/Shared/Infrastructure/Images/Products/Casco de motocicleta BCBKD.jpg", new Guid("3494e9a9-d49f-481f-90c8-336195121160") },
                    { new Guid("cca5c6e8-0a44-4179-9ce2-93851db99a72"), "/Shared/Infrastructure/Images/Products/Camiseta de algodón con estampado floral.jpg", new Guid("9c412375-70f7-447d-8507-c0363067624d") },
                    { new Guid("d03338f3-cda5-42f5-a841-297ae299e88a"), "/Shared/Infrastructure/Images/Products/Vino tinto reserva de una bodega Alavesas.jpg", new Guid("4d1370ac-3d88-44ba-8a64-039f5f4b1f36") },
                    { new Guid("d1b2dbea-e67c-45f0-9987-79a2d574c224"), "/Shared/Infrastructure/Images/Products/Juego de construcción LEGO Classic.jpg", new Guid("297ddc01-3c5d-44d7-bfaa-3ad36e96fb53") },
                    { new Guid("d5fa2691-61b2-4e04-bb20-a3732e3289b1"), "/Shared/Infrastructure/Images/Products/Perfume floral y fresco para mujer.jpg", new Guid("a1f465ed-46a0-491a-96d4-ad6a763a6468") },
                    { new Guid("d6844e4b-f67c-4ec4-8995-4bc33963799b"), "/Shared/Infrastructure/Images/Products/Laptop HP Pavilion 16.jpg", new Guid("e6a79b88-7ecd-4d13-bbb9-7ad317a4749d") },
                    { new Guid("d75e7808-d92b-4696-9146-5b7e2414c87d"), "/Shared/Infrastructure/Images/Products/chocolates gourmet de diferentes países.jpg", new Guid("cdbe3ce9-1592-46d4-b98b-66cb14fa6c77") },
                    { new Guid("dfa8872c-1da8-45d3-bffb-0fd35ecfce46"), "/Shared/Infrastructure/Images/Products/Smartphone Samsung Galaxy S22.jpg", new Guid("f772c8db-bfbe-4eb2-8d6c-7cd8f4447253") },
                    { new Guid("e2b15f33-8813-4c1b-b79d-952cc7f1fb91"), "/Shared/Infrastructure/Images/Products/Peluche suave y tierno de animalito.jpg", new Guid("3d389ed0-e764-4c4d-bfd8-b5c94f9f9d20") },
                    { new Guid("e54b38bc-310d-41c7-bdf2-cbf33dcd6e30"), "/Shared/Infrastructure/Images/Products/Suplementos vitamínicos arete.jpg", new Guid("7738fddd-3b46-48e2-8295-0f5dfded87ba") },
                    { new Guid("e65b370f-e7e7-4bf2-a02c-8dc07740a447"), "/Shared/Infrastructure/Images/Products/Tienda de campaña resistente al agua para 4 personas.jpg", new Guid("3bc2f28e-a49a-4d36-8117-8015e4caea66") },
                    { new Guid("fc9b46f5-1dda-4cdd-899b-1f2972b697f6"), "/Shared/Infrastructure/Images/Products/Auriculares inalámbricos Sony WH-1000XM4.jpg", new Guid("da4ce4aa-c14a-41be-9359-6232dd97210e") }
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
                name: "IX_ProductCategories_CategoryId",
                table: "ProductCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_ProductId",
                table: "ProductCategories",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
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
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "ProductImages");

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
