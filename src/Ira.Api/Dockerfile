#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.
#Este Dockerfile se usa para automatizar la construcción y ejecución de la aplicación Ira.Api en un contenedor Docker, facilitando su despliegue y pruebas.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Ira.Api/Ira.Api.csproj", "Ira.Api/"]
RUN dotnet restore "Ira.Api/Ira.Api.csproj"
COPY . .
WORKDIR "/src/Ira.Api"
RUN dotnet build "Ira.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ira.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ira.Api.dll"]