## Technologies

- .NET 5.0
- Docker
- Postgresql
- EF
- FluentAssertions
- FluentValidation
- XUnit

## Dependencies
```
- Npgsql.EntityFrameworkCore.PostgreSQL > 5.0.7
- FluentAssertions > 6.6.0
- Moq > 4.17.2
 ```
 # Running app in Docker

 Execute for running app : 
 `docker-compose up --build`
 `docker build -t mars-rover .`
 `docker run mars-rover:latest`
                         
 # Setup Notes
```
- Postgres in local application appsettings.json : "Server=localhost;database=postgres;"
- Postgres in docker (prod) appsettings.json : "Server=host.docker.internal;database=MarsRover;"
```


### Request
 ```
5 5
1 2 N
LMLMLMLMM
3 3 E
   ```
   ### Response
 ```
 1 3 N
5 1 E
 ```
                                  
