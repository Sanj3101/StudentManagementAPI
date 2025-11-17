# StudentManagementAPI

🚀 How to Run the API
1. Clone the Repository
git clone https://github.com/<your-username>/StudentManagementAPI.git
cd StudentManagementAPI

2. Run the Project

Using Visual Studio:
➡️ Press F5

Using .NET CLI:

dotnet run

🌐 API will start at:
`https://localhost:<your-port>/`


Open Swagger UI for testing:

👉 `https://localhost:<your-port>/swagger`

📡 API Endpoints

Below are all the available API routes and example requests.

📋 1. GET — Retrieve All Students

Endpoint:

GET /api/students


Response Example

```json
{
  "success": true,
  "message": "Students retrieved successfully",
  "data": [
    {
      "id": 1,
      "firstName": "John",
      "lastName": "Doe",
      "email": "john@example.com",
      "age": 20
    }
  ]
}
```

🔍 2. GET — Retrieve Student by ID

Endpoint:

GET /api/students/{id}


Example:

GET /api/students/3


404 Response

```json
{
  "success": false,
  "message": "Student with ID 3 not found"
}
```

✏️ 3. POST — Create a New Student

Endpoint:

POST /api/students


Request Body
```json
{
  "firstName": "Sanjana",
  "lastName": "Biswas",
  "email": "sanjana@example.com",
  "age": 21
}
```

Success Response
```json
{
  "success": true,
  "message": "Student created successfully",
  "data": { "id": 4 }
}
```

Validation Error Example

```json
{
  "success": false,
  "message": "Validation failed",
  "errors": [
    "Email must be valid.",
    "First name is required."
  ]
}
```

🔄 4. PUT — Update a Student

Endpoint:

PUT /api/students


Request Body

```json
{
  "id": 4,
  "firstName": "Aditi",
  "lastName": "Sharma",
  "email": "aditi.sharma@example.com",
  "age": 22
}
```

Success Response

```json
{
  "success": true,
  "message": "Student updated successfully"
}
```

Not Found Response

```json
{
  "success": false,
  "message": "Student not found"
}
```

❌ 5. DELETE — Remove a Student

Endpoint:

DELETE /api/students/{id}


Example:

DELETE /api/students/4


Success Response

```json
{
  "success": true,
  "message": "Student deleted successfully"
}
```

Not Found Response

```jsonn
{
  "success": false,
  "message": "Student with ID 4 not found"
}
```

🧱 Project Structure
```txt
StudentManagementAPI/
│
├── Application/
│   ├── Commands/
│   ├── Queries/
│   └── Handlers/
│
├── Behaviors/              
├── Controllers/            # API endpoints
├── Data/                   # DbContext + InMemory DB
├── Models/                 # Entities + ApiResponse
└── Program.cs
```

🎯 Tech Used

ASP.NET Core 9 Web API

MediatR

FluentValidation

Entity Framework Core (InMemory)

Swagger / OpenAPI
