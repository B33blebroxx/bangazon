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
                    Name = "65 Inch Samsung Smart TV",
                    Description = "Super high def QLED display with crazy powerful processor for 8K upscaling.",
                    Price = 2999.99M,
                    ImageUrl = "https://c8.alamy.com/comp/D3C9R8/smart-tv-with-samsung-apps-and-web-browser-D3C9R8.jpg",
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
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQRi83YREwGa67Zs-_OBjT_EjTitdaxkncb-ozkmrPvNbeaO-q27LOVqPB5fYBfPBBxuLk&usqp=CAU",
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
                    ImageUrl = "https://www.shutterstock.com/image-vector/tokyo-2021-sony-play-station-260nw-2085889891.jpg",
                    QuantityAvailable = 15,
                    SellerId = 1,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 4,
                    Name = "Wireless Headphones",
                    Description = "High quality audio output, 6 hour battery life, full noise cancellation.",
                    Price = 219.99M,
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRW0lOAR5jVc0pZqExthLSMqvjPFuwxx9CBzQ&usqp=CAU",
                    QuantityAvailable = 3,
                    SellerId = 4,
                    CategoryId = 3
                },
                new Product
                {
                    Id = 5,
                    Name = "55 Inch Vizio Smart TV",
                    Description = "A top notch 4k streaming experience at a low price.",
                    Price = 499.99M,
                    ImageUrl = "https://www.shutterstock.com/image-photo/young-woman-sitting-on-sofa-260nw-767180002.jpg",
                    QuantityAvailable = 20,
                    SellerId = 3,
                    CategoryId = 1
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

