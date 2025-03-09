FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine3.20
WORKDIR /usr/src/api

COPY Events.sln .

COPY Events.Api/Events.Api.csproj ./Events.Api/
COPY Events.Api/. ./Events.Api/

COPY Events.Api/. ./Events.Api/
COPY Events.Application/Events.Application.csproj ./Events.Application/
COPY Events.Application/. ./Events.Application/

COPY Events.Domain/Events.Domain.csproj ./Events.Domain/
COPY Events.Domain/. ./Events.Domain/

COPY Events.Common/Events.Common.csproj ./Events.Common/
COPY Events.Common/. ./Events.Common/

COPY Events.Persistance/Events.Persistance.csproj ./Events.Persistance/
COPY Events.Persistance/. ./Events.Persistance/

COPY Events.Infrastructure/Events.Infrastructure.csproj ./Events.Infrastructure/
COPY Events.Infrastructure/. ./Events.Infrastructure/

COPY Events.Application/. ./Events.Application/
COPY Events.Tests/Events.Tests.csproj ./Events.Tests/
COPY Events.Tests/. ./Events.Tests/
COPY Events.Web/Events.Web.esproj ./Events.Web/

RUN dotnet restore

RUN dotnet tool install --version 8.0.0 --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"

WORKDIR /usr/src/api/Events.Api
CMD ["dotnet", "watch", "--launch-profile", "docker", "--configuration", "Debug"]
