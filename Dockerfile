FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 82

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["PocApi/PocApi.sln", "./"]
COPY ["PocApi/Dominio/Dominio.csproj", "Dominio/"]
COPY ["PocApi/Infra/Infra.csproj", "Infra/"]
COPY ["PocApi/PocApi/PocApi.csproj", "PocApi/"]
RUN dotnet restore "PocApi/PocApi.csproj"
COPY PocApi .
WORKDIR "/src/PocApi"
RUN dotnet build "PocApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PocApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PocApi.dll"]