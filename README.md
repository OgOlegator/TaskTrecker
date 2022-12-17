# TaskTrecker

The application is a repository of tasks for projects.

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
Add-migration <Name_migration>
Update-database

# Project description

Models

![image](https://user-images.githubusercontent.com/92753056/208234094-24f0f69c-2b7b-4422-8a77-3eed1b4ca1d2.png)

Api structure

![image](https://user-images.githubusercontent.com/92753056/208257415-f0c1b409-37ca-4193-9718-aa1c58d6195e.png)
