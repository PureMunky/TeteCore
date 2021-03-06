FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

RUN apt-get update
RUN apt-get -y install build-essential
RUN apt-get -y install curl gnupg
RUN curl -sL https://deb.nodesource.com/setup_10.x  | bash -
RUN apt-get install nodejs -y

# Copy everything else and build
COPY . ./

RUN bash markbuild.sh
RUN dotnet publish -c Release -o out Tete.Web/Tete.Web.csproj

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
EXPOSE 80 443 
WORKDIR /app
COPY --from=build-env /app/out .
# COPY --from=build-env /app/Tete.Web/Tete.Web.pfx ./Tete.Web.pfx
ENTRYPOINT ["dotnet", "Tete.Web.dll"]