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
