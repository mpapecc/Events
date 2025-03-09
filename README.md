# Events

A small app for managing events.

## Running the project

### Prerequisites
- Docker

### Setup
- run `docker compose up -w`

### Usage
- the Angular client app is running on `localhost`
- the .NET Web API is running on `localhost/api`, swagger on `localhost/swagger/index.html`
- pgAdmin is running on `localhost:5050`

### Development info
- both backed and frontend have hot reloading enabled
- installing dependencies for the client should be executed inside the container, ex. `docker compose exec client npm install`

### Rebuilding images
- after changes to Dockerfiles a new image needs to be built
- you can rebuild the image using the command `docker compose up --build -w`

### Running tests
- UNIT TESTS
  - you can run unit tests inside the container using the command `docker compose exec api dotnet test ../Events.Tests`

### Rider specific setup
- you can attach the Rider debugger to the process running inside the container.
  - Make sure the app us running in docker
  - Under "Run" select "Attach to process"
  - Select "Docker"
  - If prompted click "Install tools to the container" -> you need to run this every time the image is rebuilt
  - Select "Events.Api" and click "Attach with .NET Debugger"
  - Now you can add breakpoints as usual
