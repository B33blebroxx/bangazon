using BangazonBE.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.Extensions.Hosting;
using BangazonBE.DTOs;




// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var builder = WebApplication.CreateBuilder(args);
// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<BangazonBEDbContext>(builder.Configuration["BangazonBEDbConnectionString"]);

// Set the JSON serializer options
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Post new user
app.MapPost("/register", (BangazonBEDbContext db, User newUser) =>
{
    try
    {
        db.Users.Add(newUser);
        db.SaveChanges();
        return Results.Created($"/user/{newUser.Id}", newUser);
    }
    catch (DbUpdateException)
    {
        return Results.BadRequest("Couldn't create new user, please try again!");
    }
});

//Get all users
app.MapGet("/users", (BangazonBEDbContext db) =>
{
    return db.Users.ToList();
});

//Get user by id
app.MapGet("/users/{id}", (BangazonBEDbContext db, int id) =>
{
    User chosenUser = db.Users.SingleOrDefault(u => u.Id == id);
    if (chosenUser == null)
    {
        return Results.NotFound("User not found.");
    }
    return Results.Ok(chosenUser);
});

//Search for user by first name, last name, or both
app.MapGet("/users/name-search", (BangazonBEDbContext db, string query) =>
{
    if (string.IsNullOrWhiteSpace(query))
    {
        return Results.BadRequest("Search query cannot be empty");
    }
    query = query.ToLower();

    // Filter users whose first name or last name matches the query
    var filteredUsers = db.Users
         .Where(u => (u.FirstName.ToLower() + " " + u.LastName.ToLower()).Contains(query))
         .ToList();

    if (filteredUsers.Count == 0)
    {
        return Results.NotFound("No users found with that name.");
    }
    return Results.Ok(filteredUsers);
});

//Get all products
app.MapGet("/products", (BangazonBEDbContext db) =>
{
    return db.Products.ToList();
});

// Get Orders
app.MapGet("/orders", (BangazonBEDbContext db) =>
{
    var orders = db.Orders.ToList();
    return Results.Ok(orders);
});

//Get single product by product Id
app.MapGet("/products/{productId}", (BangazonBEDbContext db, int productId) =>
{
    Product chosenProduct = db.Products.SingleOrDefault(p => p.Id == productId);

    if (chosenProduct == null)
    {
        return Results.NotFound("Product not found.");
    }
    return Results.Ok(chosenProduct);
});

//Get seller's products
app.MapGet("/users/{sellerId}/products", (BangazonBEDbContext db, int sellerId) =>
{
    return db.Products.Where(p => p.SellerId == sellerId).ToList();
});

//Search for product by name
app.MapGet("/products/search", (BangazonBEDbContext db, string query) =>
{
    if (string.IsNullOrWhiteSpace(query))
    {
        return Results.BadRequest("Search query cannot be empty");
    }
    query = query.ToLower();

    var filteredProducts = db.Products.Where(p => p.Name.ToLower().Contains(query))
    .ToList();

    if (filteredProducts.Count == 0)
    {
        return Results.NotFound("No products matching search query.");
    }
    return Results.Ok(filteredProducts);
});

//Create new product
app.MapPost("/products", (BangazonBEDbContext db, Product newProduct) =>
{
    try
    {
        db.Products.Add(newProduct);
        db.SaveChanges();
        return Results.Created($"/products/{newProduct.Id}", newProduct);
    }
    catch
    {
        return Results.BadRequest("Couldn't create product, please try again!");
    }
});

//Edit existing product
app.MapPatch("/products/{id}", (BangazonBEDbContext db, int id, Product updatedProduct) =>
{
    var product = db.Products.SingleOrDefault(p => p.Id == id);

    if (product == null)
    {
        return Results.NotFound("No product matching the provided Id.");
    }

    product.Name = updatedProduct.Name;
    product.Description = updatedProduct.Description;
    product.Price = updatedProduct.Price;
    product.ImageUrl = updatedProduct.ImageUrl;
    product.QuantityAvailable = updatedProduct.QuantityAvailable;
    product.CategoryId = updatedProduct.CategoryId;

    db.SaveChanges();

    return Results.Ok(product);

});

//Delete product
app.MapDelete("/products", (BangazonBEDbContext db, int id) =>
{
    var productToDelete = db.Products.SingleOrDefault(p => p.Id == id);
    
    if (productToDelete == null)
    {
        return Results.BadRequest("No product matching provided Id");
    }

    db.Products.Remove(productToDelete);
    db.SaveChanges();
    return Results.Ok("Product deleted");
});

//Get orders by Id
app.MapGet("/orders/{id}", (BangazonBEDbContext db, int id) =>
{
    return db.Orders.Where(o => o.Id == id).Include(p => p.Products).ToList();
});

//Create Order
app.MapPost("/orders", (BangazonBEDbContext db, Order newOrder) =>
{
    try
    {
        db.Orders.Add(newOrder);
        db.SaveChanges();
        return Results.Created($"/orders/{newOrder.Id}", newOrder);
    }
    catch (DbUpdateException)
    {
        return Results.BadRequest("Unable to create order, please try again.");
    }
});

//Add product to order
app.MapPost("/orders/addProduct", (BangazonBEDbContext db, addProductDTO newProduct) =>
{
    var order = db.Orders.Include(o => o.Products).FirstOrDefault(o => o.Id == newProduct.OrderId);

    if (order == null)
    {
        return Results.NotFound("No order found.");
    }

    var product = db.Products.Find(newProduct.ProductId);

    if (product == null)
    {
        return Results.NotFound("Product not found.");
    }

    order.Products.Add(product);
    db.SaveChanges();
    return Results.Created($"/orders/addProduct", newProduct);
});

//Patch order
app.MapPatch("/orders/{id}", (BangazonBEDbContext db, int id, Order updatedOrder) =>
{
    var order = db.Orders.SingleOrDefault(o => o.Id == id);

    if (order == null)
    {
        return Results.NotFound("Order not found");
    }

    order.IsComplete = updatedOrder.IsComplete;
    order.PaymentTypeId = updatedOrder.PaymentTypeId;
    db.SaveChanges();
    return Results.Ok("Order completed");
});

//Delete product from order
app.MapDelete("/orders/{orderId}/{productId}", (BangazonBEDbContext db, int orderId, int productId) =>
{
    var order = db.Orders.Include(o => o.Products).SingleOrDefault(o => o.Id == orderId);
    
    if (order == null)
    {
        return Results.NotFound("Order not found.");
    }

    var product = db.Products.Find(productId);

    if (product == null)
    {
        return Results.NotFound("Product not found.");
    }

    order.Products.Remove(product);
    db.SaveChanges();
    return Results.Ok("Product removed from order.");
});

//Delete order
app.MapDelete("/orders/{id}", (BangazonBEDbContext db, int id) =>
{
    var order = db.Orders.SingleOrDefault(o => o.Id == id);

    if (order == null)
    {
        return Results.NotFound("Order not found.");
    }
    db.Orders.Remove(order);
    db.SaveChanges();
    return Results.Ok("Order deleted");
});

app.Run();

