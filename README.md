# QuickBite Food Menu Management API

A robust .NET 9 Web API for managing restaurant food menus with comprehensive validation, error handling, and test coverage.

## 🚀 Features

- **CRUD Operations** for food items
- **Input Validation** with FluentValidation
- **Error Handling** with custom middleware
- **Data Seeding** with sample food items
- **Comprehensive Testing** (Unit, Integration, Validation)
- **SQLite Database** with Entity Framework Core
- **RESTful API** with Swagger documentation
- **GUID-based IDs** for better security
- **Enum Support** for categories and dietary tags

## 🛠️ Tech Stack

- **.NET 9.0** - Framework
- **ASP.NET Core Web API** - API framework
- **Entity Framework Core** - ORM
- **SQLite** - Database (Development)
- **Docker** - Containerization
- **FluentValidation** - Input validation
- **XUnit** - Testing framework
- **FluentAssertions** - Test assertions
- **Swagger/OpenAPI** - API documentation

## 📋 Prerequisites

- .NET 9.0 SDK
- Visual Studio 2022 or Visual Studio Code
- SQLite (included with .NET)
- **Docker** (optional, for containerized deployment)

## 🔧 Installation & Setup

1. **Clone the repository**
   ```bash
   git clone https://github.com/gauravsiwach/QuickBite-FoodMenuManagement.git
   cd QuickBite-FoodMenuManagement
   ```

2. **Restore dependencies**
   ```bash
   dotnet restore
   ```

3. **Build the solution**
   ```bash
   dotnet build
   ```

4. **Run the API**
   ```bash
   cd QuickBite.API
   dotnet run
   ```

5. **Access the API**
   - API Base URL: `http://localhost:5289`
   - Swagger UI: `http://localhost:5289/swagger`

## 🐳 Docker Deployment

### Build and Run with Docker

1. **Build the Docker image**
   ```bash
   docker build -t quickbite-api .
   ```

2. **Run the container**
   ```bash
   docker run -d \
     --name quickbite-api \
     -p 8080:8080 \
     -v quickbite-data:/app/data \
     quickbite-api
   ```

3. **Access the containerized API**
   - API Base URL: `http://localhost:8080`
   - Swagger UI: `http://localhost:8080/swagger`

4. **View logs**
   ```bash
   docker logs quickbite-api
   ```

5. **Stop and remove the container**
   ```bash
   docker stop quickbite-api
   docker rm quickbite-api
   ```

### Docker Features
- ✅ **Multi-stage build** for optimized image size
- ✅ **Non-root user** for enhanced security
- ✅ **Health checks** for container monitoring
- ✅ **Persistent data** with Docker volumes
- ✅ **Production-ready** configuration

## 📊 Database

The application uses SQLite for development with automatic database creation and data seeding.

### Seeded Data
The API automatically seeds 12 sample food items covering:
- **Appetizers**: Buffalo Wings, Breadsticks, Hummus Platter
- **Main Courses**: Margherita Pizza, Beef Burger, Thai Curry
- **Salads**: Caesar Salad, Buddha Bowl
- **Soups**: Tomato Basil, French Onion
- **Desserts**: Chocolate Lava Cake, Cheesecake

## 🎯 API Endpoints

