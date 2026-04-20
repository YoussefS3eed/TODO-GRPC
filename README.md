# TODO-GRPC

A modern **ToDo Application Backend** built using `.NET 10`, **gRPC**, and **Entity Framework Core**. 
This project leverages **gRPC JSON Transcoding** to expose traditional RESTful HTTP APIs alongside the high-performance gRPC services, allowing clients to interact with the API using standard HTTP/JSON requests or gRPC clients.

## Features

- **gRPC Services:** High-performance RPC framework for creating, reading, updating, and deleting ToDo items.
- **RESTful Endpoints:** Automatic transcoding of gRPC services to REST APIs via `Microsoft.AspNetCore.Grpc.JsonTranscoding`.
- **Database:** Uses **SQLite** for lightweight, local data storage.
- **Entity Framework Core:** EF Core is used as the ORM to manage database interactions and migrations.

## Technologies Used

- .NET 10.0
- ASP.NET Core gRPC (`Grpc.AspNetCore`)
- gRPC JSON Transcoding (`Microsoft.AspNetCore.Grpc.JsonTranscoding`)
- Entity Framework Core (`Microsoft.EntityFrameworkCore.Sqlite`, `Microsoft.EntityFrameworkCore.Tools`)
- Protobuf (Google Protocol Buffers)

## API Endpoints

Through gRPC JSON Transcoding, the following HTTP endpoints are exposed alongside the gRPC service definition:

| Action | HTTP Method | Endpoint | gRPC RPC Method |
| :--- | :--- | :--- | :--- |
| **Create ToDo** | `POST` | `/v1/todo` | `CreateToDo` |
| **Get All ToDos** | `GET` | `/v1/todo` | `ListToDo` |
| **Get ToDo by ID** | `GET` | `/v1/todo/{id}` | `ReadToDo` |
| **Update ToDo** | `PUT` | `/v1/todo` | `UpdateToDo` |
| **Delete ToDo** | `DELETE` | `/v1/todo/{id}` | `DeleteToDo` |

## Getting Started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/10.0)

### Running the Application

1. **Clone the repository:**
   Navigate to the project directory:
   ```bash
   cd TODO-GRPC/TODO-GRPC
   ```

2. **Apply Database Migrations:**
   Ensure the SQLite database is created and up to date:
   ```bash
   dotnet ef database update
   ```
   *(Note: The database file `ToDoDatabase.db` might already be present in the repository.)*

3. **Build and Run:**
   ```bash
   dotnet run
   ```
   The application will start, and the gRPC services along with the transcoded REST endpoints will be available.

## Project Structure

- **`Protos/`**: Contains the `.proto` files defining the gRPC services and messages (`todo.proto`, `greet.proto`). The API routing is configured inside `todo.proto` using `google.api.http` options.
- **`Models/`**: Contains Entity Framework Core entity classes (e.g., `ToDoItem.cs`).
- **`Data/`**: Contains the `AppDbContext` for EF Core.
- **`Services/`**: Contains the actual C# implementations of the gRPC services defined in the `.proto` files (e.g., `ToDoService.cs`).
- **`Program.cs`**: Application entry point where gRPC, EF Core, and JSON Transcoding are configured and services are mapped.
