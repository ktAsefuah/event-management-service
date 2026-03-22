# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["EventManager.csproj", "./"]
RUN dotnet restore "EventManager.csproj"
COPY . .
RUN dotnet build "EventManager.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "EventManager.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "EventManager.dll"]
