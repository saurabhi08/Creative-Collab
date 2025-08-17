## Mind & Market - Creative Collab (Library + Supermarket)

An application that combines library and supermarket functionality, with API endpoints, simple MVC pages, and role-based administration.

## 🌟 Features

- **Core CRUD**: `Books`, `Authors`, `Categories`, `Products`, `Aisles`, `Departments`, `ReadingSpots`, `Events`
- **Relationships**:
  - **Books ↔ Products**: list/link/unlink
  - **Books ↔ Departments**: list/link/unlink
  - **Books ↔ Events**: list/link/unlink
  - **Departments → Products**: list products in a department
  - **Aisles → Products**: list products in an aisle
- **Admin-only**: Product create/update/delete secured by ASP.NET Core Identity role `Admin`
- **UI Pages**: Simple MVC Store pages backed by services
- **Swagger**: XML summaries documented for all endpoints

## 🏗️ Tech

- .NET 8, ASP.NET Core Web API + MVC
- EF Core with SQL Server
- ASP.NET Core Identity (cookie auth + roles)

## 📁 Project Structure

```
Controllers/  Data/  DTOs/  Models/  Services/  Views/Store/  Program.cs  appsettings.json
```

## 🚀 Getting Started

### Prerequisites
- .NET 8 SDK, SQL Server (LocalDB/Express)

### Setup
```bash
dotnet restore
dotnet ef database update
dotnet run
```

### URLs
- Swagger: `http://localhost:5000/swagger`
- API base: `http://localhost:5000/api`
- Store UI: `http://localhost:5000/Store`

## 🔐 Administration & Login

- Seed admin user/role:
  - `POST /api/account/seed-admin`
  - Creates role `Admin` and user `admin@example.com` with password `Admin123$`
- Login (cookie auth):
  - `POST /api/account/login` with body:
    ```json
    { "email": "admin@example.com", "password": "Admin123$" }
    ```
  - Calls from the same browser/session will carry the auth cookie
- Logout: `POST /api/account/logout`
- Admin-only endpoints (require role `Admin`):
  - `POST /api/products`
  - `PUT /api/products/{id}`
  - `DELETE /api/products/{id}`

## 📚 Key API Endpoints

- Books: `GET/POST/PUT/DELETE /api/books`, plus relationship routes:
  - `GET /api/books/for-product/{productId}`
  - `GET /api/books/{bookId}/products`
  - `POST /api/books/{bookId}/products/{productId}` / `DELETE ...`
  - `GET /api/books/for-department/{departmentId}`
  - `POST /api/books/{bookId}/departments/{departmentId}` / `DELETE ...`
  - `GET /api/books/for-event/{eventId}`
  - `POST /api/books/{bookId}/events/{eventId}` / `DELETE ...`
- Products:
  - `GET /api/products`
  - `GET /api/products/{id}`
  - `GET /api/products/by-department/{departmentId}`
  - `GET /api/products/by-aisle/{aisleId}`
- Departments: `GET /api/departments`, `GET /api/departments/{id}/products`
- Aisles: `GET /api/aisles`, `GET /api/aisles/{id}/products`
- ReadingSpots, Events, Authors, Categories: standard CRUD under `/api/{entity}`

## 🖥️ Store UI Pages

- `GET /Store` – list products (name, price, aisle, department)
- `GET /Store/Details/{id}` – product details
- `GET /Store/ByDepartment/{id}` – products filtered by department
- `GET /Store/ByAisle/{id}` – products filtered by aisle

## 🛠️ Migrations

```bash
dotnet ef migrations add Name
dotnet ef database update
```

## Notes

- Swagger displays XML summaries for controllers and endpoints
- Development launch profile serves on `http://localhost:5000`
