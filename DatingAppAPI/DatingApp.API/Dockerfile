#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["DatingAppAPI/DatingApp.API/DatingApp.API.csproj", "DatingAppAPI/DatingApp.API/"]
COPY ["DatingAppAPI/DatingApp.BusinessLayer/DatingApp.BusinessLayer.csproj", "DatingAppAPI/DatingApp.BusinessLayer/"]
COPY ["DatingAppAPI/DatingApp.DAL/DatingApp.DAL.csproj", "DatingAppAPI/DatingApp.DAL/"]
COPY ["DatingAppAPI/DatingApp.Repositories/DatingApp.Repositories.csproj", "DatingAppAPI/DatingApp.Repositories/"]
RUN dotnet restore "./DatingAppAPI/DatingApp.API/DatingApp.API.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "./DatingAppAPI/DatingApp.API/DatingApp.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./DatingAppAPI/DatingApp.API/DatingApp.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DatingApp.API.dll"]