using Microsoft.EntityFrameworkCore;
using BangazonBE.Models;


    public class BangazonBEDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }

        public BangazonBEDbContext(DbContextOptions<BangazonBEDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User[]
            {
                new User
                {
                    Id = 1,
                    FirstName = "Brandon",
                    LastName = "Schnurbusch",
                    UserName = "bschnurb",
                    Email = "b33blebroxx@gmail.com",
                    ProfileImgUrl = "https://avatars.githubusercontent.com/u/134976580?v=4",
                    IsSeller = true,
                    Uid = "",
                },
                new User
                {
                    Id = 2,
                    FirstName = "Henry",
                    LastName = "Zebrowski",
                    UserName = "DrFanTasty",
                    Email = "sidestoriesLPOTL@gmail.com",
                    ProfileImgUrl = "https://m.media-amazon.com/images/M/MV5BMjE3MTE4NjU0NF5BMl5BanBnXkFtZTgwMDk5NzE5NzE@._V1_.jpg",
                    IsSeller = true,
                    Uid = "",
                },
                new User
                {
                    Id = 3,
                    FirstName = "Ed",
                    LastName = "Larson",
                    UserName = "Ham",
                    Email = "brighterside@gmail.com",
                    ProfileImgUrl = "https://m.media-amazon.com/images/M/MV5BNTIyYWI0ZDMtMTc3Mi00ZGFiLThjZDYtMGNmZDRjMWM0MDQ4XkEyXkFqcGdeQXVyMTI0OTEzNjY@._V1_.jpg",
                    IsSeller = true,
                    Uid = ""
                },
                new User
                {
                    Id = 4,
                    FirstName = "Marcus",
                    LastName = "Parks",
                    UserName = "DogMeat",
                    Email = "LPOTL@gmail.com",
                    ProfileImgUrl = "https://storage.googleapis.com/pkommunity/website/images/Host%20Headshots/marcus-parks.png",
                    IsSeller = true,
                    Uid = ""
                },
                new User
                {
                    Id = 5,
                    FirstName = "Holden",
                    LastName = "McNeely",
                    UserName = "LizardMan",
                    Email = "holdenatorsHo@gmail.com",
                    ProfileImgUrl = "https://pbs.twimg.com/profile_images/758335467431616512/RfoPP_jP_400x400.jpg",
                    IsSeller = false,
                    Uid = ""
                }
            });

            modelBuilder.Entity<Order>().HasData(new Order[]
            {
                new Order
                {
                    Id = 1,
                    CustomerId = 2,
                    IsComplete = true,
                    PaymentTypeId = 3
                },
                new Order
                {
                    Id = 2,
                    CustomerId = 1,
                    IsComplete = false,
                    PaymentTypeId = null
                },
                new Order
                {
                    Id = 3,
                    CustomerId = 1,
                    IsComplete = true,
                    PaymentTypeId = 2
                },
                new Order
                {
                    Id = 4,
                    CustomerId = 4,
                    IsComplete = false,
                    PaymentTypeId = null
                },
                new Order
                {
                    Id = 5,
                    CustomerId = 3,
                    IsComplete = true,
                    PaymentTypeId = 1
                }
            });

            modelBuilder.Entity<Product>().HasData(new Product[]
            {
                new Product
                {
                    Id = 1,
                    Name = "Samsung Smart TV",
                    Description = "Super high def QLED display with crazy powerful processor for 8K upscaling.",
                    Price = 3999.99M,
                    ImageUrl = "https://pisces.bbystatic.com/image2/BestBuy_US/images/products/6535/6535209_sd.jpg;maxHeight=400;maxWidth=600",
                    QuantityAvailable = 10,
                    SellerId = 5,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 2,
                    Name = "Gaming Chair",
                    Description = "Memory foam seat, armrests, and headrest, adjustable lumbar support, and breatheable fabric.",
                    Price = 449.99M,
                    ImageUrl = "https://m.media-amazon.com/images/I/61t4mpabO+L._AC_UF894,1000_QL80_.jpg",
                    QuantityAvailable = 7,
                    SellerId = 1,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 3,
                    Name = "Wireless PS5 Controller",
                    Description = "Bluetooth DualSense Edge controller for the Playstation 5.",
                    Price = 169.99M,
                    ImageUrl = "https://i5.walmartimages.com/seo/Sony-PS5-DualSense-Edge-Wireless-Controller_657e4493-944a-4782-9654-f8e024752c67.8319804d8bf7e5311004fecfb9f0e7f4.png?odnHeight=640&odnWidth=640&odnBg=FFFFFF",
                    QuantityAvailable = 15,
                    SellerId = 1,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 4,
                    Name = "Wireless Earbuds",
                    Description = "High quality audio output, 6 hour battery life, full noise cancellation.",
                    Price = 219.99M,
                    ImageUrl = "https://m.media-amazon.com/images/I/51bRSWrEc7S._AC_UF1000,1000_QL80_.jpg",
                    QuantityAvailable = 3,
                    SellerId = 4,
                    CategoryId = 3
                }
            });

            modelBuilder.Entity<PaymentType>().HasData(new PaymentType[]
            {
                new PaymentType
                {
                    Id = 1,
                    PaymentName = "PayPal"
                },
                new PaymentType
                {
                    Id = 2,
                    PaymentName = "Debit"
                },
                new PaymentType
                {
                    Id = 3,
                    PaymentName = "Credit"
                }
            });

            modelBuilder.Entity<Category>().HasData(new Category[]
            {
                new Category
                {
                    Id = 1,
                    Title = "Smart TVs"
                },
                new Category
                {
                    Id = 2,
                    Title = "Gaming Accessories"
                },
                new Category
                {
                    Id = 3,
                    Title = "Headphones"
                },
                new Category
                {
                    Id = 4,
                    Title = "Books"
                }
            });
        }

    }

