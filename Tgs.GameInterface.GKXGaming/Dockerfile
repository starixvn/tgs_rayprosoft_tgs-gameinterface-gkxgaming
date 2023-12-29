#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["nuget.config", "."]
COPY ["Tgs.GameInterface.GKXGaming/Tgs.GameInterface.GKXGaming.csproj", "Tgs.GameInterface.GKXGaming/"]
COPY ["Tgs.GameInterface.GKXGaming.Core/Tgs.GameInterface.GKXGaming.Core.csproj", "Tgs.GameInterface.GKXGaming.Core/"]
RUN dotnet restore "./Tgs.GameInterface.GKXGaming/./Tgs.GameInterface.GKXGaming.csproj"
COPY . .
WORKDIR "/src/Tgs.GameInterface.GKXGaming"
RUN dotnet build "./Tgs.GameInterface.GKXGaming.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Tgs.GameInterface.GKXGaming.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tgs.GameInterface.GKXGaming.dll"]