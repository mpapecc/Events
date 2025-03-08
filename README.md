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
