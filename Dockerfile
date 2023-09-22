#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Project2p4/Project2p4.csproj", "Project2p4/"]
RUN dotnet restore "Project2p4/Project2p4.csproj"
COPY . .
WORKDIR "/src/Project2p4"
RUN dotnet build "Project2p4.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Project2p4.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Project2p4.dll"]