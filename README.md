# CacheAndQueue

## Overview
This project is designed using Onion Architecture, focusing on maintainability, testability, and scalability. The key features and technologies used are as follows:

## Message Queue- RabbitMQ 
Used to handle order-related operations asynchronously through a queuing mechanism. A consumer service processes these messages, ensuring reliable and efficient order processing.

- **Examples:**
  - Scalability and Reliability: Using RabbitMQ for order processing allows the system to handle high volumes of orders asynchronously. 
  - This decouples the order submission process from order processing, improving the system's responsiveness and reliability.


## Cache - Redis
Employed for caching product information, reducing the load on the database and improving the response time for read operations.Caching frequently accessed data in Redis reduces the load on the database and improves the response time of the application.

## Middleware and ValidationFilter
By using middleware for validation, we can intercept and handle validation errors before they reach the business logic, providing immediate feedback to the client and improving the overall user experience.

- **Examples:**
  - Implemented a custom middleware for validation, which intercepts requests before they reach the endpoint. This middleware checks for validation errors and returns a response to the client if any issues are found, improving the robustness and user experience of the API.
  - ValidationFilter: Used to handle validation logic, ensuring that invalid data does not proceed further in the request pipeline.

## Validation and Mapping
- **Examples:**
  - Fluent Validation: Utilized for defining and managing validation rules for the application, ensuring data integrity and consistency.
  - AutoMapper: Facilitates object-to-object mapping, reducing the boilerplate code required for transforming data between different layers of the application.


## Design Patterns
- **Examples:**
  - CQRS (Command Query Responsibility Segregation): Applied to separate read and write operations, enhancing the scalability and performance of the application.
  - Repository Pattern: Ensures a clean separation of concerns between the data access layer and business logic, promoting a more maintainable and testable codebase.

## User Management and Authentication

  - ### .NET Identity
 Used for managing user-related operations such as registration, login, and role management.
  - ### JWT Token
Implemented for handling authentication and securing the API endpoints.


## Installation and Usage

To clone the project to your local environment:

```bash
git clone https://github.com/BatuhanKayaoglu/CacheAndQueue.git
