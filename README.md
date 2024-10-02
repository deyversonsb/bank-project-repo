[![Build and Test](https://github.com/deyversonsb/bank-project-repo/actions/workflows/build.yml/badge.svg)](https://github.com/deyversonsb/bank-project-repo/actions/workflows/build.yml)

# Bank Project

The Banking Project API was implemented with vertical slice architecture:

![vertical_slice_arch](https://github.com/user-attachments/assets/bcfc0d2d-c1ef-46b2-a6de-db27b1de6496)

How is implemented this API:

- .NET 8
- Visual Studio 2022 Version 17.10
- C#
- Minimal API

Frameworks:

- Redis 
- FluentValidation
- MediatR
- MassTransit

Documention:

- Swagger

Tests Frameworks:

- NetArchTest
- Xunit
- FluentAssertions

# Getting Started
  
### Prerequisites

- Clone the Banking API repository: https://github.com/deyversonsb/bank-project-repo
- [Install & start Docker Desktop](https://docs.docker.com/engine/install/)
 
### Running the solution

> [!WARNING]
> 
> Remember to ensure that Docker is started

- (Windows only) Run the application from Visual Studio:
- Open the `Banking.sln` file in Visual Studio
- Ensure that `docker-compose.dcproj` is your startup project.
- Play `Docker Compose` to launch
- Open the link on browser: <https://localhost:5001/swagger/index.html>
- swagger-ui looks like this:
![image](https://github.com/user-attachments/assets/8cd7d152-e837-4f70-877d-722147ec589c)
