FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["common/Library.Common.Endpoints/Library.Common.Endpoints.csproj", "common/Library.Common.Endpoints/"]
RUN dotnet restore "common/Library.Common.Endpoints/Library.Common.Endpoints.csproj"
COPY . .
WORKDIR "/src/common/Library.Common.Endpoints"
RUN dotnet build "Library.Common.Endpoints.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Library.Common.Endpoints.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Library.Common.Endpoints.dll"]
