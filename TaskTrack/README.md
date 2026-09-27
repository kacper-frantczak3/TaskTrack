# Task Track API

A clean and simple RESTful aPI for task management, built with .NET 10 and Entity Framework Core.

## Tech-Stack 
* **Language:** C# / .NET 10
* **Framework:** ASP.NET Core Web API
* **Database & ORM:** SQLite with EF Core
* **Environment:** JetBrains Rider (macOS)

## Features
* **GET** `/api/task` - Retrieve all tasks
* **GET** `/api/task/{id}` - Retrieve task by ID
* **POST** `/api/task` - Create a new task
* **PUT** `/api/task/{id}` - Update an existing task
* **DELETE** `/api/task/{id}` - Delete a task by ID

## How To Run Locally
1. Clone this repository:
    ```bash
   git clone https://github.com/kacper-frantczak3/TaskTrack.git
2. Open the project in JetBrains Rider or VS Code
3. Run the application. The SQLite database and schema will be created automatically on startup via `EnsureCreated()`
4. Test the endpoints using provided `TaskTrack.http` file directly in Rider or via any API client.