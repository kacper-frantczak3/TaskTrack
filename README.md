# Task Track API

A clean and simple RESTful API for task management, built with .NET 10 and Entity Framework Core.

## Tech-Stack 
* **Language:** C# / .NET 10
* **Framework:** ASP.NET Core Web API
* **Database & ORM:** SQLite with EF Core
* **Documentation & UI:** Swashbuckle Swagger UI
* **Environment:** JetBrains Rider (macOS)

## Features
* **GET** `/api/task` - Retrieve tasks with advanced query parameters:
* `isCompleted` (boolean filter)
* `search` (text search across name and description)
* `pageNumber` & `pageSize` (pagination support)
* **GET** `/api/task/{id}` - Retrieve task by ID
* **POST** `/api/task` - Create a new task
* **PUT** `/api/task/{id}` - Update an existing task
* **DELETE** `/api/task/{id}` - Delete a task by ID

## Architecture & Highlights
* **Interactive Swagger UI:** Configured directly at the root URL for seamless testing and exploration.
* **Global Exception Handling Middleware:** Centralized error management that catches unhandled exceptions and returns standardized **ProblemDetails** responses (including custom handling for `KeyNotFoundException` yielding `404 Not Found`).
* **Automatic Database Initialization:** SQLite database (`tasks.db`) and schema are created automatically on application startup via `EnsureCreated()`.

## How To Run Locally
1. Clone this repository:
    ```bash
   git clone https://github.com/kacper-frantczak3/TaskTrack.git
2. Open the project in JetBrains Rider or VS Code
3. Run the application. The SQLite database and schema will be created automatically on startup via `EnsureCreated()`
4. Test the endpoints using provided `TaskTrack.http` file directly in Rider or via any API client.
