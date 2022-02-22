# banking.operation-receipt-consumer

Banking Operation Solution - Receipt Consumer

[![.NET](https://github.com/EdsonCaliman/banking.operation-receipt-consumer/actions/workflows/dotnet.yml/badge.svg?branch=main)](https://github.com/EdsonCaliman/banking.operation-receipt-consumer/actions/workflows/dotnet.yml)
[![Coverage Status](https://coveralls.io/repos/github/EdsonCaliman/banking.operation-receipt-consumer/badge.svg?branch=main)](https://coveralls.io/github/EdsonCaliman/banking.operation-receipt-consumer?branch=main)

This project is a part of a Banking Operation solution, with DDD and microservices architecture, using .Net Core.

![BankingOperations (1)](https://user-images.githubusercontent.com/19686147/133843637-85277ee1-9748-4456-befa-4b2265e3ebec.jpg)

Using a docker-compose configuration the components will be connected so that together they work as a solution.

This component will be responsible for register the receipts, It uses Kafka for consume data.

![image](https://user-images.githubusercontent.com/19686147/155213936-d9ee7a55-04f6-497d-b4f8-540d2f839776.png)

# How to run

With a docker already installed run:

docker-compose up -d
