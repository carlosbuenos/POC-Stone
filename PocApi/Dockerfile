FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 82

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["PocApi.sln", "./"]
COPY ["Dominio/Dominio.csproj", "Dominio/"]
COPY ["Infra/Infra.csproj", "Infra/"]
COPY ["PocApi/PocApi.csproj", "PocApi/"]
RUN dotnet restore "PocApi/PocApi.csproj"
COPY . .
WORKDIR "/src/PocApi"
RUN dotnet build "PocApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PocApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PocApi.dll"]