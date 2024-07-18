# IoC Life Cycles Example API

This repository contains an example API demonstrating the different lifecycles of services in an IoC (Inversion of Control) container using .NET. The API has one endpoint `IocLifeCyclesExampleController.Get()` that returns a JSON response with GUIDs from six services to illustrate the behavior of scoped, singleton, and transient lifecycles.

Additionally, this project uses Swagger and Swagger annotations for API documentation and demonstrates keyed interface injection.

## Table of Contents

- [Getting Started](#getting-started)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Usage](#usage)
- [Service Lifecycles](#service-lifecycles)
  - [Singleton](#singleton)
  - [Scoped](#scoped)
  - [Transient](#transient)
- [Keyed Dependency Injection](#keyed-dependency-injection)
- [API Documentation](#api-documentation)
- [API Endpoint](#api-endpoint)
- [Contributing](#contributing)
- [License](#license)

## Getting Started

These instructions will guide you on how to set up and run the project on your local machine for development and testing purposes.

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later
- A code editor or IDE (e.g., Visual Studio, Visual Studio Code)

### Installation

1. Clone the repository:

    ```bash
    git clone https://github.com/bofa78/IocLifeCyclesExample.git
    cd IocLifeCyclesExample
    ```

2. Restore the dependencies:

    ```bash
    dotnet restore
    ```

3. Build the project:

    ```bash
    dotnet build
    ```

### Usage

Run the application:

```bash
dotnet run
```

The API will be available at `https://localhost:7244/`.

## Service Lifecycles

`https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection#service-lifetimes`
In this example, we demonstrate the following service lifecycles:

### Singleton

- **SingletonServiceA**
- **SingletonServiceB**

Singleton services are created once and shared throughout the application's lifetime. Their GUIDs remain constant across multiple requests.

### Scoped

- **ScopedServiceA**
- **ScopedServiceB**

Scoped services are created once per request. Their GUIDs change with each new request but remain consistent within the same request.

### Transient

- **TransientServiceA**
- **TransientServiceB**

Transient services are created every time they are requested. Their GUIDs change every time they are requested within the same request or across different requests.

## Keyed Dependency Injection

This project also demonstrates how to use keyed interface injection to resolve services by a specific key. This technique allows you to register multiple implementations of the same interface and resolve them using a key.

## API Documentation

This project uses Swagger and Swagger annotations for API documentation. Swagger provides a user-friendly interface to explore and test the API endpoints.

To access the Swagger UI, run the application and navigate to `https://localhost:7244/` in your web browser.

### Swagger Annotations

Swagger annotations are used to enhance the generated documentation with additional details, descriptions, and examples.

## API Endpoint

### `GET /IocLifeCyclesExample`

This endpoint returns a JSON object containing GUIDs from the six services, showing how they change according to their lifecycle settings.

#### Example Response

```json
{
  "SingletonServiceA": "8d5f75bc-9d1e-4d89-9a4d-c3e8c2dcb1a5",
  "SingletonServiceB": "8d5f75bc-9d1e-4d89-9a4d-c3e8c2dcb1a5",
  "ScopedServiceA": "1b9d35ae-72d3-4c28-9b4a-68d1c5d2e5d7",
  "ScopedServiceB": "1b9d35ae-72d3-4c28-9b4a-68d1c5d2e5d7",
  "TransientServiceA": "f3b6c5c8-73c9-4f99-9f2b-64b2c3e2f2e1",
  "TransientServiceB": "c4e5b8d9-8e2d-4a8e-9a5c-c7e2c5d2e2d3"
}
```

## Contributing

Contributions are welcome! Please follow these steps:

1. Fork the repository.
2. Create a new branch: `git checkout -b feature/your-feature-name`.
3. Make your changes.
4. Commit your changes: `git commit -m 'Add some feature'`.
5. Push to the branch: `git push origin feature/your-feature-name`.
6. Submit a pull request.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details.
```

Feel free to customize this README further based on your project's specific details and requirements.
