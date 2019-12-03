#!/bin/bash

set -e

dotnet ef database update -c DataContext \
     -p ./src/API.Infrastructure/API.Infrastructure.csproj \
     -s ./src/API.Web/API.Web.csproj

dotnet out/API.Web.dll