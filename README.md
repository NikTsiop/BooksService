# BooksService API - Clean Architecture Implementation

## Overview
This project is a modular and scalable .NET 8 RESTful API built using Clean Architecture principles. It serves as a demo application for managing books, users, roles, and categories. It also includes features like auditing, validation, and scheduled background services.

## Technologies Used
- .NET 8
- Entity Framework Core (Code-First + SQLite)
- MediatR
- AutoMapper
- FluentValidation
- xUnit for testing
- Docker

## Project Structure (Clean Architecture)
```
BooksService
├── BooksService.Api             --> Entry point (Controllers, Middleware, Program.cs)
├── BooksService.Application     --> Business logic (Commands, Queries, Validators, Interfaces)
├── BooksService.Domain          --> Domain models and exceptions
├── BooksService.Infrastructure  --> Audit 
├── BooksService.Persistence     --> EF DbContext, Repositories, Decorators, Configuration
└── BooksService.Tests           --> Unit tests (xUnit, Moq)
```

## Features Implemented

### Domain
- User, Role, Book, Category entities with relationships
- Business validation methods in domain (e.g. `Category.EnsureDeletable()`)

### Application Layer
- CQRS with MediatR (Commands/Handlers)
  - `CreateUserCommand`
  - `UpdateUserRoleCommand`
  - `DeleteCategoryCommand`
- DTOs and AutoMapper Profiles
- FluentValidation for input validation

### Persistence Layer
- EF Core DbContext with SQLite
- Repository pattern + generic decorators:
  - `AuditAddDecorator<TEntity>`
  - `AuditUpdateDecorator<TEntity>`
  - `AuditDeleteDecorator<TEntity>`
- Seeding of sample data (Users, Roles, Books, Categories)

### API Layer
- Controllers for Users, Books, etc.
- Swagger UI
- Global Exception Middleware
- API Response Models (PagedResponse, ErrorResponse, etc.)

### Background Services
- `AuditCleanupService`: Deletes audit records older than 20 days

## Testing
- xUnit used for testing command handlers
- Moq used for mocking dependencies
- Tests included for:
  - `CreateUserCommandHandler`
  - `UpdateUserRoleCommandHandler`
  - `DeleteCategoryCommandHandler`

## Audit Logging
- Dedicated `AuditLogs` table
- Tracks Create, Update, Delete actions via decorators
- Background cleanup service runs daily to delete old logs

## Docker
- Dockerfile for the API
- SQLite database stored in the container file system

## Getting Started
1. Run the app:
```bash
dotnet run --project BooksService.Api
```

## Note
- Dummy data is inserted on DB initialization only if the DB is newly created.
- Decorators are injected using interfaces like `IAddRepository<TEntity>`, `IUpdateRepository<TEntity>`, etc.

## Summary
This app demonstrates a solid Clean Architecture design with separation of concerns, testability, and scalability. It includes decorators, audit logging, background processing, and custom validation.

