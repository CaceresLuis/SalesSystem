using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SalesSystem.shared.infrastructure.persistence.migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
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
                    { "33dd9490-b282-442c-9c39-cf29438958cb", null, "Admin", "ADMIN" },
                    { "a2b68619-72d3-4e06-9f76-8d1ecc4f8a8d", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreateAt", "DeleteAt", "Email", "EmailConfirmed", "FirstName", "IsDeleted", "IsUpdated", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdateAt", "UserName" },
                values: new object[,]
                {
                    { "054e4b8e-41e6-4e56-8053-836e0e48bf56", 0, "3c43e4fa-a7fa-4a52-a6c2-e7c18af5377a", new DateTime(2023, 8, 8, 19, 27, 46, 912, DateTimeKind.Utc).AddTicks(1663), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Steven@mail.com", false, "Steven", false, false, "Caceres", true, null, "STEVEN@MAIL.COM", "STEVEN@MAIL.COM", "AQAAAAIAAYagAAAAEOmvpw+QF4EBiluhgKLfmQASp7mMzCYVI+3MINkdszsbr/tGVsjPEtBV5o/w4kC+dw==", "7588-5214", false, "7669c0de-fe05-4811-842c-5a5255386bcf", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Steven@mail.com" },
                    { "bd2883b5-77f0-424b-96cd-6ac5684a5ac7", 0, "92ce6918-9943-467f-983d-36132f73bfbf", new DateTime(2023, 8, 8, 19, 27, 46, 912, DateTimeKind.Utc).AddTicks(1640), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luis@mail.com", false, "Luis", false, false, "Caceres", true, null, "LUIS@MAIL.COM", "LUIS@MAIL.COM", "AQAAAAIAAYagAAAAENGW4RsNkZV/2kahC+7TeLBxf3h27k0ICDX6dusvWUar24kD0TQh8YSoSjjb2oWqCQ==", "7588-5214", false, "542c73ea-23b8-4c78-b526-fd5c35bef806", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luis@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateAt", "DeleteAt", "IsDeleted", "IsUpdated", "Name", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("12b37f05-6e66-4ea3-bb69-db2ccb6336d4"), new DateTime(2023, 8, 8, 19, 27, 47, 68, DateTimeKind.Utc).AddTicks(6692), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Juguetes y Juegos", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("30f14cb8-c302-4726-abe4-2879f19de710"), new DateTime(2023, 8, 8, 19, 27, 47, 68, DateTimeKind.Utc).AddTicks(6669), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Belleza y Cuidado Personal", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3c06e5c4-2eaf-47e8-831f-4db013d321c2"), new DateTime(2023, 8, 8, 19, 27, 47, 68, DateTimeKind.Utc).AddTicks(6703), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Automóviles y Motocicletas", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6786fe63-0bcb-4ec0-9021-ec33280b92ee"), new DateTime(2023, 8, 8, 19, 27, 47, 68, DateTimeKind.Utc).AddTicks(6667), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Hogar y Decoración", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("693e5cc1-cb3d-48c4-b2a0-9fa39d71e236"), new DateTime(2023, 8, 8, 19, 27, 47, 68, DateTimeKind.Utc).AddTicks(6654), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Electrónica", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9b17e98a-3caa-4b39-8bd2-2a0276f82bff"), new DateTime(2023, 8, 8, 19, 27, 47, 68, DateTimeKind.Utc).AddTicks(6664), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Ropa y Accesorios", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9f0d86b1-de22-4b78-86fe-cd6d789a04f3"), new DateTime(2023, 8, 8, 19, 27, 47, 68, DateTimeKind.Utc).AddTicks(6672), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Deportes y Aire Libre", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b04aed84-2e64-45c4-8e12-2c791c32c745"), new DateTime(2023, 8, 8, 19, 27, 47, 68, DateTimeKind.Utc).AddTicks(6697), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Alimentación y Bebidas", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c0a7d006-79dd-42c9-9870-06b133379100"), new DateTime(2023, 8, 8, 19, 27, 47, 68, DateTimeKind.Utc).AddTicks(6699), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Salud y Bienestar", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d7dbf899-3414-48a5-83c4-b481346bc4bd"), new DateTime(2023, 8, 8, 19, 27, 47, 68, DateTimeKind.Utc).AddTicks(6695), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Libros y Entretenimiento", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreateAt", "DeleteAt", "Description", "IsDeleted", "IsUpdated", "Name", "Price", "Stock", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("24322aa9-981e-4b68-98fd-b20adb4ede8c"), new DateTime(2023, 8, 8, 19, 27, 47, 68, DateTimeKind.Utc).AddTicks(6861), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Caja de té variado con sabores exóticos", 25m, 740, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("33104112-4553-45cd-ad22-92f4a5aa65cb"), new DateTime(2023, 8, 8, 19, 27, 47, 68, DateTimeKind.Utc).AddTicks(6805), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "CD de la banda sonora original de una película popular", 21m, 485, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("445c33af-154f-4fa3-9ba0-5d4c1f5a7ae6"), new DateTime(2023, 8, 8, 19, 27, 47, 68, DateTimeKind.Utc).AddTicks(6768), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Juego de sábanas de algodón con diseño moderno", 255m, 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4b515335-7056-496c-b9ac-2a0267a15260"), new DateTime(2023, 8, 8, 19, 27, 47, 68, DateTimeKind.Utc).AddTicks(6865), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Set de suplementos vitamínicos para la salud general", 129m, 504, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("64ab19bb-6f95-4faf-8eeb-3f653c5de3be"), new DateTime(2023, 8, 8, 19, 27, 47, 68, DateTimeKind.Utc).AddTicks(6766), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Juego de muebles de sala en tonos neutros", 720m, 78, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("672dde91-593d-419e-8378-2b492dc949ec"), new DateTime(2023, 8, 8, 19, 27, 47, 68, DateTimeKind.Utc).AddTicks(6870), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Mascarilla facial de cuidado intensivo con ingredientes naturales", 234m, 529, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("693d1fd0-e20a-4a70-9ad3-48f0d4e9702e"), new DateTime(2023, 8, 8, 19, 27, 47, 68, DateTimeKind.Utc).AddTicks(6863), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Vino tinto reserva de una bodega reconocida", 128m, 196, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6e1ed3bb-bb35-4575-b95b-769ad20f3011"), new DateTime(2023, 8, 8, 19, 27, 47, 68, DateTimeKind.Utc).AddTicks(6868), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Dispositivo de seguimiento de actividad física y sueño", 98m, 127, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6e4af7f1-1834-4172-80cb-423a17f53156"), new DateTime(2023, 8, 8, 19, 27, 47, 68, DateTimeKind.Utc).AddTicks(6789), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Tienda de campaña resistente al agua para 4 personas", 423m, 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7bf65104-2f90-4a74-9ccd-f24fcf043ed3"), new DateTime(2023, 8, 8, 19, 27, 47, 68, DateTimeKind.Utc).AddTicks(6787), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Ropa deportiva para running, incluye camiseta y pantalones cortos", 355m, 64, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7f8f2e1c-6fe3-495a-a928-cd4cc358e672"), new DateTime(2023, 8, 8, 19, 27, 47, 68, DateTimeKind.Utc).AddTicks(6771), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Lámpara de mesa de estilo industrial", 120m, 55, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7faf6a1f-624d-4ad6-ac67-9dadf68004d5"), new DateTime(2023, 8, 8, 19, 27, 47, 68, DateTimeKind.Utc).AddTicks(6858), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Selección de chocolates gourmet de diferentes países", 12m, 528, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("83533894-3f1b-41a4-a2eb-209df1794e45"), new DateTime(2023, 8, 8, 19, 27, 47, 68, DateTimeKind.Utc).AddTicks(6758), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Camiseta de algodón con estampado floral", 40m, 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("86c185af-6c8a-4d65-8432-3b55d4cefda3"), new DateTime(2023, 8, 8, 19, 27, 47, 68, DateTimeKind.Utc).AddTicks(6794), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Peluche suave y tierno de animalito", 45m, 525, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("90a53564-89a6-4b00-9c69-3eae19238c7c"), new DateTime(2023, 8, 8, 19, 27, 47, 68, DateTimeKind.Utc).AddTicks(6797), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Juego de mesa estratégico \"Catan\"", 120m, 85, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("91e69c7b-d3d6-42a9-a50a-0034215c9307"), new DateTime(2023, 8, 8, 19, 27, 47, 68, DateTimeKind.Utc).AddTicks(6800), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Novela de suspenso \"La Chica del Tren\" de Paula Hawkins", 25m, 320, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9375d24c-ac8d-4ed0-ac0a-c9a74a8d7c10"), new DateTime(2023, 8, 8, 19, 27, 47, 68, DateTimeKind.Utc).AddTicks(6791), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Juego de construcción LEGO Classic", 135m, 155, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ae7e70df-c20f-4e72-b0df-986163a188c9"), new DateTime(2023, 8, 8, 19, 27, 47, 68, DateTimeKind.Utc).AddTicks(6879), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Funda de asiento de cuero para automóvil", 75m, 56, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b53a0e27-0012-4e3f-b9db-ce90b870ad22"), new DateTime(2023, 8, 8, 19, 27, 47, 68, DateTimeKind.Utc).AddTicks(6875), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Kit de limpieza y cuidado automotriz de calidad profesional", 359m, 74, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c7ce60e1-0c54-4986-8aa1-8a2c48632169"), new DateTime(2023, 8, 8, 19, 27, 47, 68, DateTimeKind.Utc).AddTicks(6784), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Bicicleta de montaña todoterreno", 350m, 98, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c985b233-8abd-4fe6-8aff-c726403d83fe"), new DateTime(2023, 8, 8, 19, 27, 47, 68, DateTimeKind.Utc).AddTicks(6750), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Laptop HP Pavilion 16", 1500m, 210, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cb591e57-012b-4a61-86a4-ba405fd7200a"), new DateTime(2023, 8, 8, 19, 27, 47, 68, DateTimeKind.Utc).AddTicks(6764), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Bolso de cuero genuino con diseño elegante", 30m, 50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cc2bb4bc-afa1-4885-85d8-bf06f30df65c"), new DateTime(2023, 8, 8, 19, 27, 47, 68, DateTimeKind.Utc).AddTicks(6740), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Smartphone Samsung Galaxy S22", 525m, 255, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("de1eecb2-0aa9-4ce9-a77b-bd47511e6c12"), new DateTime(2023, 8, 8, 19, 27, 47, 68, DateTimeKind.Utc).AddTicks(6807), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Videojuego de aventuras \"The Legend of Zelda: Breath of the Wild\"", 55m, 785, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("de6ee507-3556-4590-b07a-4863d1734f2a"), new DateTime(2023, 8, 8, 19, 27, 47, 68, DateTimeKind.Utc).AddTicks(6752), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Auriculares inalámbricos Sony WH-1000XM4", 120m, 520, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("dfe60aa0-ec1a-4c67-b766-bbb5439e90a7"), new DateTime(2023, 8, 8, 19, 27, 47, 68, DateTimeKind.Utc).AddTicks(6881), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Casco de motocicleta de diseño aerodinámico y alta seguridad", 125m, 142, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f1c626f4-8b63-4b31-9c9b-376b53fc8a31"), new DateTime(2023, 8, 8, 19, 27, 47, 68, DateTimeKind.Utc).AddTicks(6782), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Cepillo alisador de cabello con tecnología iónica", 175m, 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f653cb8f-2225-45d3-b3a1-a745bf14223c"), new DateTime(2023, 8, 8, 19, 27, 47, 68, DateTimeKind.Utc).AddTicks(6775), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Set de maquillaje profesional de alta gama", 156m, 52, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fb9a4a25-4d10-4393-9ad8-54b1ad8e2b6e"), new DateTime(2023, 8, 8, 19, 27, 47, 68, DateTimeKind.Utc).AddTicks(6777), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Perfume floral y fresco para mujer", 85m, 75, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fe573588-ab29-4ef8-bf41-0a9b8d957039"), new DateTime(2023, 8, 8, 19, 27, 47, 68, DateTimeKind.Utc).AddTicks(6760), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Pantalones vaqueros de corte ajustado", 25m, 210, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "a2b68619-72d3-4e06-9f76-8d1ecc4f8a8d", "054e4b8e-41e6-4e56-8053-836e0e48bf56" },
                    { "33dd9490-b282-442c-9c39-cf29438958cb", "bd2883b5-77f0-424b-96cd-6ac5684a5ac7" }
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "UserId" },
                values: new object[,]
                {
                    { new Guid("2a81a774-05df-4050-917e-e10076f7196e"), "bd2883b5-77f0-424b-96cd-6ac5684a5ac7" },
                    { new Guid("f9d82921-5531-426f-971e-241f6074a920"), "054e4b8e-41e6-4e56-8053-836e0e48bf56" }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 1, new Guid("693e5cc1-cb3d-48c4-b2a0-9fa39d71e236"), new Guid("cc2bb4bc-afa1-4885-85d8-bf06f30df65c") },
                    { 2, new Guid("693e5cc1-cb3d-48c4-b2a0-9fa39d71e236"), new Guid("c985b233-8abd-4fe6-8aff-c726403d83fe") },
                    { 3, new Guid("693e5cc1-cb3d-48c4-b2a0-9fa39d71e236"), new Guid("de6ee507-3556-4590-b07a-4863d1734f2a") },
                    { 4, new Guid("9b17e98a-3caa-4b39-8bd2-2a0276f82bff"), new Guid("83533894-3f1b-41a4-a2eb-209df1794e45") },
                    { 5, new Guid("9b17e98a-3caa-4b39-8bd2-2a0276f82bff"), new Guid("fe573588-ab29-4ef8-bf41-0a9b8d957039") },
                    { 6, new Guid("9b17e98a-3caa-4b39-8bd2-2a0276f82bff"), new Guid("cb591e57-012b-4a61-86a4-ba405fd7200a") },
                    { 7, new Guid("6786fe63-0bcb-4ec0-9021-ec33280b92ee"), new Guid("64ab19bb-6f95-4faf-8eeb-3f653c5de3be") },
                    { 8, new Guid("6786fe63-0bcb-4ec0-9021-ec33280b92ee"), new Guid("445c33af-154f-4fa3-9ba0-5d4c1f5a7ae6") },
                    { 9, new Guid("6786fe63-0bcb-4ec0-9021-ec33280b92ee"), new Guid("7f8f2e1c-6fe3-495a-a928-cd4cc358e672") },
                    { 10, new Guid("30f14cb8-c302-4726-abe4-2879f19de710"), new Guid("f653cb8f-2225-45d3-b3a1-a745bf14223c") },
                    { 11, new Guid("30f14cb8-c302-4726-abe4-2879f19de710"), new Guid("fb9a4a25-4d10-4393-9ad8-54b1ad8e2b6e") },
                    { 12, new Guid("30f14cb8-c302-4726-abe4-2879f19de710"), new Guid("f1c626f4-8b63-4b31-9c9b-376b53fc8a31") },
                    { 13, new Guid("9f0d86b1-de22-4b78-86fe-cd6d789a04f3"), new Guid("c7ce60e1-0c54-4986-8aa1-8a2c48632169") },
                    { 14, new Guid("9f0d86b1-de22-4b78-86fe-cd6d789a04f3"), new Guid("7bf65104-2f90-4a74-9ccd-f24fcf043ed3") },
                    { 15, new Guid("9f0d86b1-de22-4b78-86fe-cd6d789a04f3"), new Guid("6e4af7f1-1834-4172-80cb-423a17f53156") },
                    { 16, new Guid("12b37f05-6e66-4ea3-bb69-db2ccb6336d4"), new Guid("9375d24c-ac8d-4ed0-ac0a-c9a74a8d7c10") },
                    { 17, new Guid("12b37f05-6e66-4ea3-bb69-db2ccb6336d4"), new Guid("86c185af-6c8a-4d65-8432-3b55d4cefda3") },
                    { 18, new Guid("12b37f05-6e66-4ea3-bb69-db2ccb6336d4"), new Guid("90a53564-89a6-4b00-9c69-3eae19238c7c") },
                    { 19, new Guid("d7dbf899-3414-48a5-83c4-b481346bc4bd"), new Guid("91e69c7b-d3d6-42a9-a50a-0034215c9307") },
                    { 20, new Guid("d7dbf899-3414-48a5-83c4-b481346bc4bd"), new Guid("33104112-4553-45cd-ad22-92f4a5aa65cb") },
                    { 21, new Guid("d7dbf899-3414-48a5-83c4-b481346bc4bd"), new Guid("de1eecb2-0aa9-4ce9-a77b-bd47511e6c12") },
                    { 22, new Guid("b04aed84-2e64-45c4-8e12-2c791c32c745"), new Guid("7faf6a1f-624d-4ad6-ac67-9dadf68004d5") },
                    { 23, new Guid("b04aed84-2e64-45c4-8e12-2c791c32c745"), new Guid("24322aa9-981e-4b68-98fd-b20adb4ede8c") },
                    { 24, new Guid("b04aed84-2e64-45c4-8e12-2c791c32c745"), new Guid("693d1fd0-e20a-4a70-9ad3-48f0d4e9702e") },
                    { 25, new Guid("c0a7d006-79dd-42c9-9870-06b133379100"), new Guid("4b515335-7056-496c-b9ac-2a0267a15260") },
                    { 26, new Guid("c0a7d006-79dd-42c9-9870-06b133379100"), new Guid("6e1ed3bb-bb35-4575-b95b-769ad20f3011") },
                    { 27, new Guid("c0a7d006-79dd-42c9-9870-06b133379100"), new Guid("672dde91-593d-419e-8378-2b492dc949ec") },
                    { 28, new Guid("3c06e5c4-2eaf-47e8-831f-4db013d321c2"), new Guid("b53a0e27-0012-4e3f-b9db-ce90b870ad22") },
                    { 29, new Guid("3c06e5c4-2eaf-47e8-831f-4db013d321c2"), new Guid("ae7e70df-c20f-4e72-b0df-986163a188c9") },
                    { 30, new Guid("3c06e5c4-2eaf-47e8-831f-4db013d321c2"), new Guid("dfe60aa0-ec1a-4c67-b766-bbb5439e90a7") }
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