### Food Items

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/fooditems` | Get all food items |
| GET | `/api/fooditems/{id}` | Get food item by ID |
| POST | `/api/fooditems` | Create new food item |
| PUT | `/api/fooditems/{id}` | Update food item |
| DELETE | `/api/fooditems/{id}` | Delete food item |

### Request/Response Examples

#### Create Food Item
```json
POST /api/fooditems
{
  "name": "Margherita Pizza",
  "description": "Traditional Italian pizza with fresh mozzarella",
  "price": 16.99,
  "category": "MainCourses",
  "dietaryTag": "Vegetarian"
}
```

#### Response
```json
{
  "id": "123e4567-e89b-12d3-a456-426614174000",
  "name": "Margherita Pizza",
  "description": "Traditional Italian pizza with fresh mozzarella",
  "price": 16.99,
  "category": "MainCourses",
  "dietaryTag": "Vegetarian",
  "createdAt": "2025-09-20T10:30:00Z",
  "updatedAt": "2025-09-20T10:30:00Z"
}
```

## 📝 Data Models

### Food Item
```csharp
public class FoodItem
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public FoodCategory Category { get; set; }
    public DietaryTag? DietaryTag { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
```

### Enums
```csharp
public enum FoodCategory
{
    Appetizers = 1,
    MainCourses = 2,
    Desserts = 3,
    Beverages = 4,
    Salads = 5,
    Soups = 6
}

public enum DietaryTag
{
    Vegetarian = 1,
    Vegan = 2,
    GlutenFree = 3,
    DairyFree = 4,
    Spicy = 5
}
```

## ✅ Validation Rules

### Create/Update Food Item
- **Name**: Required, 1-100 characters, cannot be whitespace
- **Description**: Optional, max 1000 characters
- **Price**: Required, must be greater than 0
- **Category**: Required, must be valid enum value
- **DietaryTag**: Optional, must be valid enum value if provided

## 🧪 Testing

The project includes comprehensive test coverage:

### Run All Tests
```bash
dotnet test
```

### Test Categories
- **Unit Tests**: Service and validator logic
- **Integration Tests**: End-to-end API functionality
- **Validation Tests**: Input validation scenarios

### Test Coverage
- **73 Tests** total
- Unit tests for services and validators
- Integration tests for all endpoints
- Edge case and error scenario testing

## 🔐 Error Handling

The API includes comprehensive error handling:

- **400 Bad Request**: Validation errors
- **404 Not Found**: Resource not found
- **500 Internal Server Error**: Unexpected errors

### Error Response Format
```json
{
  "type": "https://tools.ietf.org/html/rfc9110#section-15.5.1",
  "title": "One or more validation errors occurred.",
  "status": 400,
  "errors": {
    "Name": ["Name is required"],
    "Price": ["Price must be greater than 0"]
  },
  "traceId": "00-trace-id-00"
}
```

## 📁 Project Structure

```
QuickBite-FoodMenuManagement/
├── QuickBite.API/
│   ├── Controllers/         # API controllers
│   ├── Data/               # Database context
│   ├── Middleware/         # Custom middleware
│   ├── Models/             # Entities, DTOs, Enums
│   ├── Services/           # Business logic
│   ├── Validators/         # FluentValidation rules
│   └── Program.cs          # Application entry point
├── QuickBite.Tests/
│   ├── Unit/               # Unit tests
│   └── Integration/        # Integration tests
├── docs/                   # Documentation
├── Dockerfile              # Docker configuration
├── .dockerignore           # Docker ignore file
└── README.md
```

## 🚀 Development Workflow

### Adding New Features
1. Write tests first (TDD approach)
2. Implement feature
3. Ensure all tests pass
4. Update documentation

### Code Quality
- Follow SOLID principles
- Use dependency injection
- Implement proper error handling
- Maintain test coverage

## 🔄 CI/CD

The project is set up for continuous integration with:
- Automated testing on push
- Build verification
- Code quality checks

## 📚 Documentation

- **API Documentation**: Available via Swagger UI
- **Code Documentation**: Inline comments and XML docs
- **Architecture**: Layered architecture with separation of concerns

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Add/update tests
5. Ensure all tests pass
6. Submit a pull request

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 👨‍💻 Author

**Gaurav Siwach**
- GitHub: [@gauravsiwach](https://github.com/gauravsiwach)

## 🙏 Acknowledgments

- Built with .NET 9 and modern development practices
- Following RESTful API design principles
- Test-driven development approach
- Clean architecture patterns

---

## 📞 Support

For support, please open an issue on the GitHub repository or contact the development team.

**Happy Coding! 🍕**