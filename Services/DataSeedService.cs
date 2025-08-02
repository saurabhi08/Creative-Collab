using Microsoft.EntityFrameworkCore;
using MindAndMarket.Data;
using MindAndMarket.Models;

namespace MindAndMarket.Services
{
    public class DataSeedService : IDataSeedService
    {
        private readonly MindAndMarketContext _context;

        public DataSeedService(MindAndMarketContext context)
        {
            _context = context;
        }

        public async Task SeedDataAsync()
        {
            // Check if data already exists
            if (await _context.Authors.AnyAsync())
            {
                return; // Data already seeded
            }

            // Seed Authors
            var authors = new List<Author>
            {
                new Author { Name = "Julia Child", Biography = "Famous chef and cookbook author", Nationality = "American", BirthDate = new DateTime(1912, 8, 15) },
                new Author { Name = "Gordon Ramsay", Biography = "Celebrity chef and restaurateur", Nationality = "British", BirthDate = new DateTime(1966, 11, 8) },
                new Author { Name = "Jamie Oliver", Biography = "British chef and food campaigner", Nationality = "British", BirthDate = new DateTime(1975, 5, 27) },
                new Author { Name = "Ina Garten", Biography = "Barefoot Contessa and cookbook author", Nationality = "American", BirthDate = new DateTime(1948, 2, 2) },
                new Author { Name = "Anthony Bourdain", Biography = "Chef, author, and travel documentarian", Nationality = "American", BirthDate = new DateTime(1956, 6, 25) },
                new Author { Name = "Michael Pollan", Biography = "Food journalist and author", Nationality = "American", BirthDate = new DateTime(1955, 2, 6) },
                new Author { Name = "Alice Waters", Biography = "Chef and food activist", Nationality = "American", BirthDate = new DateTime(1944, 4, 28) },
                new Author { Name = "Yotam Ottolenghi", Biography = "Chef and cookbook author", Nationality = "Israeli-British", BirthDate = new DateTime(1968, 12, 14) }
            };

            _context.Authors.AddRange(authors);
            await _context.SaveChangesAsync();

            // Seed Categories
            var categories = new List<Category>
            {
                new Category { Name = "Cookbooks", Description = "Cooking and recipe books" },
                new Category { Name = "Healthy Eating", Description = "Nutrition and healthy lifestyle books" },
                new Category { Name = "Baking", Description = "Baking and pastry books" },
                new Category { Name = "Mediterranean", Description = "Mediterranean cuisine books" },
                new Category { Name = "Vegetarian", Description = "Vegetarian and vegan cooking" },
                new Category { Name = "Food Science", Description = "Food science and nutrition" },
                new Category { Name = "Organic Farming", Description = "Organic farming and sustainable agriculture" },
                new Category { Name = "Food History", Description = "Culinary history and food culture" }
            };

            _context.Categories.AddRange(categories);
            await _context.SaveChangesAsync();

            // Seed Aisles
            var aisles = new List<Aisle>
            {
                new Aisle { Name = "Cooking Oils", Description = "Various cooking oils and fats", AisleNumber = 1, Location = "North side" },
                new Aisle { Name = "Grains & Pasta", Description = "Rice, pasta, and grains", AisleNumber = 2, Location = "North side" },
                new Aisle { Name = "Fresh Produce", Description = "Fresh fruits and vegetables", AisleNumber = 3, Location = "East side" },
                new Aisle { Name = "Dairy & Eggs", Description = "Milk, cheese, and eggs", AisleNumber = 4, Location = "West side" },
                new Aisle { Name = "Bakery", Description = "Fresh bread and pastries", AisleNumber = 5, Location = "South side" },
                new Aisle { Name = "Spices & Herbs", Description = "Dried spices and fresh herbs", AisleNumber = 6, Location = "North side" },
                new Aisle { Name = "Organic Foods", Description = "Organic and natural products", AisleNumber = 7, Location = "East side" },
                new Aisle { Name = "International Foods", Description = "International and ethnic foods", AisleNumber = 8, Location = "West side" }
            };

            _context.Aisles.AddRange(aisles);
            await _context.SaveChangesAsync();

            // Seed Departments
            var departments = new List<Department>
            {
                new Department { Name = "Organic Foods", Description = "Organic and natural food products", ManagerName = "Sarah Johnson", IsActive = true },
                new Department { Name = "Fresh Produce", Description = "Fresh fruits and vegetables", ManagerName = "Mike Chen", IsActive = true },
                new Department { Name = "Bakery", Description = "Fresh bread and pastries", ManagerName = "Maria Rodriguez", IsActive = true },
                new Department { Name = "Dairy", Description = "Milk, cheese, and dairy products", ManagerName = "David Wilson", IsActive = true },
                new Department { Name = "International Foods", Description = "International and ethnic foods", ManagerName = "Lisa Kim", IsActive = true },
                new Department { Name = "Health & Wellness", Description = "Health foods and supplements", ManagerName = "Tom Anderson", IsActive = true },
                new Department { Name = "Gourmet Foods", Description = "Premium and gourmet products", ManagerName = "Emma Thompson", IsActive = true },
                new Department { Name = "Sustainable Products", Description = "Eco-friendly and sustainable products", ManagerName = "Alex Green", IsActive = true }
            };

            _context.Departments.AddRange(departments);
            await _context.SaveChangesAsync();

            // Seed Products
            var products = new List<Product>
            {
                new Product { Name = "Extra Virgin Olive Oil", Description = "Premium Italian extra virgin olive oil", Price = 12.99m, StockQuantity = 100, SKU = "EVOO-001", IsOrganic = true, IsGlutenFree = true, AisleId = 1, DepartmentId = 1 },
                new Product { Name = "Organic Quinoa", Description = "Organic quinoa grains", Price = 8.99m, StockQuantity = 75, SKU = "QUIN-001", IsOrganic = true, IsGlutenFree = true, AisleId = 2, DepartmentId = 1 },
                new Product { Name = "Fresh Basil", Description = "Fresh organic basil", Price = 3.99m, StockQuantity = 50, SKU = "BASIL-001", IsOrganic = true, IsGlutenFree = true, AisleId = 3, DepartmentId = 2 },
                new Product { Name = "Artisan Sourdough Bread", Description = "Freshly baked artisan sourdough", Price = 6.99m, StockQuantity = 30, SKU = "BREAD-001", IsOrganic = false, IsGlutenFree = false, AisleId = 5, DepartmentId = 3 },
                new Product { Name = "Organic Greek Yogurt", Description = "Creamy organic Greek yogurt", Price = 5.99m, StockQuantity = 60, SKU = "YOG-001", IsOrganic = true, IsGlutenFree = true, AisleId = 4, DepartmentId = 4 },
                new Product { Name = "Mediterranean Sea Salt", Description = "Premium Mediterranean sea salt", Price = 4.99m, StockQuantity = 80, SKU = "SALT-001", IsOrganic = true, IsGlutenFree = true, AisleId = 6, DepartmentId = 7 },
                new Product { Name = "Organic Cherry Tomatoes", Description = "Sweet organic cherry tomatoes", Price = 4.49m, StockQuantity = 40, SKU = "TOMATO-001", IsOrganic = true, IsGlutenFree = true, AisleId = 3, DepartmentId = 2 },
                new Product { Name = "Balsamic Vinegar", Description = "Aged balsamic vinegar", Price = 15.99m, StockQuantity = 45, SKU = "VINEGAR-001", IsOrganic = false, IsGlutenFree = true, AisleId = 6, DepartmentId = 7 }
            };

            _context.Products.AddRange(products);
            await _context.SaveChangesAsync();

            // Seed Books
            var books = new List<Book>
            {
                new Book { Title = "The Mediterranean Diet Cookbook", Description = "Healthy recipes from the Mediterranean region", ISBN = "978-1234567890", PublicationDate = new DateTime(2023, 1, 15), Price = 29.99m, StockQuantity = 50, AuthorId = 1, CategoryId = 4 },
                new Book { Title = "Mastering the Art of French Cooking", Description = "Classic French cooking techniques", ISBN = "978-0987654321", PublicationDate = new DateTime(1961, 10, 16), Price = 45.00m, StockQuantity = 25, AuthorId = 1, CategoryId = 1 },
                new Book { Title = "The Omnivore's Dilemma", Description = "A natural history of four meals", ISBN = "978-1111111111", PublicationDate = new DateTime(2006, 4, 11), Price = 16.99m, StockQuantity = 40, AuthorId = 6, CategoryId = 6 },
                new Book { Title = "Jerusalem: A Cookbook", Description = "Recipes from the heart of the Middle East", ISBN = "978-2222222222", PublicationDate = new DateTime(2012, 10, 23), Price = 35.00m, StockQuantity = 30, AuthorId = 8, CategoryId = 1 },
                new Book { Title = "Organic Farming Handbook", Description = "Complete guide to organic farming", ISBN = "978-3333333333", PublicationDate = new DateTime(2022, 3, 8), Price = 24.99m, StockQuantity = 35, AuthorId = 7, CategoryId = 7 },
                new Book { Title = "The Art of Simple Food", Description = "Notes, lessons, and recipes from a delicious revolution", ISBN = "978-4444444444", PublicationDate = new DateTime(2007, 10, 30), Price = 32.00m, StockQuantity = 28, AuthorId = 7, CategoryId = 2 },
                new Book { Title = "Ottolenghi Simple", Description = "Easy recipes for home cooking", ISBN = "978-5555555555", PublicationDate = new DateTime(2018, 9, 4), Price = 30.00m, StockQuantity = 45, AuthorId = 8, CategoryId = 1 },
                new Book { Title = "Kitchen Confidential", Description = "Adventures in the culinary underbelly", ISBN = "978-6666666666", PublicationDate = new DateTime(2000, 5, 22), Price = 18.99m, StockQuantity = 20, AuthorId = 5, CategoryId = 8 }
            };

            _context.Books.AddRange(books);
            await _context.SaveChangesAsync();

            // Seed Reading Spots
            var readingSpots = new List<ReadingSpot>
            {
                new ReadingSpot { Name = "Book & Brew Corner", Description = "Cozy reading area with coffee service", Location = "Near the entrance", Capacity = 20, IsAvailable = true, Amenities = "Coffee, WiFi, Comfortable seating" },
                new ReadingSpot { Name = "Garden Reading Nook", Description = "Peaceful reading area near the garden section", Location = "Near fresh produce", Capacity = 15, IsAvailable = true, Amenities = "Natural light, Plants, Quiet atmosphere" },
                new ReadingSpot { Name = "Chef's Corner", Description = "Reading area near the cooking section", Location = "Near cooking supplies", Capacity = 12, IsAvailable = true, Amenities = "Cooking magazines, Recipe books, Coffee" },
                new ReadingSpot { Name = "Kids Reading Zone", Description = "Family-friendly reading area", Location = "Near the bakery", Capacity = 25, IsAvailable = true, Amenities = "Children's books, Coloring supplies, Kid-friendly seating" }
            };

            _context.ReadingSpots.AddRange(readingSpots);
            await _context.SaveChangesAsync();

            // Seed Events
            var events = new List<Event>
            {
                new Event { Title = "Mediterranean Cooking Demo", Description = "Learn to cook Mediterranean dishes with our chef", StartTime = DateTime.Now.AddDays(7), EndTime = DateTime.Now.AddDays(7).AddHours(2), Location = "Cooking Demo Area", MaxCapacity = 30, CurrentAttendees = 0, EventType = "Cooking Demo", IsActive = true },
                new Event { Title = "Storytime for Kids", Description = "Interactive story reading for children", StartTime = DateTime.Now.AddDays(3), EndTime = DateTime.Now.AddDays(3).AddHours(1), Location = "Kids Reading Zone", MaxCapacity = 20, CurrentAttendees = 0, EventType = "Storytime", IsActive = true },
                new Event { Title = "Organic Farming Workshop", Description = "Learn about organic farming practices", StartTime = DateTime.Now.AddDays(14), EndTime = DateTime.Now.AddDays(14).AddHours(3), Location = "Garden Area", MaxCapacity = 25, CurrentAttendees = 0, EventType = "Workshop", IsActive = true },
                new Event { Title = "Book Signing: Chef's New Cookbook", Description = "Meet the author and get your book signed", StartTime = DateTime.Now.AddDays(10), EndTime = DateTime.Now.AddDays(10).AddHours(2), Location = "Book & Brew Corner", MaxCapacity = 40, CurrentAttendees = 0, EventType = "Book Signing", IsActive = true }
            };

            _context.Events.AddRange(events);
            await _context.SaveChangesAsync();

            // Create relationships between books and products
            var book1 = await _context.Books.FirstAsync(b => b.Title.Contains("Mediterranean"));
            var oliveOil = await _context.Products.FirstAsync(p => p.Name.Contains("Olive Oil"));
            var balsamic = await _context.Products.FirstAsync(p => p.Name.Contains("Balsamic"));
            var basil = await _context.Products.FirstAsync(p => p.Name.Contains("Basil"));
            var tomatoes = await _context.Products.FirstAsync(p => p.Name.Contains("Tomatoes"));

            book1.RelatedProducts.Add(oliveOil);
            book1.RelatedProducts.Add(balsamic);
            book1.RelatedProducts.Add(basil);
            book1.RelatedProducts.Add(tomatoes);

            // Create relationships between books and departments
            var organicBook = await _context.Books.FirstAsync(b => b.Title.Contains("Organic Farming"));
            var organicDept = await _context.Departments.FirstAsync(d => d.Name.Contains("Organic"));
            var sustainableDept = await _context.Departments.FirstAsync(d => d.Name.Contains("Sustainable"));

            organicBook.RelatedDepartments.Add(organicDept);
            organicBook.RelatedDepartments.Add(sustainableDept);

            // Create relationships between books and events
            var mediterraneanBook = await _context.Books.FirstAsync(b => b.Title.Contains("Mediterranean"));
            var cookingEvent = await _context.Events.FirstAsync(e => e.Title.Contains("Mediterranean"));
            var organicBook2 = await _context.Books.FirstAsync(b => b.Title.Contains("Organic Farming"));
            var workshopEvent = await _context.Events.FirstAsync(e => e.Title.Contains("Organic"));

            mediterraneanBook.Events.Add(cookingEvent);
            organicBook2.Events.Add(workshopEvent);

            await _context.SaveChangesAsync();

            Console.WriteLine("✅ Database seeded successfully with sample data!");
        }
    }
} 