#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src

COPY Orders.sln ./
COPY Domain/*.csproj ./Domain/
COPY Tests/*.csproj ./Tests/
COPY Application/*.csproj ./Application/
COPY Infrastructure/*.csproj ./Infrastructure/
COPY API/*.csproj ./API/

RUN dotnet restore

COPY . .
WORKDIR /src/Domain
RUN dotnet build -c Release -o /app

WORKDIR /src/Application
RUN dotnet build -c Release -o /app

WORKDIR /src/Infrastructure
RUN dotnet build -c Release -o /app

WORKDIR /src/Tests
RUN dotnet build -c Release -o /app

WORKDIR /src/API
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish "API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.dll"]