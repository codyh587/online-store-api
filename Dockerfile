#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# Get .NET SDK, install dependencies, and create optimized production build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["OnlineStoreAPI.csproj", "."]
RUN dotnet restore "./OnlineStoreAPI.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet publish "OnlineStoreAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Get optimized ASP.NET Core runtime image and listen on 8080
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
ENV ASPNETCORE_URLS=http://*:8080
EXPOSE 8080
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "OnlineStoreAPI.dll"]