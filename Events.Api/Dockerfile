FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine3.20
WORKDIR /usr/src/api

COPY Events.sln .
COPY Events.Api/Events.Api.csproj ./Events.Api/
COPY Events.Application/Events.Application.csproj ./Events.Application/
COPY Events.Web/Events.Web.esproj ./Events.Web/
COPY Events.Tests/Events.Tests.csproj ./Events.Tests/
COPY Events.Api/. ./Events.Api/
COPY Events.Application/. ./Events.Application/
RUN dotnet restore

WORKDIR /usr/src/api/Events.Api
CMD ["dotnet", "watch", "--launch-profile", "docker"]
