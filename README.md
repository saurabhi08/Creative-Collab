<<<<<<< HEAD
# Mind & Market - Creative Collab (Library + Supermarket)

A unique application that combines library and supermarket functionality, creating an innovative shopping and reading experience.

## 🌟 Features

### Core CRUD Operations
- **Books** - Complete library management
- **Authors** - Author information and biographies
- **Categories** - Book categorization
- **Products** - Supermarket inventory management
- **Aisles** - Store layout management
- **Departments** - Department organization

### Combined Features
- **ListBooksForProduct** - Show all books linked to a product (e.g., cookbooks for olive oil)
- **ListProductsForBook** - Recommend grocery products that go with a book (e.g., Mediterranean diet book → olive oil, pasta)
- **AddBookToProduct** - Link books to products
- **RemoveBookFromProduct** - Unlink books from products
- **ListBooksForDepartment** - Show books related to a department
- **AddBookToDepartment** - Connect books to departments (e.g., organic farming book → organic vegetables department)
- **RemoveBookFromDepartment** - Unlink books from departments
- **ListReadingSpotsInStore** - Show available reading areas (Book & Brew Corner, Reading Nooks)
- **Events Management** - Create, manage events like Storytime, Book signings, Cooking demos
- **ListBooksForEvent** - Show books related to events
- **AddBookToEvent** - Link books to events
- **RemoveBookFromEvent** - Unlink books from events

## 🏗️ Architecture

- **.NET 8.0** Web API
- **Entity Framework Core** for data access
- **SQL Server** database
- **Repository Pattern** with Services
- **DTOs** for data transfer
- **Swagger** for API documentation

## 📁 Project Structure

```
Mind and Market/
├── Controllers/          # API Controllers
├── Data/                # Entity Framework Context
├── DTOs/                # Data Transfer Objects
├── Models/              # Entity Models
├── Services/            # Business Logic Services
├── Properties/          # Project Properties
├── appsettings.json     # Configuration
├── Program.cs           # Application Entry Point
└── README.md           # This File
```

## 🚀 Getting Started

### Prerequisites
- .NET 8.0 SDK
- SQL Server (LocalDB or SQL Server Express)
- Visual Studio 2022 or VS Code

### Installation

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd Mind-and-Market
   ```

2. **Restore dependencies**
   ```bash
   dotnet restore
   ```

3. **Create the database**
   ```bash
   dotnet ef database update
   ```

4. **Run the application**
   ```bash
   dotnet run
   ```

5. **Access the API**
   - Swagger UI: `https://localhost:7000/swagger`
   - API Base URL: `https://localhost:7000/api`

## 📚 API Endpoints

### Books
- `GET /api/books` - Get all books
- `GET /api/books/{id}` - Get book by ID
- `POST /api/books` - Create new book
- `PUT /api/books/{id}` - Update book
- `DELETE /api/books/{id}` - Delete book

### Combined Features
- `GET /api/books/for-product/{productId}` - Get books for a product
- `GET /api/books/{bookId}/products` - Get products for a book
- `POST /api/books/{bookId}/products/{productId}` - Link book to product
- `DELETE /api/books/{bookId}/products/{productId}` - Unlink book from product
- `GET /api/books/for-department/{departmentId}` - Get books for a department
- `POST /api/books/{bookId}/departments/{departmentId}` - Link book to department
- `DELETE /api/books/{bookId}/departments/{departmentId}` - Unlink book from department
- `GET /api/books/for-event/{eventId}` - Get books for an event
- `POST /api/books/{bookId}/events/{eventId}` - Link book to event
- `DELETE /api/books/{bookId}/events/{eventId}` - Unlink book from event

### Other Entities
- **Authors**: `/api/authors`
- **Categories**: `/api/categories`
- **Products**: `/api/products`
- **Aisles**: `/api/aisles`
- **Departments**: `/api/departments`
- **ReadingSpots**: `/api/readingspots`
- **Events**: `/api/events`

## 🌟 Real-World Use Cases

| Scenario | API Example |
|----------|-------------|
| Show all books linked to "Olive Oil" | `GET /api/books/for-product/1` |
| Recommend products for "The Mediterranean Diet" book | `GET /api/books/1/products` |
| Connect "Organic Farming" book to "Organic Vegetables Department" | `POST /api/books/2/departments/3` |
| Create a cooking + reading event for kids | `POST /api/events` + `POST /api/books/4/events/1` |
| Show reading spots available in-store | `GET /api/readingspots` |

## 🛠️ Development

### Database Migrations
```bash
# Create a new migration
dotnet ef migrations add MigrationName

# Update database
dotnet ef database update
```

### Testing
Use the provided `MindAndMarket.http` file to test the API endpoints.

## 📝 License

This project is created for educational purposes.

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Submit a pull request

## 📞 Support

For questions or support, please open an issue in the repository. 
=======
# Creative-Collab
>>>>>>> b3f8461ff217ab8b6aba5e590253fb712fa995df
