# TransportCompany

TransportCompany application is a distributed microservices application created as the technical part of master thesis:  
**Domain Driven Design concept based on the example of an application designed to handle transport company's orders**

## Services

* **Customer** - service allows customer to manipulate his personal data and modify requested rides properties
* **Driver** - service allows driver to manipulate his personal data along with car, driver's licence and company details modification
* **Order** - service for processing rides information, manipulating and displaying transport company's orders

## Infrastructure

* **Microsoft SQL Server** - database (database-per-service pattern implemented)
* **RabbitMQ** - message broker (publish/subsribe messages transport type implemented)

## Prerequisities

In order to run application locally you'll need docker installed.

* [Windows](https://docs.docker.com/windows/started)
* [OS X](https://docs.docker.com/mac/started/)
* [Linux](https://docs.docker.com/linux/started/)

## How to run

In order to run application locally you need to run powershell or cmd console in `/TransportCompany/src/` and run the docker.  
  
First to build all the services' images...    
```shell
docker-compose build
```
...and to run the whole thing
```shell
docker-compose up
```

To close the application down:  
```shell
docker-compose down
```

## API documentation

The http requests that are used in the transport comapny's API's are contained in  
`Transport Company APIs.postman_collection.json` in `/TransportCompany/postman/` destination.  
  
All you need to do before using the postman created http requests and have fun is to... install the postman application from here: [Postman](https://www.postman.com/downloads/).
