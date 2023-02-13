 FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
 WORKDIR /app
 EXPOSE 8000

 ENV ASPNETCORE_URLS=http://+:8000

 FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
 WORKDIR /src
 COPY ["otus.health.csproj", ""]
 RUN dotnet restore "./otus.health.csproj"
 COPY . .
 WORKDIR "/src/."
 RUN dotnet build "otus.health.csproj" -c Release -o /app/build
 FROM build AS publish
 RUN dotnet publish "otus.health.csproj" -c Release -o /app/publish
 FROM base AS final
 WORKDIR /app
 COPY --from=publish /app/publish .
 ENTRYPOINT ["dotnet", "otus.health.dll"]