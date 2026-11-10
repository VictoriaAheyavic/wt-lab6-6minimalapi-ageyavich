using wt_lab6_6minimalapi_ageyavich.Data;
using wt_lab6_6minimalapi_ageyavich.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var builder = WebApplication.CreateBuilder(args);

// Добавляем поддержку OpenAPI
builder.Services.AddOpenApi(); 

var app = builder.Build();

// Включаем генератор документации в режиме разработки
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// GET /
app.MapGet("/", () => "Minimal API работает!");

// GET /api/info
app.MapGet("/api/info", () => 
{
    return new
    {
        Application = "Web Technologies",
        Technology = "ASP.NET Core Minimal API",
        Version = "1.0"
    };
});

// 1. GET /api/products (получить список + фильтрация)
app.MapGet("/api/products", (string? search) => 
{
    var products = ProductStore.Products.AsEnumerable();
    
    // Если передан query-параметр search, фильтруем
    if (!string.IsNullOrWhiteSpace(search))
    {
        products = products.Where(x => x.Name.Contains(search, StringComparison.OrdinalIgnoreCase));
    }
    
    return Results.Ok(products);
});

// 2. GET /api/products/{id} (получить один объект)
app.MapGet("/api/products/{id}", (int id) => 
{
    var product = ProductStore.Products.FirstOrDefault(x => x.Id == id);
    
    if (product == null) 
        return Results.NotFound(); // 404
        
    return Results.Ok(product);    // 200
});

// POST /api/products
app.MapPost("/api/products", (Product product) => 
{
    // Автоматическая генерация ID
    var newId = ProductStore.Products.Count == 0 
        ? 1 
        : ProductStore.Products.Max(x => x.Id) + 1;
        
    product.Id = newId;
    ProductStore.Products.Add(product);

    // Возвращаем 201 Created и ссылку на созданный ресурс
    return Results.Created($"/api/products/{product.Id}", product);
});

// PUT /api/products/{id} (обновление)
app.MapPut("/api/products/{id}", (int id, Product updatedProduct) => 
{
    var product = ProductStore.Products.FirstOrDefault(x => x.Id == id);
    
    if (product == null) 
        return Results.NotFound();

    // Обновляем поля
    product.Name = updatedProduct.Name;
    product.Category = updatedProduct.Category;
    product.Price = updatedProduct.Price;
    product.IsAvailable = updatedProduct.IsAvailable;

    return Results.Ok(product);
});

// DELETE /api/products/{id} (удаление)
app.MapDelete("/api/products/{id}", (int id) => 
{
    var product = ProductStore.Products.FirstOrDefault(x => x.Id == id);
    
    if (product == null) 
        return Results.NotFound();

    ProductStore.Products.Remove(product);
    
    // 204 No Content (успешно удалено, тело ответа не нужно)
    return Results.NoContent(); 
});

var port = Environment.GetEnvironmentVariable("PORT") ?? "10000";
app.Run($"http://0.0.0.0:{port}");