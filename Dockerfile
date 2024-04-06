FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY *.sln .
COPY . .

RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
COPY --from=build /app/out ./

ENTRYPOINT ["dotnet", "AugustaGourmet.Api.WebAPI.dll"]