using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SalesSystem.shared.infrastructure.persistence.migrations
{
    /// <inheritdoc />
    public partial class TempUserCart : Migration
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
                    { "c506c0ae-d06e-4d5d-a57d-433c63245883", null, "Admin", "ADMIN" },
                    { "cbbaac48-603d-4004-907b-f9fb1020309c", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreateAt", "DeleteAt", "Email", "EmailConfirmed", "FirstName", "IsDeleted", "IsUpdated", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdateAt", "UserName" },
                values: new object[,]
                {
                    { "7a39b716-9943-4abc-accf-8783b13c18af", 0, "f72acdd5-a570-4311-b75a-ed3c97e7f82f", new DateTime(2023, 8, 17, 3, 40, 5, 567, DateTimeKind.Utc).AddTicks(1385), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Steven@mail.com", false, "Steven", false, false, "Caceres", true, null, "STEVEN@MAIL.COM", "STEVEN@MAIL.COM", "AQAAAAIAAYagAAAAELgTBbYM6wZcZENVtLGLaJRwDeU53Krhbgn0JakmjfYDSsXc/yGMOS6XuPT/G97MIA==", "7588-5214", false, "1928f58d-e995-4d71-bcdc-dc75fbe24d60", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Steven@mail.com" },
                    { "93bd6f5d-6af9-45b1-b996-ee198fb746ab", 0, "d43c2d37-7167-4713-8f9c-d930f99f986a", new DateTime(2023, 8, 17, 3, 40, 5, 567, DateTimeKind.Utc).AddTicks(1362), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luis@mail.com", false, "Luis", false, false, "Caceres", true, null, "LUIS@MAIL.COM", "LUIS@MAIL.COM", "AQAAAAIAAYagAAAAEJBfwcHnXM09w53eH74bKv3XIC5bk05qTuV8Eg8k0VfhSvU7MzVJmFTPKUTbifvH7w==", "7588-5214", false, "455dbdd5-65a8-48de-ae11-083352ba2038", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luis@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateAt", "DeleteAt", "IsDeleted", "IsUpdated", "Name", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("1e2ad49d-7a99-4ad5-9f75-45bca7c4db77"), new DateTime(2023, 8, 17, 3, 40, 5, 737, DateTimeKind.Utc).AddTicks(4344), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Belleza y Cuidado Personal", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("36739425-1f4b-4eac-843c-0afb7ae019a0"), new DateTime(2023, 8, 17, 3, 40, 5, 737, DateTimeKind.Utc).AddTicks(4342), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Hogar y Decoración", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3ea92e81-dd91-4bda-88b8-025bf4e19bb0"), new DateTime(2023, 8, 17, 3, 40, 5, 737, DateTimeKind.Utc).AddTicks(4374), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Juguetes y Juegos", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("645fdc3a-b59e-44d9-8b1b-803571621af9"), new DateTime(2023, 8, 17, 3, 40, 5, 737, DateTimeKind.Utc).AddTicks(4380), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Salud y Bienestar", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a463d0fe-1ed9-4165-bf9b-a76c6f012cfd"), new DateTime(2023, 8, 17, 3, 40, 5, 737, DateTimeKind.Utc).AddTicks(4339), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Ropa y Accesorios", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("afd4f956-fc03-408c-8f2f-c348bb583184"), new DateTime(2023, 8, 17, 3, 40, 5, 737, DateTimeKind.Utc).AddTicks(4378), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Alimentación y Bebidas", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d5e1613b-61bc-4583-8cad-d05818b9ab8e"), new DateTime(2023, 8, 17, 3, 40, 5, 737, DateTimeKind.Utc).AddTicks(4376), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Libros y Entretenimiento", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e5cb1954-be90-4594-8db6-3eac4f6fdf52"), new DateTime(2023, 8, 17, 3, 40, 5, 737, DateTimeKind.Utc).AddTicks(4357), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Deportes y Aire Libre", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f755e198-179c-4791-92be-a6b4f2359b8b"), new DateTime(2023, 8, 17, 3, 40, 5, 737, DateTimeKind.Utc).AddTicks(4329), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Electrónica", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("fa2c0a85-c2f7-4ebd-95a0-511d74e95cca"), new DateTime(2023, 8, 17, 3, 40, 5, 737, DateTimeKind.Utc).AddTicks(4384), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Automóviles y Motocicletas", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreateAt", "DeleteAt", "Description", "IsDeleted", "IsUpdated", "Name", "Price", "Stock", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("091dafe0-7e5a-47d1-bdd5-9871ca447c93"), new DateTime(2023, 8, 17, 3, 40, 5, 737, DateTimeKind.Utc).AddTicks(4649), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Selección de chocolates gourmet de diferentes países", 12m, 528, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("26520101-3a7a-4e33-99b3-165d0a0b9436"), new DateTime(2023, 8, 17, 3, 40, 5, 737, DateTimeKind.Utc).AddTicks(4488), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Juego de construcción LEGO Classic", 135m, 155, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2f72df20-229f-44be-ba2f-6b8e344cb690"), new DateTime(2023, 8, 17, 3, 40, 5, 737, DateTimeKind.Utc).AddTicks(4461), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Juego de muebles de sala en tonos neutros", 720m, 78, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("38772743-0756-4077-ad8d-40c34f7279e7"), new DateTime(2023, 8, 17, 3, 40, 5, 737, DateTimeKind.Utc).AddTicks(4454), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Pantalones vaqueros de corte ajustado", 25m, 210, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4ea174ca-fc53-456e-bf9a-49eb1b871010"), new DateTime(2023, 8, 17, 3, 40, 5, 737, DateTimeKind.Utc).AddTicks(4491), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Peluche suave y tierno de animalito", 45m, 525, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("56ba067d-63c5-4dc4-b880-47737cf00b1d"), new DateTime(2023, 8, 17, 3, 40, 5, 737, DateTimeKind.Utc).AddTicks(4659), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Dispositivo de seguimiento de actividad física y sueño", 98m, 127, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5f3b91ca-feb4-4ac0-bc78-b7b789ceea62"), new DateTime(2023, 8, 17, 3, 40, 5, 737, DateTimeKind.Utc).AddTicks(4480), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Bicicleta de montaña todoterreno", 350m, 98, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("658655e0-2126-41af-8df7-e7cc34facdde"), new DateTime(2023, 8, 17, 3, 40, 5, 737, DateTimeKind.Utc).AddTicks(4670), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Funda de asiento de cuero para automóvil", 75m, 56, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("71a124f3-136d-4f40-95c2-945b5b3edf01"), new DateTime(2023, 8, 17, 3, 40, 5, 737, DateTimeKind.Utc).AddTicks(4486), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Tienda de campaña resistente al agua para 4 personas", 423m, 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("71c645cc-6bfe-4f0e-9262-aaaf09d368a5"), new DateTime(2023, 8, 17, 3, 40, 5, 737, DateTimeKind.Utc).AddTicks(4452), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Camiseta de algodón con estampado floral", 40m, 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7a7ecb1e-c7f9-47ac-bf8e-5ee76e6ce623"), new DateTime(2023, 8, 17, 3, 40, 5, 737, DateTimeKind.Utc).AddTicks(4638), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Novela de suspenso \"La Chica del Tren\" de Paula Hawkins", 25m, 320, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7cfbe4d7-1e5d-4797-bbf7-af19a03920be"), new DateTime(2023, 8, 17, 3, 40, 5, 737, DateTimeKind.Utc).AddTicks(4652), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Caja de té variado con sabores exóticos", 25m, 740, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("82a42560-99aa-48b0-8a58-e43b68c25e4f"), new DateTime(2023, 8, 17, 3, 40, 5, 737, DateTimeKind.Utc).AddTicks(4469), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Set de maquillaje profesional de alta gama", 156m, 52, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("837fcb93-492c-4808-8121-f8b8a2ceec0f"), new DateTime(2023, 8, 17, 3, 40, 5, 737, DateTimeKind.Utc).AddTicks(4450), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Auriculares inalámbricos Sony WH-1000XM4", 120m, 520, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("878e6080-c5a3-428e-a030-0031c6e80dcd"), new DateTime(2023, 8, 17, 3, 40, 5, 737, DateTimeKind.Utc).AddTicks(4646), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Videojuego de aventuras \"The Legend of Zelda: Breath of the Wild\"", 55m, 785, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a814df1f-461e-43b9-99c6-2bdfa0e93de1"), new DateTime(2023, 8, 17, 3, 40, 5, 737, DateTimeKind.Utc).AddTicks(4458), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Bolso de cuero genuino con diseño elegante", 30m, 50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ab6cfb55-0836-486a-bdbb-c416ca73d98b"), new DateTime(2023, 8, 17, 3, 40, 5, 737, DateTimeKind.Utc).AddTicks(4644), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "CD de la banda sonora original de una película popular", 21m, 485, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b1941ffa-9f4b-4a4d-8b96-ebf9830b9ed7"), new DateTime(2023, 8, 17, 3, 40, 5, 737, DateTimeKind.Utc).AddTicks(4477), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Cepillo alisador de cabello con tecnología iónica", 175m, 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b7b7cb67-09b9-40b3-90ef-386ce01f8f71"), new DateTime(2023, 8, 17, 3, 40, 5, 737, DateTimeKind.Utc).AddTicks(4664), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Mascarilla facial de cuidado intensivo con ingredientes naturales", 234m, 529, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b9f73587-1dee-4477-959c-f0b3b29d2098"), new DateTime(2023, 8, 17, 3, 40, 5, 737, DateTimeKind.Utc).AddTicks(4463), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Juego de sábanas de algodón con diseño moderno", 255m, 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c5d547c0-cdc1-43c3-b273-6df9f26b9410"), new DateTime(2023, 8, 17, 3, 40, 5, 737, DateTimeKind.Utc).AddTicks(4443), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Laptop HP Pavilion 16", 1500m, 210, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c92afc07-b66c-437e-81ed-208a9d8d02ba"), new DateTime(2023, 8, 17, 3, 40, 5, 737, DateTimeKind.Utc).AddTicks(4433), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Smartphone Samsung Galaxy S22", 525m, 255, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ce88b4d5-d95d-4993-96ff-fd346a56eb37"), new DateTime(2023, 8, 17, 3, 40, 5, 737, DateTimeKind.Utc).AddTicks(4666), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Kit de limpieza y cuidado automotriz de calidad profesional", 359m, 74, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d7c93dda-e972-4bc6-b69b-e7e0ffe2ec1b"), new DateTime(2023, 8, 17, 3, 40, 5, 737, DateTimeKind.Utc).AddTicks(4657), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Set de suplementos vitamínicos para la salud general", 129m, 504, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d7cc4571-67fb-4358-bf3c-56e7448c1f23"), new DateTime(2023, 8, 17, 3, 40, 5, 737, DateTimeKind.Utc).AddTicks(4482), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Ropa deportiva para running, incluye camiseta y pantalones cortos", 355m, 64, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("dc0c5b56-5689-410d-bc24-24c9cd103113"), new DateTime(2023, 8, 17, 3, 40, 5, 737, DateTimeKind.Utc).AddTicks(4475), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Perfume floral y fresco para mujer", 85m, 75, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("dcd48f9a-560b-424e-a8c6-da9978b07414"), new DateTime(2023, 8, 17, 3, 40, 5, 737, DateTimeKind.Utc).AddTicks(4676), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Casco de motocicleta de diseño aerodinámico y alta seguridad", 125m, 142, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("dde91dc3-296a-4707-98c0-74edfba5b570"), new DateTime(2023, 8, 17, 3, 40, 5, 737, DateTimeKind.Utc).AddTicks(4466), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Lámpara de mesa de estilo industrial", 120m, 55, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f05c8368-94f4-4293-878a-a96ee27047b0"), new DateTime(2023, 8, 17, 3, 40, 5, 737, DateTimeKind.Utc).AddTicks(4632), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Juego de mesa estratégico \"Catan\"", 120m, 85, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ff579eb7-6313-4ae1-97e4-d550ea9065eb"), new DateTime(2023, 8, 17, 3, 40, 5, 737, DateTimeKind.Utc).AddTicks(4654), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", false, false, "Vino tinto reserva de una bodega reconocida", 128m, 196, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "cbbaac48-603d-4004-907b-f9fb1020309c", "7a39b716-9943-4abc-accf-8783b13c18af" },
                    { "c506c0ae-d06e-4d5d-a57d-433c63245883", "93bd6f5d-6af9-45b1-b996-ee198fb746ab" }
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "UserId" },
                values: new object[,]
                {
                    { new Guid("5dbfb477-a824-4a34-a815-78bd860d476d"), "7a39b716-9943-4abc-accf-8783b13c18af" },
                    { new Guid("7464b959-6dab-420e-bd6a-48075a76b1e2"), "93bd6f5d-6af9-45b1-b996-ee198fb746ab" }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 1, new Guid("f755e198-179c-4791-92be-a6b4f2359b8b"), new Guid("c92afc07-b66c-437e-81ed-208a9d8d02ba") },
                    { 2, new Guid("f755e198-179c-4791-92be-a6b4f2359b8b"), new Guid("c5d547c0-cdc1-43c3-b273-6df9f26b9410") },
                    { 3, new Guid("f755e198-179c-4791-92be-a6b4f2359b8b"), new Guid("837fcb93-492c-4808-8121-f8b8a2ceec0f") },
                    { 4, new Guid("a463d0fe-1ed9-4165-bf9b-a76c6f012cfd"), new Guid("71c645cc-6bfe-4f0e-9262-aaaf09d368a5") },
                    { 5, new Guid("a463d0fe-1ed9-4165-bf9b-a76c6f012cfd"), new Guid("38772743-0756-4077-ad8d-40c34f7279e7") },
                    { 6, new Guid("a463d0fe-1ed9-4165-bf9b-a76c6f012cfd"), new Guid("a814df1f-461e-43b9-99c6-2bdfa0e93de1") },
                    { 7, new Guid("36739425-1f4b-4eac-843c-0afb7ae019a0"), new Guid("2f72df20-229f-44be-ba2f-6b8e344cb690") },
                    { 8, new Guid("36739425-1f4b-4eac-843c-0afb7ae019a0"), new Guid("b9f73587-1dee-4477-959c-f0b3b29d2098") },
                    { 9, new Guid("36739425-1f4b-4eac-843c-0afb7ae019a0"), new Guid("dde91dc3-296a-4707-98c0-74edfba5b570") },
                    { 10, new Guid("1e2ad49d-7a99-4ad5-9f75-45bca7c4db77"), new Guid("82a42560-99aa-48b0-8a58-e43b68c25e4f") },
                    { 11, new Guid("1e2ad49d-7a99-4ad5-9f75-45bca7c4db77"), new Guid("dc0c5b56-5689-410d-bc24-24c9cd103113") },
                    { 12, new Guid("1e2ad49d-7a99-4ad5-9f75-45bca7c4db77"), new Guid("b1941ffa-9f4b-4a4d-8b96-ebf9830b9ed7") },
                    { 13, new Guid("e5cb1954-be90-4594-8db6-3eac4f6fdf52"), new Guid("5f3b91ca-feb4-4ac0-bc78-b7b789ceea62") },
                    { 14, new Guid("e5cb1954-be90-4594-8db6-3eac4f6fdf52"), new Guid("d7cc4571-67fb-4358-bf3c-56e7448c1f23") },
                    { 15, new Guid("e5cb1954-be90-4594-8db6-3eac4f6fdf52"), new Guid("71a124f3-136d-4f40-95c2-945b5b3edf01") },
                    { 16, new Guid("3ea92e81-dd91-4bda-88b8-025bf4e19bb0"), new Guid("26520101-3a7a-4e33-99b3-165d0a0b9436") },
                    { 17, new Guid("3ea92e81-dd91-4bda-88b8-025bf4e19bb0"), new Guid("4ea174ca-fc53-456e-bf9a-49eb1b871010") },
                    { 18, new Guid("3ea92e81-dd91-4bda-88b8-025bf4e19bb0"), new Guid("f05c8368-94f4-4293-878a-a96ee27047b0") },
                    { 19, new Guid("d5e1613b-61bc-4583-8cad-d05818b9ab8e"), new Guid("7a7ecb1e-c7f9-47ac-bf8e-5ee76e6ce623") },
                    { 20, new Guid("d5e1613b-61bc-4583-8cad-d05818b9ab8e"), new Guid("ab6cfb55-0836-486a-bdbb-c416ca73d98b") },
                    { 21, new Guid("d5e1613b-61bc-4583-8cad-d05818b9ab8e"), new Guid("878e6080-c5a3-428e-a030-0031c6e80dcd") },
                    { 22, new Guid("afd4f956-fc03-408c-8f2f-c348bb583184"), new Guid("091dafe0-7e5a-47d1-bdd5-9871ca447c93") },
                    { 23, new Guid("afd4f956-fc03-408c-8f2f-c348bb583184"), new Guid("7cfbe4d7-1e5d-4797-bbf7-af19a03920be") },
                    { 24, new Guid("afd4f956-fc03-408c-8f2f-c348bb583184"), new Guid("ff579eb7-6313-4ae1-97e4-d550ea9065eb") },
                    { 25, new Guid("645fdc3a-b59e-44d9-8b1b-803571621af9"), new Guid("d7c93dda-e972-4bc6-b69b-e7e0ffe2ec1b") },
                    { 26, new Guid("645fdc3a-b59e-44d9-8b1b-803571621af9"), new Guid("56ba067d-63c5-4dc4-b880-47737cf00b1d") },
                    { 27, new Guid("645fdc3a-b59e-44d9-8b1b-803571621af9"), new Guid("b7b7cb67-09b9-40b3-90ef-386ce01f8f71") },
                    { 28, new Guid("fa2c0a85-c2f7-4ebd-95a0-511d74e95cca"), new Guid("ce88b4d5-d95d-4993-96ff-fd346a56eb37") },
                    { 29, new Guid("fa2c0a85-c2f7-4ebd-95a0-511d74e95cca"), new Guid("658655e0-2126-41af-8df7-e7cc34facdde") },
                    { 30, new Guid("fa2c0a85-c2f7-4ebd-95a0-511d74e95cca"), new Guid("dcd48f9a-560b-424e-a8c6-da9978b07414") }
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
