# Events

A small app for managing events.

## Running the project

### Prerequisites
- Docker

### Setup
- run `docker compose up -w`

### Usage
- the Angular client app is running on `localhost`
- the .NET Web API is running on `localhost/api`, swagger on `localhost/api/swagger/index.html`
- pgAdmin is running on `localhost:5050`

### Development info
- both backed and frontend have hot reloading enabled
- installing dependencies for the client should be executed inside the container, ex. `docker compose exec client npm install`

### Managing Database
Adding migrations and updating database have to be made from inside container from location usr/src/api. 
- Add migration : `dotnet ef migrations add -s Events.Api -p Events.Persistance`
- Update database : `dotnet ef database update -s Events.Api -p Events.Persistance`