using wt_lab6_6minimalapi_ageyavich.Models;

namespace wt_lab6_6minimalapi_ageyavich.Data;

public static class ProductStore
{
    public static List<Product> Products { get; } = new()
    {
        new Product { Id = 1, Name = "Ноутбук", Category = "Компьютеры", Price = 2500m, IsAvailable = true },
        new Product { Id = 2, Name = "Мышь", Category = "Аксессуары", Price = 80m, IsAvailable = true },
        new Product { Id = 3, Name = "Клавиатура", Category = "Аксессуары", Price = 150m, IsAvailable = false },
        new Product { Id = 4, Name = "Монитор", Category = "Компьютеры", Price = 350m, IsAvailable = true },
        new Product { Id = 5, Name = "Наушники", Category = "Аудио", Price = 120m, IsAvailable = true }
    };
}