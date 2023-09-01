using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SalesSystem.Modules.Carts.Domain;
using SalesSystem.Modules.Products.Domain;
using SalesSystem.Modules.Categories.Domain;
using SalesSystem.Modules.Users.Domain.Entities;
using SalesSystem.Modules.ProductCategories.Domain;
using SalesSystem.Modules.Users.Domain.ValueObjetcs;

namespace SalesSystem.Modules.Users.Infrastructure
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            List<IdentityRole> roles = new()
            {
                new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Name = "User", NormalizedName = "USER" }
            };
            modelBuilder.Entity<IdentityRole>().HasData(roles);

            PhoneNumber? phoneAdmin = PhoneNumber.Create("7588-5214");
            PhoneNumber? phoneUser = PhoneNumber.Create("7895-5914");

            List<User> users = new()
            {
                new User("Luis@mail.com", "Luis", "Caceres", phoneAdmin!,  DateTime.UtcNow, DateTime.MinValue, DateTime.MinValue, false, false),
                new User("Steven@mail.com", "Steven", "Caceres", phoneAdmin!,  DateTime.UtcNow, DateTime.MinValue, DateTime.MinValue, false, false)
            };

            PasswordHasher<User> passHasher = new();
            users[0].PasswordHash = passHasher.HashPassword(users[0], "123456");
            users[1].PasswordHash = passHasher.HashPassword(users[1], "123456");

            users[0].NormalizedEmail = "LUIS@MAIL.COM";
            users[1].NormalizedEmail = "STEVEN@MAIL.COM";

            users[0].NormalizedUserName = "LUIS@MAIL.COM";
            users[1].NormalizedUserName = "STEVEN@MAIL.COM";

            users[0].LockoutEnabled = true;
            users[1].LockoutEnabled = true;

            modelBuilder.Entity<User>().HasData(users);

            List<IdentityUserRole<string>> userRoles = new()
            {
                new IdentityUserRole<string>
                {
                    UserId = users[0].Id,
                    RoleId = roles.FirstOrDefault(r => r.Name == "Admin")!.Id
                },
                new IdentityUserRole<string>
                {
                    UserId = users[1].Id,
                    RoleId = roles.FirstOrDefault(r => r.Name == "User")!.Id
                }
            };
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);

            List<Cart> carts = new()
            {
                new(new CartId(Guid.NewGuid()), users[0].Id),
                new(new CartId(Guid.NewGuid()), users[1].Id)
            };
            modelBuilder.Entity<Cart>().HasData(carts);

            List<Category> categories = new()
            {
                new Category(new CategoryId(Guid.NewGuid()), "Electrónica", DateTime.UtcNow,DateTime.MinValue,DateTime.MinValue,false,false),
                new Category(new CategoryId(Guid.NewGuid()), "Ropa y Accesorios", DateTime.UtcNow,DateTime.MinValue,DateTime.MinValue,false,false),
                new Category(new CategoryId(Guid.NewGuid()), "Hogar y Decoración", DateTime.UtcNow,DateTime.MinValue,DateTime.MinValue,false,false),
                new Category(new CategoryId(Guid.NewGuid()), "Belleza y Cuidado Personal", DateTime.UtcNow,DateTime.MinValue,DateTime.MinValue,false,false),
                new Category(new CategoryId(Guid.NewGuid()), "Deportes y Aire Libre", DateTime.UtcNow,DateTime.MinValue,DateTime.MinValue,false,false),
                new Category(new CategoryId(Guid.NewGuid()), "Juguetes y Juegos", DateTime.UtcNow,DateTime.MinValue,DateTime.MinValue,false,false),
                new Category(new CategoryId(Guid.NewGuid()), "Libros y Entretenimiento", DateTime.UtcNow,DateTime.MinValue,DateTime.MinValue,false,false),
                new Category(new CategoryId(Guid.NewGuid()), "Alimentación y Bebidas", DateTime.UtcNow,DateTime.MinValue,DateTime.MinValue,false,false),
                new Category(new CategoryId(Guid.NewGuid()), "Salud y Bienestar", DateTime.UtcNow,DateTime.MinValue,DateTime.MinValue,false,false),
                new Category(new CategoryId(Guid.NewGuid()), "Automóviles y Motocicletas", DateTime.UtcNow,DateTime.MinValue,DateTime.MinValue,false,false),
            };
            modelBuilder.Entity<Category>().HasData(categories);

            List<Product> products = new()
            {
                new Product(new ProductId(Guid.NewGuid()), "Smartphone Samsung Galaxy S22", "", 525, 255, DateTime.UtcNow, DateTime.MinValue, DateTime.MinValue, false, false),
                new Product(new ProductId(Guid.NewGuid()), "Laptop HP Pavilion 16", "", 1500, 210, DateTime.UtcNow, DateTime.MinValue, DateTime.MinValue, false, false),
                new Product(new ProductId(Guid.NewGuid()), "Auriculares inalámbricos Sony WH-1000XM4", "", 120, 520, DateTime.UtcNow, DateTime.MinValue, DateTime.MinValue, false, false),

                new Product(new ProductId(Guid.NewGuid()), "Camiseta de algodón con estampado floral", "", 40, 41, DateTime.UtcNow, DateTime.MinValue, DateTime.MinValue, false, false),
                new Product(new ProductId(Guid.NewGuid()), "Pantalones vaqueros de corte ajustado", "", 25, 210, DateTime.UtcNow, DateTime.MinValue, DateTime.MinValue, false, false),
                new Product(new ProductId(Guid.NewGuid()), "Bolso de cuero genuino con diseño elegante", "", 30, 50, DateTime.UtcNow, DateTime.MinValue, DateTime.MinValue, false, false),

                new Product(new ProductId(Guid.NewGuid()), "Juego de muebles de sala en tonos neutros", "", 720, 78, DateTime.UtcNow, DateTime.MinValue, DateTime.MinValue, false, false),
                new Product(new ProductId(Guid.NewGuid()), "Juego de sábanas de algodón con diseño moderno", "", 255, 39, DateTime.UtcNow, DateTime.MinValue, DateTime.MinValue, false, false),
                new Product(new ProductId(Guid.NewGuid()), "Lámpara de mesa de estilo industrial", "", 120, 55, DateTime.UtcNow, DateTime.MinValue, DateTime.MinValue, false, false),

                new Product(new ProductId(Guid.NewGuid()), "Set de maquillaje profesional de alta gama", "", 156, 52, DateTime.UtcNow, DateTime.MinValue, DateTime.MinValue, false, false),
                new Product(new ProductId(Guid.NewGuid()), "Perfume floral y fresco para mujer", "", 85, 75, DateTime.UtcNow, DateTime.MinValue, DateTime.MinValue, false, false),
                new Product(new ProductId(Guid.NewGuid()), "Cepillo alisador de cabello con tecnología iónica", "", 175, 19, DateTime.UtcNow, DateTime.MinValue, DateTime.MinValue, false, false),

                new Product(new ProductId(Guid.NewGuid()), "Bicicleta de montaña todoterreno", "", 350, 98, DateTime.UtcNow, DateTime.MinValue, DateTime.MinValue, false, false),
                new Product(new ProductId(Guid.NewGuid()), "Ropa deportiva para running, incluye camiseta y pantalones cortos", "", 355, 64, DateTime.UtcNow, DateTime.MinValue, DateTime.MinValue, false, false),
                new Product(new ProductId(Guid.NewGuid()), "Tienda de campaña resistente al agua para 4 personas", "", 423, 27, DateTime.UtcNow, DateTime.MinValue, DateTime.MinValue, false, false),

                new Product(new ProductId(Guid.NewGuid()), "Juego de construcción LEGO Classic", "", 135, 155, DateTime.UtcNow, DateTime.MinValue, DateTime.MinValue, false, false),
                new Product(new ProductId(Guid.NewGuid()), "Peluche suave y tierno de animalito", "", 45, 525, DateTime.UtcNow, DateTime.MinValue, DateTime.MinValue, false, false),
                new Product(new ProductId(Guid.NewGuid()), "Juego de mesa estratégico \"Catan\"", "", 120, 85, DateTime.UtcNow, DateTime.MinValue, DateTime.MinValue, false, false),

                new Product(new ProductId(Guid.NewGuid()), "Novela de suspenso \"La Chica del Tren\" de Paula Hawkins", "", 25, 320, DateTime.UtcNow, DateTime.MinValue, DateTime.MinValue, false, false),
                new Product(new ProductId(Guid.NewGuid()), "CD de la banda sonora original de Greace", "", 21, 485, DateTime.UtcNow, DateTime.MinValue, DateTime.MinValue, false, false),
                new Product(new ProductId(Guid.NewGuid()), "Videojuego de aventuras \"The Legend of Zelda: Breath of the Wild\"", "", 55, 785, DateTime.UtcNow, DateTime.MinValue, DateTime.MinValue, false, false),

                new Product(new ProductId(Guid.NewGuid()), "Selección de chocolates gourmet de diferentes países", "", 12, 528, DateTime.UtcNow, DateTime.MinValue, DateTime.MinValue, false, false),
                new Product(new ProductId(Guid.NewGuid()), "Caja de té variado con sabores exóticos: Bigelow", "", 25, 740, DateTime.UtcNow, DateTime.MinValue, DateTime.MinValue, false, false),
                new Product(new ProductId(Guid.NewGuid()), "Vino tinto reserva de una bodega Alavesas", "", 128, 196, DateTime.UtcNow, DateTime.MinValue, DateTime.MinValue, false, false),

                new Product(new ProductId(Guid.NewGuid()), "Set de suplementos vitamínicos Arete, para la salud general", "", 129, 504, DateTime.UtcNow, DateTime.MinValue, DateTime.MinValue, false, false),
                new Product(new ProductId(Guid.NewGuid()), "Dispositivo de seguimiento de actividad física y sueño", "", 98, 127, DateTime.UtcNow, DateTime.MinValue, DateTime.MinValue, false, false),
                new Product(new ProductId(Guid.NewGuid()), "Mascarilla facial Cucumber, de cuidado intensivo con ingredientes naturales", "", 234, 529, DateTime.UtcNow, DateTime.MinValue, DateTime.MinValue, false, false),

                new Product(new ProductId(Guid.NewGuid()), "Kit de limpieza y cuidado automotriz de calidad profesional Chemical Guys", "", 359, 74, DateTime.UtcNow, DateTime.MinValue, DateTime.MinValue, false, false),
                new Product(new ProductId(Guid.NewGuid()), "Funda de asiento de cuero para automóvil Handao-Us", "", 75, 56, DateTime.UtcNow, DateTime.MinValue, DateTime.MinValue, false, false),
                new Product(new ProductId(Guid.NewGuid()), "Casco de motocicleta de diseño aerodinámico y alta seguridad BCBKD", "", 125, 142, DateTime.UtcNow, DateTime.MinValue, DateTime.MinValue, false, false),
            };
            modelBuilder.Entity<Product>().HasData(products);

            List<ProductImage> images = new()
            {
              new ProductImage(Guid.NewGuid(), "/Shared/Infrastructure/Images/Products/Smartphone Samsung Galaxy S22.jpg", products[0].Id!),
              new ProductImage(Guid.NewGuid(), "/Shared/Infrastructure/Images/Products/Laptop HP Pavilion 16.jpg", products[1].Id!),
              new ProductImage(Guid.NewGuid(), "/Shared/Infrastructure/Images/Products/Auriculares inalámbricos Sony WH-1000XM4.jpg", products[2].Id!),

              new ProductImage(Guid.NewGuid(), "/Shared/Infrastructure/Images/Products/Camiseta de algodón con estampado floral.jpg", products[3].Id!),
              new ProductImage(Guid.NewGuid(), "/Shared/Infrastructure/Images/Products/Pantalones vaqueros de corte ajustado.jpg", products[4].Id!),
              new ProductImage(Guid.NewGuid(), "/Shared/Infrastructure/Images/Products/Bolso de cuero genuino con diseño elegante.jpg", products[5].Id!),

              new ProductImage(Guid.NewGuid(), "/Shared/Infrastructure/Images/Products/Juego de muebles de sala en tonos neutros.jpg", products[6].Id!),
              new ProductImage(Guid.NewGuid(), "/Shared/Infrastructure/Images/Products/Juego de sábanas de algodón con diseño moderno.jpg", products[7].Id!),
              new ProductImage(Guid.NewGuid(), "/Shared/Infrastructure/Images/Products/Lámpara de mesa de estilo industrial.jpg", products[8].Id!),

              new ProductImage(Guid.NewGuid(), "/Shared/Infrastructure/Images/Products/Set de maquillaje profesional de alta gama.jpg", products[9].Id!),
              new ProductImage(Guid.NewGuid(), "/Shared/Infrastructure/Images/Products/Perfume floral y fresco para mujer.jpg", products[10].Id!),
              new ProductImage(Guid.NewGuid(), "/Shared/Infrastructure/Images/Products/Cepillo alisador de cabello con tecnología iónica.jpg", products[11].Id!),

              new ProductImage(Guid.NewGuid(), "/Shared/Infrastructure/Images/Products/Bicicleta de montaña todoterreno.jpg", products[12].Id!),
              new ProductImage(Guid.NewGuid(), "/Shared/Infrastructure/Images/Products/Ropa deportiva para running.jpg", products[13].Id!),
              new ProductImage(Guid.NewGuid(), "/Shared/Infrastructure/Images/Products/Tienda de campaña resistente al agua para 4 personas.jpg", products[14].Id!),

              new ProductImage(Guid.NewGuid(), "/Shared/Infrastructure/Images/Products/Juego de construcción LEGO Classic.jpg", products[15].Id!),
              new ProductImage(Guid.NewGuid(), "/Shared/Infrastructure/Images/Products/Peluche suave y tierno de animalito.jpg", products[16].Id!),
              new ProductImage(Guid.NewGuid(), "/Shared/Infrastructure/Images/Products/Juego de mesa estratégico Catan.jpg", products[17].Id!),

              new ProductImage(Guid.NewGuid(), "/Shared/Infrastructure/Images/Products/Novela de suspenso La Chica del Tren de Paula Hawkins.jpg", products[18].Id!),
              new ProductImage(Guid.NewGuid(), "/Shared/Infrastructure/Images/Products/CD de la banda sonora original de Greace", products[19].Id!),
              new ProductImage(Guid.NewGuid(), "/Shared/Infrastructure/Images/Products/The Legend of Zelda Breath of the Wild.jpg", products[20].Id!),

              new ProductImage(Guid.NewGuid(), "/Shared/Infrastructure/Images/Products/chocolates gourmet de diferentes países.jpg", products[21].Id!),
              new ProductImage(Guid.NewGuid(), "/Shared/Infrastructure/Images/Products/Caja de té variado Bigelow.jpg", products[22].Id!),
              new ProductImage(Guid.NewGuid(), "/Shared/Infrastructure/Images/Products/Vino tinto reserva de una bodega Alavesas.jpg", products[23].Id!),

              new ProductImage(Guid.NewGuid(), "/Shared/Infrastructure/Images/Products/Suplementos vitamínicos arete.jpg", products[24].Id!),
              new ProductImage(Guid.NewGuid(), "/Shared/Infrastructure/Images/Products/Dispositivo de seguimiento de actividad física y sueño.jpg", products[25].Id!),
              new ProductImage(Guid.NewGuid(), "/Shared/Infrastructure/Images/Products/Mascarilla facial Cucumber.jpg", products[26].Id!),

              new ProductImage(Guid.NewGuid(), "/Shared/Infrastructure/Images/Products/Kit de limpieza y cuidado automotriz Chemical Guys.jpg", products[27].Id!),
              new ProductImage(Guid.NewGuid(), "/Shared/Infrastructure/Images/Products/Funda de asiento de cuero Handao-Us.jpg", products[28].Id!),
              new ProductImage(Guid.NewGuid(), "/Shared/Infrastructure/Images/Products/Casco de motocicleta BCBKD.jpg", products[29].Id!),
            };
            modelBuilder.Entity<ProductImage>().HasData(images);

            List<ProductCategory> productCategories = new()
            {
                new ProductCategory(1, categories[0].Id!, products[0].Id!),
                new ProductCategory(2, categories[0].Id!, products[1].Id!),
                new ProductCategory(3, categories[0].Id!, products[2].Id!),

                new ProductCategory(4, categories[1].Id!, products[3].Id!),
                new ProductCategory(5, categories[1].Id!, products[4].Id!),
                new ProductCategory(6, categories[1].Id!, products[5].Id!),

                new ProductCategory(7, categories[2].Id!, products[6].Id!),
                new ProductCategory(8, categories[2].Id!, products[7].Id!),
                new ProductCategory(9, categories[2].Id!, products[8].Id!),

                new ProductCategory(10, categories[3].Id!, products[9].Id!),
                new ProductCategory(11, categories[3].Id!, products[10].Id!),
                new ProductCategory(12, categories[3].Id!, products[11].Id!),

                new ProductCategory(13, categories[4].Id!, products[12].Id!),
                new ProductCategory(14, categories[4].Id!, products[13].Id!),
                new ProductCategory(15, categories[4].Id!, products[14].Id!),

                new ProductCategory(16, categories[5].Id!, products[15].Id!),
                new ProductCategory(17, categories[5].Id!, products[16].Id!),
                new ProductCategory(18, categories[5].Id!, products[17].Id!),

                new ProductCategory(19, categories[6].Id!, products[18].Id!),
                new ProductCategory(20, categories[6].Id!, products[19].Id!),
                new ProductCategory(21, categories[6].Id!, products[20].Id!),

                new ProductCategory(22, categories[7].Id!, products[21].Id!),
                new ProductCategory(23, categories[7].Id!, products[22].Id!),
                new ProductCategory(24, categories[7].Id!, products[23].Id!),

                new ProductCategory(25, categories[8].Id!, products[24].Id!),
                new ProductCategory(26, categories[8].Id!, products[25].Id!),
                new ProductCategory(27, categories[8].Id!, products[26].Id!),

                new ProductCategory(28, categories[9].Id!, products[27].Id!),
                new ProductCategory(29, categories[9].Id!, products[28].Id!),
                new ProductCategory(30, categories[9].Id!, products[29].Id!),
            };

            modelBuilder.Entity<ProductCategory>().HasData(productCategories);
        }
    }
}
