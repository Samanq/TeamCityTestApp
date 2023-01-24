FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5000

ENV ASPNETCORE_URLS=http://+:5000

RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TeamCityTestApp.WebApi/TeamCityTestApp.WebApi.csproj", "TeamCityTestApp.WebApi/"]
RUN dotnet restore "TeamCityTestApp.WebApi/TeamCityTestApp.WebApi.csproj"
COPY . .
WORKDIR "/src/TeamCityTestApp.WebApi"
RUN dotnet build "TeamCityTestApp.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TeamCityTestApp.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TeamCityTestApp.WebApi.dll"]