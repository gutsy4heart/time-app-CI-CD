FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

COPY LiteraHouse.sln ./
COPY LiteraHouse/*.csproj LiteraHouse/

RUN dotnet restore

COPY . .

WORKDIR /src/LiteraHouse

RUN dotnet publish LiteraHouse.csproj -c Release -o /app/out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

WORKDIR /app

COPY --from=build /app/out ./

EXPOSE 5042

ENTRYPOINT ["/bin/sh", "-c", "\
  echo '⏳ Waiting for MSSQL...'; \
  for i in $(seq 1 30); do \
    timeout 1 bash -c 'cat < /dev/null > /dev/tcp/mssql/1433' 2>/dev/null && break; \
    echo 'MSSQL not ready yet... retrying'; \
    sleep 1; \
  done; \
  echo '✅ MSSQL is up - starting API'; \
  dotnet LiteraHouse.dll"]
