# WT-6. Minimal API — Интернет-магазин

## Эндпоинты

| Метод | URL | Назначение |
| :--- | :--- | :--- |
| GET | `/api/products` | Получить список всех товаров (можно добавить `?search=текст`) |
| GET | `/api/products/{id}` | Получить товар по ID |
| POST | `/api/products` | Создать новый товар |
| PUT | `/api/products/{id}` | Обновить товар по ID |
| DELETE | `/api/products/{id}` | Удалить товар по ID |

## Пример JSON для POST и PUT
```json
{
  "name": "Смартфон",
  "category": "Электроника",
  "price": 800,
  "isAvailable": true
}