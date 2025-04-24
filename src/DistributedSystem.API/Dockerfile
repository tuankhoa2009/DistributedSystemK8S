#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY DistributedSystem.API/DistributedSystem.API.csproj DistributedSystem.API/
#COPY DistributedSystem.Infrastructure/DistributedSystem.Infrastructure.csproj DistributedSystem.Infrastructure
COPY DistributedSystem.Application/DistributedSystem.Application.csproj DistributedSystem.Application
COPY DistributedSystem.Contract/DistributedSystem.Contract.csproj DistributedSystem.Contract
COPY DistributedSystem.Domain/DistributedSystem.Domain.csproj DistributedSystem.Domain
COPY DistributedSystem.Persistence/DistributedSystem.Persistence.csproj DistributedSystem.Persistence
COPY DistributedSystem.Presentation/DistributedSystem.Presentation.csproj DistributedSystem.Presentation
RUN dotnet restore "DistributedSystem.API/DistributedSystem.API.csproj"
COPY . .
WORKDIR "/src/DistributedSystem.API"
RUN dotnet build "DistributedSystem.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "DistributedSystem.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DistributedSystem.API.dll"]