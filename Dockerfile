#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ParcialMs/ParcialMs.csproj", "ParcialMs/"]
RUN dotnet restore "ParcialMs/ParcialMs.csproj"
COPY . .
WORKDIR "/src/ParcialMs"
RUN dotnet build "ParcialMs.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ParcialMs.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ParcialMs.dll"]