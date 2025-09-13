# Base runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /app

# Copy csproj and restore
COPY src/TalentDataTracker.API/TalentDataTracker.API.csproj src/TalentDataTracker.API/
RUN dotnet restore src/TalentDataTracker.API/TalentDataTracker.API.csproj

COPY src ./src

# Build
WORKDIR /app/src/TalentDataTracker.API
RUN dotnet build TalentDataTracker.API.csproj -c $BUILD_CONFIGURATION -o /app/build

# Publish
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish TalentDataTracker.API.csproj -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TalentDataTracker.API.dll"]