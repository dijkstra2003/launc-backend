FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./*.sln ./
COPY ./src/API.Web/API.Web.csproj ./API.Web.csproj
RUN dotnet restore API.Web.csproj

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out ./src/API.Web/API.Web.csproj

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.0
WORKDIR /app
COPY --from=build-env /app/out .

EXPOSE 80

ENV LAUNC_DEFAULT_CONNECTION_STRING

# Run the runtime
ENTRYPOINT ["dotnet", "API.Web.dll"]
