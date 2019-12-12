# Launc backend
[![Build Status](https://travis-ci.com/dijkstra2003/launc-backend.svg?token=NHZZE7EcX4WkL29ZP9TB&branch=master)](https://travis-ci.com/dijkstra2003/launc-backend)

Main backend API for the Launc platform

To run the application in watch mode go to the root folder and run the following command:
```
dotnet watch -p ./src/API.Web/API.Web.csproj run
```

To run the application tests go to the root folder and run the following command:
```
dotnet test
```

To build the docker image run
```
docker build . -t launc
```

To add a migration to the project, go to the root folder and run the following command:  
Change $MIGRATIONS_NAME to the name you want to use for the migration.
```
dotnet ef migrations add $MIGRATIONS_NAME --context DataContext -p ./src/API.Infrastructure/API.Infrastructure.csproj -s ./src/API.Web/API.Web.csproj -o Data/Migrations
```
If you get an error about missing the dotnet ef you can run the following command:
```
dotnet tool install --global dotnet-ef --version 3.0.0
```
