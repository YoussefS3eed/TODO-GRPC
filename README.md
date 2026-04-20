<div align="center">

# 📝 TODO-GRPC

**A High-Performance ToDo API powered by .NET 10 & gRPC**

[![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![gRPC](https://img.shields.io/badge/gRPC-RPC-244c5a?logo=grpc&logoColor=white)](https://grpc.io/)
[![SQLite](https://img.shields.io/badge/SQLite-07405E?logo=sqlite&logoColor=white)](https://www.sqlite.org/)
[![EF Core](https://img.shields.io/badge/EF%20Core-ORM-blueviolet)](https://learn.microsoft.com/en-us/ef/core/)

*Experience the speed of gRPC with the convenience of RESTful APIs via JSON Transcoding.*

</div>

---

## 📖 Overview

**TODO-GRPC** is a robust backend service designed to manage ToDo tasks. By leveraging the power of **gRPC** inside ASP.NET Core, it offers incredibly fast remote procedure calls. 

But there's a twist! Thanks to **gRPC JSON Transcoding**, this project simultaneously exposes traditional RESTful HTTP APIs. Clients can choose whether to integrate via standard `HTTP/JSON` endpoints or via high-performance gRPC clients—all without maintaining duplicate controller logic.

## ✨ Key Features

- ⚡ **Blazing Fast RPC:** Built on HTTP/2 and Protobuf for lightweight, heavily optimized communication.
- 🌐 **RESTful Transcoding:** Automatically generates REST endpoints (`GET`, `POST`, `PUT`, `DELETE`) from `.proto` files.
- 📦 **Embedded Database:** Uses **SQLite** for instant setup and zero configuration out of the box.
- 🛠️ **Entity Framework Core:** Clean data-access architecture managed entirely through EF Core.

## 🛠️ Built With

* **[.NET 10](https://dotnet.microsoft.com/)** - The underlying framework providing exceptional performance.
* **[ASP.NET Core gRPC](https://learn.microsoft.com/en-us/aspnet/core/grpc/?view=aspnetcore-8.0)** - RPC framework integration.
* **[gRPC JSON Transcoding](https://learn.microsoft.com/en-us/aspnet/core/grpc/json-transcoding?view=aspnetcore-8.0)** - Exposing gRPC services as RESTful APIs.
* **[Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/)** - Modern Object-Relational Mapper (ORM).
* **[SQLite](https://www.sqlite.org/)** - Lightweight database engine.

---

## 🚦 API Endpoints

Through gRPC JSON Transcoding, traditional REST endpoints are mapped seamlessly. 

| Method | Endpoint | Description | gRPC Method |
| :---: | :--- | :--- | :--- |
| `POST` | `/v1/todo` | Create a new ToDo | `CreateToDo` |
| `GET` | `/v1/todo` | Retrieve all ToDos | `ListToDo` |
| `GET` | `/v1/todo/{id}` | Retrieve a specific ToDo | `ReadToDo` |
| `PUT` | `/v1/todo` | Update an existing ToDo | `UpdateToDo` |
| `DELETE` | `/v1/todo/{id}` | Delete a specific ToDo | `DeleteToDo` |

> **Note:** Because this uses JSON Transcoding, you can test these exact endpoints using tools like **Postman** or **cURL**, just as you would with a typical Web API.

---

## 🚀 Getting Started

Follow these steps to get a local copy up and running quickly.

### Prerequisites

* [.NET 10 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/10.0)

### Installation & Execution

1. **Clone & Navigate**
   ```bash
   cd TODO-GRPC/TODO-GRPC
   ```

2. **Run Database Migrations** 
   Set up the local SQLite database schema.
   ```bash
   dotnet ef database update
   ```
   *The `ToDoDatabase.db` file will either be created or updated automatically.*

3. **Launch the Service**
   ```bash
   dotnet run
   ```
   *Your terminal will display the active ports where the gRPC/REST APIs are listening.*

---

## 📁 Project Structure

```text
📦 TODO-GRPC
 ┣ 📂 Protos/        # Protocol Buffer files defining services (todo.proto)
 ┣ 📂 Models/        # Entity Framework classes (ToDoItem.cs)
 ┣ 📂 Data/          # EF Core Database Context (AppDbContext.cs)
 ┣ 📂 Services/      # C# implementations of the generated gRPC services
 ┗ 📜 Program.cs     # App entry point (gRPC configuration & JSON Transcoding)
```

<div align="center">
  <i>Built with using modern .NET Architecture</i>
  <i>Made with ❤️ by <a href="https://github.com/YoussefS3eed">Youssef S3eed</a></i>
</div>
