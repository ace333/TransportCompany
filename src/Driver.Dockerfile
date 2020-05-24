FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env

WORKDIR /src

COPY TransportCompany.Shared.Domain/. ./TransportCompany.Shared.Domain
COPY TransportCompany.Shared.EventStore/. ./TransportCompany.Shared.EventStore
COPY TransportCompany.Shared.Infrastructure/. ./TransportCompany.Shared.Infrastructure
COPY TransportCompany.Shared.Application/. ./TransportCompany.Shared.Application
COPY TransportCompany.Shared.ApiInfrastructure/. ./TransportCompany.Shared.ApiInfrastructure
COPY TransportCompany.Driver.Domain/. ./TransportCompany.Driver.Domain
COPY TransportCompany.Driver.Infrastructure/. ./TransportCompany.Driver.Infrastructure
COPY TransportCompany.Driver.Application/. ./TransportCompany.Driver.Application
COPY TransportCompany.Driver.WebAPI/. ./TransportCompany.Driver.WebAPI

RUN dotnet publish TransportCompany.Driver.WebAPI -c Release -o /app

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app .
ENTRYPOINT ["dotnet", "TransportCompany.Driver.WebApi.dll"]

