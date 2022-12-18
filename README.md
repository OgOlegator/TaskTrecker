# TaskTrecker

The application is a repository of tasks for projects. Web API for entering project data into the database (task tracker).
Each task is part of one of the projects. A project is an object that contains a name, an identifier (and also contains Task objects).

Application features:
- Create/Modify/Delete a project
- Obtaining information about projects / project (using various filters)
- Create/Modify/Delete tasks
- Getting information about tasks/tasks (using various filters)

Using technologies: 
- .Net Core, 
- WebApi, 
- EF Core.

Using database: 
- MsSql

# Project setup instructions
Using NuGet:
- AutoMapper (12.0.0)
- AutoMapper.Extensions.Microsoft.DependencyInjection (12.0.0)
- Microsoft.EntityFrameworkCore.SqlServer (7.0.0)
- Microsoft.EntityFrameworkCore.Tools (7.0.0)
- Swashbuckle.AspNetCore (6.2.3)
- Swashbuckle.AspNetCore.Newtonsoft (6.4.0)

The database connection string is stored in a file appsettings.json

Script create database:
- Add-migration <Name_migration>
- Update-database

# Project description

The application has a two-tier model-controller architecture.

Responsible for working with the database:
Models:
- Project
- Task

Data transfer objects:
- ProjectDto (For Project model)
- TaskDto (For the Task model)
- ResponseDto (WebApi response format)

The ApplicationDbContext class is responsible for communicating with the database.

Interaction with the database is described in interfaces:
- IProjectRepository
-ITaskRepository

And implemented in classes:
- ProjectRepository
- TaskRepository

API controllers:
- ProjectController
-TaskController

Models

![image](https://user-images.githubusercontent.com/92753056/208264418-1dc9e226-89fa-409c-ace2-f038e2369389.png)

Api structure

![image](https://user-images.githubusercontent.com/92753056/208264331-7a17e2fc-ef95-4801-808e-8ee8ce0091db.png)
