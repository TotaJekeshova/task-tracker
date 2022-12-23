# Task-tracker
Web API for entering project data into the database (task tracker)

## Dependencies:
- Microsoft.EntityFrameworkCore.Design Version=6.0.11
- Npgsql.EntityFrameworkCore.PostgreSQL Version=6.0.7
- AutoMapper Version=12.0.0
- Ardalis.ApiEndpoints Version=4.0.1
- MediatR Version=11.1.0 
- Swashbuckle.AspNetCore Version=6.2.3
- Swashbuckle.AspNetCore.Annotations Version=6.4.0

## Installation:
1. Clone the repository - https://github.com/TotaJekeshova/task-tracker.git
2. Add your username and password to "ConnectionStrings" in appsettings.json file
``` 
"ConnectionStrings": {
    "TrackerStorageConnectionString": "Server=localhost;Port=5432;Database=TasksTrackerDb;Username=postgres;Password=111;"
  }
``` 
3. To create or update database run this command in terminal
``` 
dotnet ef database update
``` 

## Run:
1. Open project in IDE (JetBrains Rider) 
2. Press "RUN" button in your IDE. 
This should start web-server to serve Task_tracker.API
``` 
https://localhost:7232/swagger/index.html
``` 

## Useful links:
- Overview of Entity Framework Core:  https://learn.microsoft.com/en-us/ef/core/
