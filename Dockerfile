FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
USER $APP_UID

# Api
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /


COPY ./src ./
RUN dotnet restore "CapitalPlacement.Api/CapitalPlacement.Api.csproj"

# Set the build directory
WORKDIR /CapitalPlacement.Api

RUN dotnet build --no-restore "CapitalPlacement.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish Api release
FROM build AS api-publish

WORKDIR /CapitalPlacement.Api
RUN dotnet publish -c $BUILD_CONFIGURATION -o /app/publish

# Build api runtime image
FROM base AS final
WORKDIR /app
COPY --from=api-publish /app/publish .
ENTRYPOINT ["dotnet", "CapitalPlacement.Api.dll"]
