FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env
WORKDIR /app

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out core-api/core-api.csproj

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
EXPOSE 5000
EXPOSE 5001
WORKDIR /app
COPY --from=build-env /app/core-api/out .
ENTRYPOINT ["dotnet", "core-api.dll"]