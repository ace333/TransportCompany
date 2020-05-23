FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env

WORKDIR /src

COPY TransportCompany.Shared.Domain/. ./TransportCompany.Shared.Domain
COPY TransportCompany.Shared.Infrastructure/. ./TransportCompany.Shared.Infrastructure
COPY TransportCompany.Shared.Application/. ./TransportCompany.Shared.Application
COPY TransportCompany.Shared.ApiInfrastructure/. ./TransportCompany.Shared.ApiInfrastructure
COPY TransportCompany.Customer.Domain/. ./TransportCompany.Customer.Domain
COPY TransportCompany.Customer.Infrastructure/. ./TransportCompany.Customer.Infrastructure
COPY TransportCompany.Customer.Application/. ./TransportCompany.Customer.Application
COPY TransportCompany.Customer.WebAPI/. ./TransportCompany.Customer.WebAPI

RUN dotnet publish TransportCompany.Customer.WebAPI -c Release -o /app

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app .
ENTRYPOINT ["dotnet", "TransportCompany.Customer.WebApi.dll"]

