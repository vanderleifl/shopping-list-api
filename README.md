# 🛒 ShoppingListAPI

A simple and modern RESTful API built with **ASP.NET Core 9** to manage shopping lists and items — designed to demonstrate clean architecture, API documentation, authentication, and DevOps readiness.

## 👨‍💻 Author

Created by **Vanderlei Franke Liviz** — full-stack developer with 30+ years of experience, always learning and adapting.

- [GitHub](https://github.com/vanderleifl)
- [LinkedIn](https://www.linkedin.com/in/vanderleifl)

## 📦 Technologies Used

- ASP.NET Core MVC
- RESTful API design
- Swagger (OpenAPI)
- Entity Framework Core with (InMemory provider)
- Git version control
- DevOps best practices
- Hosting on Microsoft Azure

## 🚀 Current Features

✅ Supports full **CRUD** operations for shopping list items:

| Method | Route                  | Description                                 |
|--------|------------------------|---------------------------------------------|
| `GET`  | `/items`               | Retrieve all items                          |
| `POST` | `/items`               | Create a new item                           |
| `PUT`  | `/items/{id}/toggle`   | Toggle item as purchased/unpurchased        |
| `DELETE` | `/items/{id}`        | Delete an item from the list                |

## 📦 Example JSON (Create Item)

```json
{
  "name": "Milk",
  "price": 3.49,
  "shoppingListId": 1
}

🧪 Swagger UI

To explore and test the API, open:

http://localhost:5251/ (your port can be different)

📂 Project Structure (so far)

Models/User.cs - Controls the access to the API
Models/Item.cs — Defines shopping item entity.
Models/ShoppingList.cs — Represents a list with multiple items.
Data/AppDbContext.cs — EF Core context using InMemoryDatabase.
Program.cs — Configures API endpoints and services.

🔄 Next Steps

Link users to shopping lists.
Connect to a real database (SQL Server or Azure SQL).
Build React front-end to consume this API.
Learn how to deploy the full stack using DevOps tools and CI/CD pipelines.

🧠 Learning Goals

This project is part of a continuous learning journey to improve understanding of:

System design patterns
DevOps and CI/CD
Cloud hosting (Azure)
Front-end integration (React)
📌 Author: @vanderleifl
🎯 Project: Educational / Portfolio

## 🔗 How to Run

```bash
dotnet restore
dotnet run

