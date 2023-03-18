# **Gerdisc**

Gerdisc is a web-based information system designed to manage the registration and information of students enrolled in the MSc program in Computer Science at CEFET/RJ. The system is intended to replace the current spreadsheet-based approach, which has become increasingly cumbersome to manage as the volume of data grows.

### Architecture

The project follows a typical N-tier architecture, with the following layers:

    Presentation (controllers and models)
    Service (business logic)
    Data (repositories and database context)

##### Presentation Layer
The presentation layer consists of controllers and models, which define the API endpoints and the data transfer objects (DTOs) used to transfer data between the API and the service layer.
Service Layer
The models represent the data structures of the entities in the system, such as Student, Teacher, ResearchLine, and ResearchProject. These models are used to map the database tables and to perform CRUD (Create-Read-Update-Delete) operations on the data.
Views
The controllers handle the HTTP requests and responses, and they are responsible for executing the logic of the application. Each entity in the system has its own controller, such as StudentsController, TeachersController, ResearchLinesController, and ResearchProjectsController. These controllers expose endpoints for creating, reading, updating, and deleting data for their respective entities.
Services

##### Service Layer 
The service layer contains the business logic of the application. It communicates with the data layer (repositories and database context) to perform CRUD operations on the database.
The services layer contains the business logic of the application. The services are used by the controllers to perform complex operations that require multiple database queries or complex calculations. In Gerdisc, each entity has its own service, such as StudentService, TeacherService, ResearchLineService, and ResearchProjectService.
Repository

##### Data Layer

The data layer consists of repositories and a database context. The repositories encapsulate the data access logic, while the database context provides a connection to the database and manages the entities.

The repository layer is responsible for communicating with the database. It uses Entity Framework to perform the CRUD operations on the database tables. In Gerdisc, each entity has its own repository, such as StudentRepository, TeacherRepository, ResearchLineRepository, and ResearchProjectRepository. The repositories are used by the services to access the data.

### Technologies Used

    ASP.NET Core
    Entity Framework Core
    Npgsql (PostgreSQL database provider)
    Other technologies used in the project.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.
Prerequisites

    .NET Core SDK
    PostgreSQL

### Installing

    Clone the repository to your local machine.
    Configure the database connection string in appsettings.json.
    Run the database migrations to create the required tables in the database.
    Run the project.
    ```
    git clone https://github.com/yourusername/gerdisc.git
    cd gerdisc
    dotnet ef database update
    dotnet run
    ```

### Usage

The application exposes the following endpoints:

    GET /api/students: Returns a list of all students.
    GET /api/students/{id}: Returns the student with the specified ID.
    POST /api/students: Creates a new student.
    PUT /api/students/{id}: Updates the student with the specified ID.
    DELETE /api/students/{id}: Deletes the student with the specified ID.