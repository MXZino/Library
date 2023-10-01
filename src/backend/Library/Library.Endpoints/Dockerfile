FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Library.Endpoints/Library.Endpoints.csproj", "Library.Endpoints/"]
RUN dotnet restore "Library.Endpoints/Library.Endpoints.csproj"
COPY . .
WORKDIR "/src/Library.Common.Endpoints"
RUN dotnet build "Library.Endpoints.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "Library.Endpoints.csproj" -c Debug -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Library.Endpoints.dll"]
