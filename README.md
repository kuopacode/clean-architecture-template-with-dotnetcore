# clean-architecture-template

This is a clean architecture template implemented in .Net Core 7, featuring:

### DDD (Domain-Driven Design) Architecture
Organize your codebase around your business domain for better maintainability and scalability.

### CQRS (Command Query Responsibility Segregation)
Separate command and query operations to optimize system performance and responsiveness.

### Event-Driven with Kafka
Utilize Kafka for reliable and scalable event distribution, enabling real-time and reactive systems.

## Getting Started

### Database Setup
- Create a 'product' schema in localhost.
- Execute SQL commands from the 'sql' file to create tables.
- Update the MySQL connection string in "\src\Product.Api\appsettings.Development.json".

**Note**: Ensure database setup and connection string configuration before proceeding.

## TODO
- kafka
- unit test
- Nlog