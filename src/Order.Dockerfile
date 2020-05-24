FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env

WORKDIR /src

COPY TransportCompany.Shared.Domain/. ./TransportCompany.Shared.Domain
COPY TransportCompany.Shared.EventStore/. ./TransportCompany.Shared.EventStore
COPY TransportCompany.Shared.Infrastructure/. ./TransportCompany.Shared.Infrastructure
COPY TransportCompany.Shared.Application/. ./TransportCompany.Shared.Application
COPY TransportCompany.Shared.ApiInfrastructure/. ./TransportCompany.Shared.ApiInfrastructure
COPY TransportCompany.Order.Domain/. ./TransportCompany.Order.Domain
COPY TransportCompany.Order.Infrastructure/. ./TransportCompany.Order.Infrastructure
COPY TransportCompany.Order.Application/. ./TransportCompany.Order.Application
COPY TransportCompany.Order.WebAPI/. ./TransportCompany.Order.WebAPI

RUN dotnet publish TransportCompany.Order.WebAPI -c Release -o /app

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app .
ENTRYPOINT ["dotnet", "TransportCompany.Order.WebApi.dll"]

