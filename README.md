
# Cloud Incident Management

A microservices-based application for managing cloud operational events, incidents, and DevOps automation using .NET and Azure technologies.

## Project Overview

The application is designed to explore how distributed services can process operational events, manage incidents, and support troubleshooting through AI-assisted analysis.

## Planned Architecture

- Microservices with independent service responsibilities
- REST APIs for synchronous communication
- RabbitMQ for asynchronous event-driven communication
- Clean Architecture principles within services
- Independent data ownership using EF Core
- Docker and Kubernetes for container orchestration
- Azure for cloud deployment and monitoring

## Planned Services

| Service | Responsibility |
|---|---|
| Event Ingestion | Receive, validate, and publish operational events |
| Incident Management | Manage incidents, severity, status, and lifecycle |
| AI Analysis | Analyze logs, pipeline failures, and incidents |
| Knowledge | Provide runbook retrieval and troubleshooting knowledge |
| Notification | Process incident notifications |

## Technology Stack

- .NET 11 / C#
- ASP.NET Core Web API
- Entity Framework Core
- RabbitMQ
- SQL Server
- Docker and Docker Compose
- Kubernetes / AKS
- GitHub Actions
- Azure
- Terraform
- OpenTelemetry
- AI / RAG integration

## Development Approach

The project is being implemented incrementally, starting with the Event Ingestion and Incident Management services.

Each feature will include appropriate validation, testing, documentation, and operational considerations.

## Project Status

**In development — repository initialization.**

The architecture and features described above represent the planned implementation and are not yet complete.
