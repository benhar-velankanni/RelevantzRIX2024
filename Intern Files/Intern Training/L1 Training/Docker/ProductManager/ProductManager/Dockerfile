# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
 
# Copy the project file and restore dependencies
COPY ["ProductManager.csproj", "./"]
RUN dotnet restore "ProductManager.csproj"
 
# Copy the entire source code
COPY . .
 
# Build the project
RUN dotnet build "ProductManager.csproj" -c Release -o /app/build
 
# Stage 2: Publish the application
FROM build AS publish
RUN dotnet publish "ProductManager.csproj" -c Release -o /app/publish /p:UseAppHost=false
 
# Stage 3: Create the final runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
USER root
EXPOSE 8080
EXPOSE 8081
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductManager.dll"]