#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["LocalForecast53.API/LocalForecast53.API.csproj", "LocalForecast53.API/"]
COPY ["LocalForecast53.Application/LocalForecast53.Application.csproj", "LocalForecast53.Application/"]
COPY ["LocalForecast53.Core/LocalForecast53.Core.csproj", "LocalForecast53.Core/"]
COPY ["LocalForecast53.Shared/LocalForecast53.Shared.csproj", "LocalForecast53.Shared/"]
RUN dotnet restore "./LocalForecast53.API/LocalForecast53.API.csproj"
COPY . .
WORKDIR "/src/LocalForecast53.API"
RUN dotnet build "./LocalForecast53.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./LocalForecast53.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LocalForecast53.API.dll"]