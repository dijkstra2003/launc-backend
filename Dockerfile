FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build-env
WORKDIR /app

ENV PATH="${PATH}:/root/.dotnet/tools"

# Copy everything and restore
COPY . ./
RUN dotnet restore ./src/API.Web/API.Web.csproj

# Install the Dotnet entity framework so we can run migrations
RUN dotnet tool install --global dotnet-ef --version 3.0.0

EXPOSE 80

RUN dotnet publish -c Release -o out ./src/API.Web/API.Web.csproj

ENV LAUNC_DB_HOST "localhost"
ENV LAUNC_DEFAULT_CONNECTION_STRING ""

RUN chmod +x ./scripts/wait-for-it.sh
RUN chmod +x ./scripts/local-entrypoint.sh
ENTRYPOINT ./scripts/wait-for-it $LAUNC_DB_HOST:5432 -- ./scripts/entrypoint.sh
