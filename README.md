<h1 align='center'>
  🥄 REST Gourmet 🔪
</h1>

[![Last Release](https://img.shields.io/github/v/release/bartolek153/rest-gourmet?logo=github&label=latest&style=flat-square)](https://github.com/bartolek153/rest-gourmet/releases)
[![Build](https://img.shields.io/github/actions/workflow/status/bartolek153/rest-gourmet/main.yml?branch=main&logo=github&style=flat-square)](https://nightly.link/bartolek153/rest-gourmet/workflows/pipeline/master)

<p >
  REST Gourmet is a comprehensive restaurant management application designed to streamline the operations of restaurants, cafes, and food establishments.
  The project consists of a RESTful API backend for managing restaurant data and a user-friendly UI frontend for interacting with the system.
</p>

1. [Features](#features)
2. [Installation](#installation)
3. [Running in development](#rundev)
4. [Documentation](#documentation)
5. [TODO](#todo)

## Features (under development)

<div align='center'>
  <img alt="whatsapp" src="https://img.shields.io/badge/WhatsApp-25D366?style=for-the-badge&logo=whatsapp&logoColor=white" />
  <img alt="telegram" src="https://img.shields.io/badge/Telegram-2CA5E0?style=for-the-badge&logo=telegram&logoColor=white" />
  <img alt="gmail" src="https://img.shields.io/badge/Gmail-D14836?style=for-the-badge&logo=gmail&logoColor=white" />

  </br>
  <img alt="jwt" src="https://img.shields.io/badge/JWT-000000?style=for-the-badge&logo=JSON%20web%20tokens&logoColor=white" />

  </br></br>
</div>

* CRUD Operations
* User Management
* Employees Attendance and Activities Control
* Inventory Tracking
* Brazillian NFe Receipts Management

<div align='center'>
  <img src="/.github/assets/nfe.png" height=50 width=50 alt="NFe" />
</div>

## Installation

```bash
docker run -d --name rest-gourmet ghcr.io/bartolek153/rest-gourmet
```

## Running in development

### Starting REST API on [http://localhost:5274](http://localhost:5274)

```bash
dotnet run --project AugustaGourmet.Api.WebAPI
```

### Starting UI on [http://localhost:5173/](http://localhost:5173/)

```bash
cd UI
yarn
yarn dev
```

### Launching Azure Functions locally

```bash
cd Functions
func host start
```

## Documentation

## TODO

* Features
  * Add multitenancy
  * Implement cancellation tokens
* Code Improvement
  * Add IDateTimeProvider interface
  * Add unit tests
  * Decouple email reader and sender to be server agnostic
  * Update React-Admin to v5
* Bug Fixes
  * Fix UI forms not letting submit again after 400 response

## Refactor History

* Migrate from .NET Framework 4.6 to .NET Core 8 ✔️
* Migrate from EF6 to EF Core ✔️
* Implement JWT ✔️
* Rename code entities and add enumerated types ✔️
* Rename database objects, use schemas and add table indexes ❌
* Review entities data types 🟨
* Implement base entities and auditable entities ✔️
* Add multiple environments (development, staging and production areas) 🟨
* Add CI/CD workflow and manage credentials ✔️
* Add logging and text messaging ✔️
* Add Unit of Work pattern ✔️
* Create domain events ❌
* Create dynamic sorting, filtering and paging 🟨
* Add new caching strategies ❌
* Add client-side valiation ❌
* Setup authorization and Swagger authentication ❌
* Dockerize ❌
* Rebase commit history (conventional commit messages) ❌

## Credits/Acknowledgements

### Commit Convention

* [Conventional Commits](https://www.conventionalcommits.org/en/v1.0.0/)

### Code Suggestions

* UI Tree Layout (<https://marmelab.com/react-admin-demo/#/invoices>)
* UI Side Detail Layout (<https://marmelab.com/react-admin-demo/#/reviews/80>)
* UI Flex Form Layouts (<https://marmelab.com/react-admin-demo/#/customers/26>)
* UI Dialog (<https://marmelab.com/blog/2018/08/27/react-admin-tutorials-custom-forms-related-records.html>)

## Technologies used

![React](https://img.shields.io/badge/React-20232A?style=for-the-badge&logo=react&logoColor=61DAFB)
![Vite](https://img.shields.io/badge/Vite-B73BFE?style=for-the-badge&logo=vite&logoColor=FFD62E)
![TS](https://img.shields.io/badge/ts--node-3178C6?style=for-the-badge&logo=ts-node&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![MSSQL](https://img.shields.io/badge/Microsoft_SQL_Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)
![Functions](https://img.shields.io/badge/Azure_Functions-0062AD?style=for-the-badge&logo=azure-functions&logoColor=white)
![Swagger](https://img.shields.io/badge/Swagger-85EA2D?style=for-the-badge&logo=Swagger&logoColor=white)
