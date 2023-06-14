#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Get ASP.NET Core runtime image, allow HTTP and HTTPS
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base

# Get .NET SDK, install dependencies
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["OnlineStoreAPI.csproj", "."]
RUN dotnet restore "./OnlineStoreAPI.csproj"
COPY . .
WORKDIR "/src/."

# Create optimized production build
FROM build AS publish
RUN dotnet publish "OnlineStoreAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Run with optimized ASP.NET Core runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://*:8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "OnlineStoreAPI.dll"]