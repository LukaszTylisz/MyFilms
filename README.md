## MyFilms

This is repository for a web application built with `ASP.NET Core 8 Web API`.  includes instructions for setting up the development environment, running the application and managing database migrations with Entity Framework Core. It's a personal application to catch from external API movies and user has a possibility to use CRUD actions.

## Requirements

Before you begin, ensure you have the following software installed on your system:

- [.NET Core 8 SDK]
- [Node.js]

## Development Setup
1. Clone this repository:
   ```bash
   git clone https://github.com/LukaszTylisz/MyFilms.git
   
2. Create a database and apply migrations:
   ```bash
    dotnet ef database update
3. cd Client
    ```bash
    npm install
4. npm run serve
5. Back end run on: https://localhost:7235/ and front end on: https://localhost:8080

### Solution structure

![image](https://github.com/LukaszTylisz/MyFilms/assets/86656091/98f0bbb9-3836-4d94-adf4-47ac92b5f6ac)

### Swagger

![image](https://github.com/LukaszTylisz/MyFilms/assets/86656091/e1bcb575-c17e-4174-b0f3-cc4ded1ee5bc)

### Front end

![image](https://github.com/LukaszTylisz/MyFilms/assets/86656091/edc4923d-249d-454a-b829-9894fb0d1276)

It's not pretty yet, it was my first time with Vue.js

### Architecture overview

With Clean Architecture, the `Domain` and `Application` layers are at the center of the design. This is known as the `Core` of the system. 

The Domain layer contains enterprise logic and types and the Application layer contains business logic and types.
The Core shouldn’t be dependent on concerns such as `Persistence` (Data Access) and `Infrastructure`, so we invert those dependencies.

This is achieved by adding interfaces and abstractions within Core, which are implemented by layers outside Core such as Infrastructure. Front end site is made by Vue.js and it's connecting with backend using the WEB API. User can get all movies, get by Id, update, delete or fetch movies from external API. All data is saved in MSSQL database.

All dependencies flow inwards, and Core has no dependencies on any other layers.
Infrastructure and Presentation depend on Core, but not on one another.

#### The architecture is based on the following architectural principles:
- Separation of concerns
- Dependency Inversion
- Single Responsibility
- DRY
- Persistence Ignorance

This results in a design that is: 
- Independent of UI, databases, frameworks
- Clean, maintainable, testable

### Technologies
- ASP.NET Core 8 Web API
- Onion Architecture
- CQRS with MediatR
- Fluent Validation
- Automapper
- Feature‑based folder organization
- Entity Framework Core
- Repository Pattern
- Swagger UI
- In-Memory Database for Integration Tests
