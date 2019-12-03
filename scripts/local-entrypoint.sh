#!/bin/bash

set -e

dotnet build

#dotnet build

#dotnet ef database update -c DataContext \
#     -p ./src/API.Infrastructure/API.Infrastructure.csproj \
#     -s ./src/API.Web/API.Web.csproj

# dotnet run watch --project src/API.Web --urls "http://0.0.0.0:5000;http://[::]:5000"
# dotnet run watch --project src/API.Web

